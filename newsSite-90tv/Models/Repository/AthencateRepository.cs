using newsSite90tv.Models.apimodels;
using newsSite90tv.Models.apiobject;
using newsSite90tv.Models.Services;
using newsSite90tv.Models.UnitOfWork;
using newsSite90tv.PublicClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.Repository
{
    public class AthencateRepository : IAthenticate
    {
        private readonly IUnitOfWork _context;
        private readonly IUserapp _userapp;
        private readonly Isend _isend;
        private readonly IsaveImage _saveimage;

        public AthencateRepository(IUnitOfWork context, IUserapp userapp, Isend isend, IsaveImage isaveImage)
        {
            _context = context;
            _userapp = userapp;
            _isend = isend;

            _saveimage = isaveImage;
        }

        public async Task<UserApp> checkToken(string token)
        {
            try
            {
                return await _context.userappRepositoryUW.GetAsync(a => a.token == token && a.isEnable);
            }
            catch (Exception)
            {

                return null;
            }
        }
     



        public async Task<AllApi> register(RegisterApiModel register)
        {
            var api = new AllApi();
            try
            {

                var user = await _userapp.IsUserappExist(register.mobile);

                if (user != null)
                {
                    // user exist 
                    api.message = EndPointMessage.API_USER_REGISTER_EXIST;
                    api.status = EndPointMessage.API_ERROR_Std;
                }
                else
                {
                    //user not exist


                    // check inputs fields is valid
                    if (string.IsNullOrEmpty(register.firstname))
                    {
                        api.message = "فیلد نام وارد شود";
                        api.status = EndPointMessage.API_ERROR_Std;

                        return api;
                    }


                    if (string.IsNullOrEmpty(register.firstname))
                    {
                        api.message = "فیلد نام خانوادگی  وارد شود";
                        api.status = EndPointMessage.API_ERROR_Std;

                        return api;
                    }


                    if (string.IsNullOrEmpty(register.mobile))
                    {
                        api.message = "فیلد شماره همراه وارد شود ";
                        api.status = EndPointMessage.API_ERROR_Std;

                        return api;

                    }

                    if (!Utility.validphone(register.mobile))
                    {
                        api.message = "فیلد شماره همراه بدرستی وارد شود";
                        api.status = EndPointMessage.API_ERROR_Std;

                        return api;

                    }


                    // generate mobile active code

                    var code = Utility.GenerateMobileCode();


                    var newuser = new UserApp
                    {
                        mobile = register.mobile,
                        firstName = register.firstname,
                        lastName = register.lastname,
                        isEnable = true,
                        mobileActiveCode = code,
                        mobileActiveStatus = false,
                        type = 0, // normal user
                        gender = 1, // defualt male
                        image = "defaultuserImage.png",

                        datemiladi = DateTime.Now,
                        dateshamsi = DateAndTimeShamsi.DateTimeShamsi(),
                    };


                    _context.userappRepositoryUW.Create(newuser);
                    await _context.saveAsync();


                    // send verify code code 

                    var sendres = await _isend.sendMessage(code, register.mobile);

                    if (sendres)
                    {
                        // REGISTER OK AND SEND OK
                        api.message = EndPointMessage.API_USER_REGISTER_SUCCESS;
                        api.status = EndPointMessage.API_OK_Std;
                    }
                    else
                    {
                        // REGISTER OK SEND NOT OK
                        api.message = EndPointMessage.API_USER_REGISTER_SUCCESS_CODE_FAIL;
                        api.status = EndPointMessage.API_ERROR_Std;
                    }


                }



            }
            catch (Exception)
            {

                api.message = EndPointMessage.API_OK_MSG;
                api.status = EndPointMessage.API_ERROR_Std;
            }

            return api;
        }


        public async Task<AllApi> login(string mobile)
        {
            var api = new AllApi();
            try
            {
                if (Utility.validphone(mobile))
                {
                    var user = await _userapp.IsUserappExist(mobile);

                    if (user != null)
                    {
                        if (user.isEnable)
                        {
                            user.mobileActiveCode = Utility.GenerateMobileCode();

                            await _context.saveAsync();

                            // send verify code for athenticate
                            var sendres = await _isend.sendMessage(user.mobileActiveCode, user.phone);

                            if (sendres)
                            {
                                api.message = EndPointMessage.API_VERIFY_CODE_SEND;
                                api.status = EndPointMessage.API_OK_Std;
                            }
                            else
                            {
                                api.message = EndPointMessage.API_VERIFY_CODE_Not_SEND;
                                api.status = EndPointMessage.API_ERROR_Std;
                            }

                        }
                        else
                        {
                            api.message = EndPointMessage.API_USER_ACCOUNT_DISABLE;
                            api.status = EndPointMessage.API_ERROR_Std;
                        }


                    }
                    else
                    {
                        api.message = EndPointMessage.API_USER_NOT_EXIST;
                        api.status = EndPointMessage.API_ERROR_Std;
                    }
                }
                else
                {
                    api.message = EndPointMessage.API_PHONE_NOM_INVALID;
                    api.status = EndPointMessage.API_ERROR_Std;
                }


            }
            catch (Exception)
            {

                api.message = EndPointMessage.API_ERROR_MSG;
                api.status = EndPointMessage.API_ERROR_Std;
            }

            return api;
        }




        public async Task<UserAppApiObject> verify(string code, string mobile)
        {
            var api = new UserAppApiObject();

            try
            {
                if (Utility.validphone(mobile))
                {
                    var user = await _userapp.IsUserappExist(mobile);

                    if (user != null)
                    {
                        if (user.isEnable)
                        {
                            if (user.mobileActiveCode == code)
                            {
                                user.token = Utility.GenerateToken();

                                user.mobileActiveStatus = true;

                                await _context.saveAsync();



                                // get user info
                                api.userapp = new UserAppApiModel
                                {
                                    email = user.email,
                                    firstname = user.firstName,
                                    gender = user.gender,
                                    lastname = user.lastName,
                                    mobile = user.mobile,
                                    nationalcode = user.nationalcode,
                                    phone = user.phone,
                                    token = user.token,
                                    type = user.type,

                                    imageurl = string.IsNullOrEmpty(user.image) ? "defaultuserImage.png" : user.image
                                };



                                api.message = EndPointMessage.API_OK_MSG;
                                api.status = EndPointMessage.API_OK_Std;


                            }
                            else
                            {

                                api.message = EndPointMessage.API_VERIFY_CODE_INVALID;
                                api.status = EndPointMessage.API_ERROR_Std;
                            }
                        }
                        else
                        {

                            api.message = EndPointMessage.API_USER_ACCOUNT_DISABLE;
                            api.status = EndPointMessage.API_ERROR_Std;
                        }
                    }
                    else
                    {
                        api.message = EndPointMessage.API_USER_NOT_EXIST;
                        api.status = EndPointMessage.API_ERROR_Std;
                    }
                }
                else
                {
                    api.message = EndPointMessage.API_PHONE_NOM_INVALID;
                    api.status = EndPointMessage.API_ERROR_Std;
                }

            }
            catch (Exception)
            {
                api.message = EndPointMessage.API_ERROR_MSG;
                api.status = EndPointMessage.API_ERROR_Std;
            }


            return api;
        }




        public async Task<AllApi> preregister(string mobile)
        {
            var api = new AllApi();

            try
            {
                if (Utility.validphone(mobile))
                {

                    // check user exist
                    var user = await _userapp.IsUserappExist(mobile);

                    if (user == null)
                    {

                        // check fields
                        if (string.IsNullOrEmpty(mobile))
                        {
                            api.message = "فیلد شماره همراه وارد شود ";
                            api.status = EndPointMessage.API_ERROR_Std;

                            return api;

                        }

                        if (!Utility.validphone(mobile))
                        {
                            api.message = "فیلد شماره همراه بدرستی وارد شود";
                            api.status = EndPointMessage.API_ERROR_Std;

                            return api;

                        }

                        var code = Utility.GenerateMobileCode();

                        var newuser = new UserApp
                        {
                            mobile = mobile,
                            image = "defaultuserImage.png",
                            mobileActiveStatus = false,
                            type = 0,
                            datemiladi = DateTime.Now,
                            dateshamsi = DateAndTimeShamsi.DateTimeShamsi(),
                            mobileActiveCode = code,
                            isEnable = true,
                            gender = 1,




                        };

                        _context.userappRepositoryUW.Create(newuser);

                        await _context.saveAsync();

                        // send verify code 

                        var sendres = await _isend.sendMessage(code, mobile);

                        if (sendres)
                        {
                            // REGISTER OK AND SEND OK
                            api.message = EndPointMessage.API_VERIFY_CODE_SEND;
                            api.status = EndPointMessage.API_OK_Std;
                        }
                        else
                        {
                            // REGISTER OK SEND NOT OK
                            api.message = EndPointMessage.API_USER_REGISTER_SUCCESS_CODE_FAIL;
                            api.status = EndPointMessage.API_ERROR_Std;
                        }

                    }
                    else
                    {
                        api.message = EndPointMessage.API_USER_REGISTER_EXIST;
                        api.status = EndPointMessage.API_ERROR_Std;
                    }

                }
                else
                {
                    api.message = EndPointMessage.API_PHONE_NOM_INVALID;
                    api.status = EndPointMessage.API_ERROR_Std;
                }
            }
            catch (Exception)
            {

                api.message = EndPointMessage.API_ERROR_MSG;
                api.status = EndPointMessage.API_ERROR_Std;
            }

            return api;
        }




        public async Task<AllApi> coderesend(string mobile)
        {
            var api = new AllApi();

            try
            {
                if (Utility.validphone(mobile))
                {
                    var user = await _userapp.IsUserappExist(mobile);

                    if (user != null)
                    {
                        if (user.isEnable)
                        {

                            user.mobileActiveCode = Utility.GenerateMobileCode();


                            await _context.saveAsync();


                            var sendres = await _isend.sendMessage(user.mobileActiveCode, user.phone);


                            if (sendres)
                            {
                                api.message = EndPointMessage.API_VERIFY_CODE_SEND;
                                api.status = EndPointMessage.API_OK_Std;
                            }
                            else
                            {
                                api.message = EndPointMessage.API_VERIFY_CODE_Not_SEND;
                                api.status = EndPointMessage.API_ERROR_Std;
                            }

                        }
                        else
                        {
                            api.message = EndPointMessage.API_USER_ACCOUNT_DISABLE;
                            api.status = EndPointMessage.API_ERROR_Std;
                        }
                    }
                    else
                    {
                        api.message = EndPointMessage.API_USER_NOT_EXIST;
                        api.status = EndPointMessage.API_ERROR_Std;
                    }
                }
                else
                {
                    api.message = EndPointMessage.API_PHONE_NOM_INVALID;
                    api.status = EndPointMessage.API_ERROR_Std;
                }
            }
            catch (Exception)
            {

                api.message = EndPointMessage.API_ERROR_MSG;
                api.status = EndPointMessage.API_ERROR_Std;
            }

            return api;
        }






        public async Task<AllApi> updateprofile(UserAppApiModel model, string token)
        {
            var api = new AllApi();
            try
            {
                var userapp = await this.checkToken(token);

                if (userapp != null)
                {
                    userapp.firstName = model.firstname;
                    userapp.lastName = model.lastname;
                    userapp.mobile = model.mobile;
                    userapp.phone = model.phone;
                    userapp.nationalcode = model.nationalcode;
                    userapp.email = model.email;
                    userapp.image = (!string.IsNullOrEmpty(model.imageurl)) ? await _saveimage.SaveUserAppImage(userapp.image, Convert.FromBase64String(model.imageurl)) : "defaultuserImage.png";




                    _context.userappRepositoryUW.Update(userapp);

                    await _context.saveAsync();

                    api.message = EndPointMessage.API_EDIT_USER_PROFILE;
                    api.status = EndPointMessage.API_OK_Std;


                }
                else
                {
                    api.message = EndPointMessage.API_USER_NOT_EXIST;
                    api.status = EndPointMessage.API_Fail_Std;
                }
            }
            catch (Exception)
            {

                api.message = EndPointMessage.API_Fail_MSG;
                api.status = EndPointMessage.API_Fail_Std;
            }

            return api;
        }


    }
}
