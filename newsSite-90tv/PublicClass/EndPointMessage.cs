using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.PublicClass
{
    public static class EndPointMessage
    {
        public static string SUCCESS_MSG = "با موفقیت ثبت شد";
        public static string SUCCESS_TYPE = "success";

        public static string DONE_MSG = "انجام شد";
        public static string DONE_TYPE = "success";

        public static string SUCCESS_Edit_MSG = "با موفقیت ویرایش شد";
        public static string SUCCESS_Edit_TYPE = "success";

        public static string DELETE_MSG = "با موفقیت حذف شد";
        public static string DELETE_TYPE = "success";


        public static string USER_PHONE_REAPETS = " .کاربری قبلا با این شماره همراه ایجاد شده است ";
        public static string USER_PHONE_REAPETS_TYPE = "info";


        public static string SHOP_NAME_REAPETS = "فروشگاهی قبلا با این نام ایجاد شده است";
        public static string SHOP_NAME_REAPETS_TYPE = "info";



        public static string SHOP_DOUBLE_SELL_BEFORE = "ابن محصول  توسط این فروشنده در حال فروش است فروشنده ی دیگری انتخاب کنید";
        public static string SHOP_DOUBLE_SELL_BEFORE_TYPE = "info";








        public static string Fail_MSG = "در اجرای عملیات خطایی رخ داده است";
        public static string Fail_TYPE = "danger";


        public static string Value_MSG = "مقادیر بدرستی وارد شوند";
        public static string Value_TYPE = "info";


        // MESSAGE ABOUT API



       //STATUS

        public static int API_OK_Std = 200;
        public static int API_ERROR_Std = 500;
        public static int API_Fail_Std = 400;
        public static int API_Token_FAIL_Std = 501;
        public static int API_Param_Std = 502;


        //MESSAGES
        public static string API_OK_MSG = "ok";


        public static string API_CREATE_PRODUCT_SUCCESS = "محصول شما با موفقیت ثبت شد";

        public static string API_DELETE_PRODUCT_SUCCESS = "محصول شما با موفقیت حذف شد";

        public static string API_UPDATE_PRODUCT_SUCCESS = "محصول شما با موفقیت ویرایش شد";


        public static string API_Fail_MSG = "درخواست شما با مشکل مواجه شده است";

        public static string API_SUCCESS_MSG = "درخواست شما با موفقیت ثیت شد";


        public static string API_SELLER_NOT_EXIST = "فروشنده نامعتبر";
      


        public static string API_ERROR_MSG = "Error";

        public static string API_FAIL_TOKEN_MSG = "کاربری نامعتبر،غیر مجاز ";

        public static string API_PRODUCT_CREATE_MSG_SUCCESS = " محصول شما با موفقیت ثبت شد. در انتظار تایید ";

        public static string API_PRODUCT_CREATE_MSG_FAIL = "محصول شما ثبت نشد";


        public static string API_PRODUCT_UPDATE_MSG_SUCCESS = "محصول شما با موفقیت ویرایش شد";

        public static string API_PRODUCT_UPDATE_MSG_FAIL = "محصول شما ویرایش نشد";


        public static string API_PRODUCT_DELETE_MSG_SUCCESS = "محصول شما با موفقیت حذف شد";

        public static string API_PRODUCT_DELETE_MSG_FAIL = "محصول شما حذف نشد";


        public static string API_SHOP_CREATE_MSG_SUCCESS = "... فروشگاه شما با موفقیت ثبت شد. در انتظار تایید";

        public static string API_SHOP_CREATE_MSG_FAIL = "فروشگاه شما ثبت نشد";



        public static string API_SHOP_UPDATE_MSG_SUCCESS = "... فروشگاه شما با موفقیت ویرایش شد. در انتظار تایید";

        public static string API_SHOP_UPDATE_MSG_FAIL = "فروشگاه شما ویرایش نشد";



        public static string API_SHOP_DELETE_MSG_SUCCESS = "فروشگاه شما با موفقیت حذف شد";

        public static string API_SHOP_DELETE_MSG_FAIL = "فروشگاه شما شما حذف نشد";


        public static string API_SHOP_IMAGE_MSG_SUCCESS = "تصویر فروشگاه شما با موفقیت تغییر کرد";

        public static string API_SHOP_IMAGE_MSG_FAIL = "مشکل در ویرایش تصویر";


        public static string API_COMMENT_ADD_MSG_SUCCESS = "  نظر شما با موفقیت ثبت شد. در انتظار تایید";

        public static string API_ADV_ADD_MSG_SUCCESS = "  درخواست تبلیغ فروشگاه شما با موفقیت ثبت شد. در انتظار تایید";

        public static string API_PARAM_ERROR  = "Parameter Error";

        public static string API_USER_REGISTER_EXIST  = "کاربری قبلا با این شماره ثبت نام کرده است";

        public static string API_USER_NOT_EXIST  = "کاربری با این شماره وجود ندارد";

        public static string API_VERIFY_CODE_SEND = "  کد فرستاده شد";

        public static string API_VERIFY_CODE_Not_SEND = " کد فرستاده نشد";

        public static string API_USER_ACCOUNT_DISABLE = "حساب کاربری غیر فعال شده است";

        public static string API_PHONE_NOM_INVALID = "شماره تماس نا معتبر است";

        public static string API_VERIFY_CODE_INVALID = "کد فعال سازی نا معتبر است";

        public static string API_USER_REGISTER_SUCCESS  = "ثبت نام انجام شد کد فرستاده شد";

        public static string API_USER_REGISTER_SUCCESS_CODE_FAIL  = "ثبت نام موفقیت امیز خطا در ارسال کد فعال سازی";

        public static string API_USER_NOT_PRODFILE_COMPLETE  = " (مشخصات فردی الزامی است) لطفا پروفایل کاربری خود را جهت ادامه این فرایند تکمیل کنید ";

        public static string API_CREATE_JOBBANNER_SUCCESS  = "آگهی شما با موفقیت درج شد . در انتظار تایید";

        public static string API_EDIT_JOBBANNER_SUCCESS  = ".آگهی شما با موفقیت ویرایش شد";
        public static string API_DELETE_JOBBANNER_SUCCESS  = ".آگهی شما با موفقیت حذف شد";

        public static string API_CREATE_REPORT_LIMIT  = "تعداد درخواست شما برای دادن گزارش تخلف این محصول به اتمام رسیده است";
        public static string API_CREATE_REPORT_SHOP_LIMIT  = "تعداد درخواست شما برای دادن گزارش تخلف این فروشگاه به اتمام رسیده است";

        public static string API_CREATE_REPORT  = "درخواست شما ثبت شد . در حال بررسی ";


        public static string API_FAV_ADD  = "1"; // for change image in client
        public static string API_FAV_DELETE  = "0";

        public static string API_EDIT_USER_PROFILE  = "ویرایش پروفایل شما با موفقیت انجام شد";
    }
}
