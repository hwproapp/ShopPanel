using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using newsSite90tv.Models.ExtraClass;
using newsSite90tv.Models.UnitOfWork;
using newsSite90tv.PublicClass;

namespace newsSite90tv.Areas.AdminPanel.Controllers
{

    [Area("AdminPanel")]
    public class checkoutrequestController : Controller
    {
        private readonly IUnitOfWork _context;

        public checkoutrequestController(IUnitOfWork context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> Getrequest(int t = 10)
        {
            ViewBag.viewtitle = "درخواست های تسویه حساب";
            var model =await _context.CheckoutRequestRepositoryUW.GetWithSkipAsync(a => a.status == 0, null, "Tbl_Shop,Tbl_Salsman,Tbl_sellerbank", 0, t);
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> GetPayaBankInfo(string id)
        {
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    List<PayaModel> payaModels = new List<PayaModel>();

                    var checkoutrequestid = Utility.ParseJson<List<long>>(id);

                    foreach (var itemid in checkoutrequestid)
                    {
                        PayaModel payaModel = new PayaModel();

                        var checkoutrequest = await _context.CheckoutRequestRepositoryUW.GetAsync(a=>a.Id == itemid , "Tbl_sellerbank");

                        payaModel.amount = checkoutrequest.requestprice;

                        payaModel.name = checkoutrequest.Tbl_sellerbank.owner;

                        payaModel.shabaNom = checkoutrequest.Tbl_sellerbank.shabNom;
                    
                        
                        payaModels.Add(payaModel);
                    }
                    

                   return await new ExcelUtil(_context).CreateExcel(payaModels);

                }
                else
                {
                    TempData["message"] = EndPointMessage.Fail_MSG;
                    TempData["type"] = EndPointMessage.Fail_TYPE;
                }
            }
            catch (Exception ex)
            {

                TempData["message"] = EndPointMessage.Fail_MSG + ex.Message;
                TempData["type"] = EndPointMessage.Fail_TYPE;
            }


            return RedirectToAction(nameof(Getrequest));
        }
    }
}