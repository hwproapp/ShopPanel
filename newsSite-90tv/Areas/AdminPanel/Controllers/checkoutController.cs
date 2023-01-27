using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using newsSite90tv.Models;
using newsSite90tv.Models.UnitOfWork;
using newsSite90tv.PublicClass;

namespace newsSite90tv.Areas.AdminPanel.Controllers
{

    [Area("AdminPanel")]
    public class checkoutController : Controller
    {
        private readonly IUnitOfWork _context;

        public checkoutController(IUnitOfWork context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            ViewBag.viewtitle = "واریز های من";


            int paresh = (page - 1) * 10;
            //تعداد کل ردیف ها
            int totalCount = await _context.CheckoutRepositoryUW.GetCountAsync();
            ViewBag.PageID = page;
            double remain = totalCount % 10;

            if (remain == 0)
            {
                ViewBag.PageCount = totalCount / 10;
            }
            else
            {
                ViewBag.PageCount = (totalCount / 10) + 1;
            }


            var model = await _context.CheckoutRepositoryUW.GetWithSkipAsync(null, null, "Tbl_Shop,Tbl_Salsman,Tbl_sellerBank", paresh, 10);



            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> Newcheckout(string id)
        {
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    var checkoutreqid = Utility.ParseJson<List<long>>(id);

                    foreach (var itemid in checkoutreqid)
                    {
                        var checkoutrequest = await _context.CheckoutRequestRepositoryUW.GetAsync(a => a.Id == itemid, "Tbl_sellerbank");

                        checkoutrequest.status = 1;

                        _context.CheckoutRequestRepositoryUW.Update(checkoutrequest);

                        //update shop's sell removable price
                        var sell = await _context.sellRepositoryUW.GetAsync(a => a.seller_id == checkoutrequest.seller_id && a.shop_id == checkoutrequest.shop_id && a.sellstatus == 2);
                        if (sell != null)
                        {
                            sell.removableprice -= checkoutrequest.requestprice;
                            _context.sellRepositoryUW.Update(sell);

                        }else
                        {
                            TempData["message"] = "فروش فروشنده یافت نشد برای اعمال قیمت جدید";
                            TempData["type"]    = EndPointMessage.Fail_TYPE;

                            return RedirectToAction("Getrequest", "checkoutrequest");
                        }

                        //new checkout

                        Checkout checkout = new Checkout
                        {
                            bank_id = checkoutrequest.bank_id,
                            checkoutprice = checkoutrequest.requestprice,
                            datemiladi = DateTime.Now,
                            dateshamsi = DateAndTimeShamsi.DateTimeShamsi(),
                            seller_id = checkoutrequest.seller_id,
                            shop_id = checkoutrequest.shop_id
                        };

                        _context.CheckoutRepositoryUW.Create(checkout);
                     

                        //tell the seller  for checkout state
                        UserAlarm newalarm = new UserAlarm()
                        {
                            appuser_id = _context.salsmanRepositoryUW.GetById(checkoutrequest.seller_id).appuser_id,
                            title = "درخواست تسویه حساب فروش",
                            body = ".واریز شد" + checkoutrequest.Tbl_sellerbank.owner  +  "تومان به حساب " + checkoutrequest.requestprice.RialToToman().ToPrice() + "درخواست تسویه شما با موفقیت انجام شد. و مبلغ",
                            isenable = true,
                            status = 0,

                        };



                        _context.useralarmRepositoryUW.Create(newalarm);
                        await _context.saveAsync();

                    }


                    TempData["message"] = EndPointMessage.SUCCESS_MSG;
                    TempData["type"] = EndPointMessage.SUCCESS_TYPE;
                }
                else
                {
                    TempData["message"] = EndPointMessage.Fail_MSG;
                    TempData["type"] = EndPointMessage.Fail_TYPE;
                }
            }
            catch (Exception ex)
            {

                TempData["message"] = EndPointMessage.Fail_MSG;
                TempData["type"]    = EndPointMessage.Fail_TYPE;
            }

            return RedirectToAction("Getrequest", "checkoutrequest");

        }
    }
}