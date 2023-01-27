using newsSite90tv.Models.Services;
using newsSite90tv.Models.UnitOfWork;
using newsSite90tv.PublicClass;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.Repository
{
    public class searchResult : IsearchResult
    {
        private readonly IUnitOfWork _context;
        public searchResult(IUnitOfWork context)
        {
            _context = context;
        }



        //search result for products
        public Hashtable SearchResProd(byte order, string key, int page, byte take)
        {
            IEnumerable<Product> model = null;

            Hashtable s = new Hashtable();




            int paresh = (page - 1) * take;
            int total = 0;

            switch (order)
            {

                case 0:
                    {

                        total = _context.productRepositoryUW.Get(a => a.Tbl_Shop.title == key.Trim()).Count();
                        model = _context.productRepositoryUW.Get(a => a.Tbl_Shop.title == key.Trim()).Skip(paresh).Take(take);
                    }

                    break;

                case 1:
                    {

                        total = _context.productRepositoryUW.Get(a => a.Tbl_Salsman.Tbl_Userapp.firstName.Contains(key.Trim())).Count();
                        model = _context.productRepositoryUW.Get(a => a.Tbl_Salsman.Tbl_Userapp.lastName.Contains(key.Trim())).Skip(paresh).Take(take);
                    }
                    break;


                case 2:
                    {

                        total = _context.productRepositoryUW.Get(a => a.Tbl_Category.Title.Contains(key.Trim())).Count();
                        model = _context.productRepositoryUW.Get(a => a.Tbl_Category.Title.Contains(key.Trim())).Skip(paresh).Take(take);

                    }
                    break;


                case 3:
                    {
                        total = _context.productRepositoryUW.Get(a => a.title.Contains(key.Trim())).Count();
                        model = _context.productRepositoryUW.Get(a => a.title.Contains(key.Trim())).Skip(paresh).Take(take);
                    }
                    break;

            }




            s.Add("prod", model);
            s.Add("count", total);


            return s;
        }

        //search result for shops
        public Hashtable SearchResShop(byte order, string key, int page, byte take)
        {
            IEnumerable<Shop> model = null;

            Hashtable s = new Hashtable();






            int paresh = (page - 1) * take;
            int total = 0;

            switch (order)
            {

                case 0:
                    {

                        total = _context.shopRepositoryUW.Get(a => a.title == key.Trim()).Count();
                        model = _context.shopRepositoryUW.Get(a => a.title == key.Trim()).Skip(paresh).Take(take);
                    }

                    break;

                case 1:
                    {

                        total = _context.shopRepositoryUW.Get(a => a.salsman.Tbl_Userapp.firstName.Contains(key.Trim())).Count();
                        model = _context.shopRepositoryUW.Get(a => a.salsman.Tbl_Userapp.lastName.Contains(key.Trim())).Skip(paresh).Take(take);
                    }
                    break;


                case 2:
                    {

                        var data = key.Trim().Split(',');

                        int ostan = data[0].ToInt();
                        int city = data[1].ToInt();


                        total = _context.shopRepositoryUW.Get(a => a.ostan_id == ostan && a.city_id == city).Count();
                        model = _context.shopRepositoryUW.Get(a => a.ostan_id == ostan && a.city_id == city).Skip(paresh).Take(take);


                    }
                    break;



            }




            s.Add("shops", model);
            s.Add("count", total);


            return s;
        }

        //search result for sellers
        public Hashtable SearchResSeller(byte order, string key, int page, byte take)
        {
            IEnumerable<Salsman> model = null;

            Hashtable s = new Hashtable();


            int paresh = (page - 1) * take;
            int total = 0;

            switch (order)
            {

                case 0:
                    {
                        var temp = key.Trim().Split(' ');

                        total = _context.salsmanRepositoryUW.Get(a => a.Tbl_Userapp.firstName.Contains(temp[0]) && a.Tbl_Userapp.lastName.Contains(temp[1])).Count();
                        model = _context.salsmanRepositoryUW.Get(a => a.Tbl_Userapp.firstName.Contains(temp[0]) && a.Tbl_Userapp.lastName.Contains(temp[1])).Skip(paresh).Take(take);
                    }

                    break;

                case 1:
                    {

                        total = _context.salsmanRepositoryUW.Get(a => a.Tbl_Userapp.phone.Contains(key.Trim())).Count();
                        model = _context.salsmanRepositoryUW.Get(a => a.Tbl_Userapp.phone.Contains(key.Trim())).Skip(paresh).Take(take);
                    }
                    break;


                default:
                    model = null;
                    break;

            }




            s.Add("sellers", model);
            s.Add("count", total);


            return s;
        }


        //search result for userapp
        public Hashtable SearchResuserApp(byte order, string key, int page, byte take)
        {
            IEnumerable<UserApp> model = null;

            Hashtable s = new Hashtable();


            int paresh = (page - 1) * take;
            int total = 0;

            switch (order)
            {

                case 0:
                    {
                        var temp = key.Trim().Split(' ');

                        total = _context.userappRepositoryUW.Get(a => a.firstName.Contains(temp[0]) && a.lastName.Contains(temp[1])).Count();
                        model = _context.userappRepositoryUW.Get(a => a.firstName.Contains(temp[0]) && a.lastName.Contains(temp[1])).Skip(paresh).Take(take);
                    }

                    break;

                case 1:
                    {

                        total = _context.userappRepositoryUW.Get(a => a.phone.Contains(key.Trim())).Count();
                        model = _context.userappRepositoryUW.Get(a => a.phone.Contains(key.Trim())).Skip(paresh).Take(take);
                    }
                    break;


                default:
                    model = null;
                    break;

            }




            s.Add("userapp", model);
            s.Add("count", total);


            return s;
        }


        

       

        //search result for adv 
        public Hashtable SearchResadv(string key, int page, byte take)
        {
            IEnumerable<shopadvertise> model = null;

            Hashtable s = new Hashtable();


            int paresh = (page - 1) * take;
           

            int total = _context.AdvertisRepositoryUW.Get(a => a.Shop.title.Contains(key) , null , "shop,Salsman").Count();
            model = _context.AdvertisRepositoryUW.Get(a => a.Shop.title.Contains(key) , null, "shop,Salman").Skip(paresh).Take(take);


            s.Add("adv", model);
            s.Add("count", total);


            return s;
        }




        #region Dispose
        protected bool isDisposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                _context.Dispose();
            }

            isDisposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}
