using PagedList;
using ShoppingOnline.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingOnline.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new ProductBusiness();
            ViewBag.LstProduct = model.getAll();
            //ViewBag.lstPhuKienThoiTrang = model.getProductBy_PhuKienThoiTrang();
            //ViewBag.lstQuanAoNam = model.GetProductBy_QuanAoNam();
            //ViewBag.lstQuanApNu = model.GetProductBy_QuanAoNu();
            //ViewBag.lstValiBalo = model.GetProductBy_ValiBalo();
            ViewBag.lstProductRecommend_1 = model.getProductRecommend();
            ViewBag.lstProductRecommend_2 = model.getProductRecommend();

            ViewBag.lstCategory = model.GetCategories();
            ViewBag.lstProductAll = model.getAllProduct();
            return View();
        }

        public ActionResult GetProductByCategory(string Metatitle, long ID, string order = null, int page = 1, int pagesize = 6)
        {
            var model = new ProductBusiness().getProductByCategory(ID, page, pagesize, order);
            ViewBag.Category = new ProductBusiness().FindCategory(ID);
            ViewBag.lstCategory = new ProductBusiness().GetCategories();
            ViewBag.orderby = order; 
            return View(model);
        }

        //Load menu
        [ChildActionOnly]
        public PartialViewResult MainMenu()
        {
            ViewBag.lstCategory = new ProductBusiness().GetCategories();
            return PartialView();
        }

        [ChildActionOnly]
        public PartialViewResult Navigation()
        {
            ViewBag.lstCategory = new ProductBusiness().GetCategories();
            return PartialView();
        }
    }
}