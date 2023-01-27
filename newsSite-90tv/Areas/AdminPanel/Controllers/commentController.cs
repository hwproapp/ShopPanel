using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using newsSite90tv.Models.UnitOfWork;
using newsSite90tv.PublicClass;

namespace newsSite90tv.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class commentController : Controller
    {
        private readonly IUnitOfWork _context;

        public commentController(IUnitOfWork context)
        {
            _context = context;
        }

        public  async Task<IActionResult> Index(int page=1)
        {
            ViewBag.viewtitle = "نظرات کاربران";


            int paresh = (page - 1) * 10;
            //تعداد کل ردیف ها
            int totalCount =await _context.commentRepositoryUW.GetCountAsync(a=>a.isEnable);

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


            var model =await  _context.commentRepositoryUW.GetWithSkipAsync(a => a.isEnable, a => a.OrderByDescending(b => b.status == 0) , "Tbl_UserApp", paresh,10);



            return View(model);
        }


      


        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await _context.commentRepositoryUW.GetAsync(a=>a.Id == id , "Tbl_UserApp,Tbl_Products");
            return View(model);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = _context.commentRepositoryUW.GetById(id);
            return View(model: model);
        }




        [ActionName("Delete")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfimed(int id)
        {

            try
            {


                var comment = await _context.commentRepositoryUW.GetByIdAsync(id);

                comment.isEnable = false;

                _context.commentRepositoryUW.Update(comment);
                await _context.saveAsync();





                TempData["message"] = EndPointMessage.DELETE_MSG;
                TempData["type"] = EndPointMessage.DELETE_TYPE;




            }
            catch (Exception)
            {


                TempData["message"] = EndPointMessage.Fail_MSG;
                TempData["type"] = EndPointMessage.Fail_TYPE;
            }

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> changeStatus(int id, byte state = 2)
        {
            try
            {
                var comment = await _context.commentRepositoryUW.GetByIdAsync(id);

                comment.status = state;

                _context.commentRepositoryUW.Update(comment);

                await _context.saveAsync();



                TempData["message"] = EndPointMessage.DONE_MSG;
                TempData["type"] = EndPointMessage.DONE_TYPE;

            }
            catch (Exception)
            {


                TempData["message"] = EndPointMessage.Fail_MSG;
                TempData["type"] = EndPointMessage.Fail_TYPE;
            }

            return RedirectToAction(nameof(Index));


        }






        // shop comment part 


     

        //public IActionResult shopcomment(int page = 1)
        //{


        //    ViewBag.viewtitle = "نظرات کاربران - فروشگاه";

        //    int paresh = (page - 1) * 10;
        //    //تعداد کل ردیف ها
        //    int totalCount = _context.shopCommentUW.Get(a => a.IsEnable).Count();
        //    ViewBag.PageID = page;
        //    double remain = totalCount % 10;

        //    if (remain == 0)
        //    {
        //        ViewBag.PageCount = totalCount / 10;
        //    }
        //    else
        //    {
        //        ViewBag.PageCount = (totalCount / 10) + 1;
        //    }


        //    var model = _context.shopCommentUW.Get(a => a.IsEnable, a => a.OrderByDescending(b => b.status == 0), "Tbl_UserApp,Tbl_Shop").Skip(paresh).Take(10);



        //    return View(model);
        //}


        //[HttpGet]
        //public async Task<IActionResult> DetailsShopcomment(int id)
        //{
        //    var model = await _context.shopCommentUW.GetByIdAsync(id);
        //    return View(model);
        //}
        


     
        //[HttpGet]
        //public IActionResult DeleteShopComment(int id)
        //{
        //    var model = _context.shopCommentUW.GetById(id);
        //    return View(model: model);
        //}




        //[ActionName("DeleteShopComment")]
        //[HttpPost, ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfimedShopComment(int id)
        //{

        //    try
        //    {


        //        var comment = await _context.shopCommentUW.GetByIdAsync(id);

        //        comment.IsEnable = false;

        //        _context.shopCommentUW.Update(comment);
        //        await _context.saveAsync();





        //        TempData["message"] = EndPointMessage.DELETE_MSG;
        //        TempData["type"] = EndPointMessage.DELETE_TYPE;




        //    }
        //    catch (Exception)
        //    {


        //        TempData["message"] = EndPointMessage.Fail_MSG;
        //        TempData["type"] = EndPointMessage.Fail_TYPE;
        //    }

        //    return RedirectToAction(nameof(shopcomment));
        //}




       


        //public async Task<IActionResult> changeStatusShop(int id, byte state = 2)
        //{
        //    var shopcomment = await _context
        //        .shopCommentUW.GetByIdAsync(id);
        //    shopcomment.status = state;
        //    _context.shopCommentUW.Update(shopcomment);

        //    await _context.saveAsync();

        //    return RedirectToAction(nameof(shopcomment));


        //}

       

    }
}