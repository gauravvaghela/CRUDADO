using BAL.ShaligramModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyPractice.Controllers
{
    public class ShaliGramController : Controller
    {
        clsShaligram clsShaligram = null;
        // GET: ShaliGram
        
        public ActionResult Index()
        {
            clsShaligram = new clsShaligram();
            var result = clsShaligram.GetItem().ToList();
            ViewBag.Total = result.Sum(x => x.Total);
            ViewBag.IncludeGST = ((Convert.ToInt32(ViewBag.Total) * 18) / 100) + Convert.ToInt32(ViewBag.Total);
            return View(result);
        }

        public JsonResult GetUser()
        {
            clsShaligram = new clsShaligram();
            var UserList = clsShaligram.GetAllUser().ToList();
            return Json(UserList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetItem()
        {
            clsShaligram = new clsShaligram();
            var UserList = clsShaligram.GetAllItem().ToList();
            return Json(UserList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult PostItem(string ItemName)
        {
            clsShaligram = new clsShaligram();
            if (clsShaligram.AddItem(ItemName))
            {
                return Json("OK", JsonRequestBehavior.AllowGet);
            }
            return Json("Bad", JsonRequestBehavior.AllowGet);
        }

        public JsonResult ValidateCoupon(string txtCoupon, int TotalAmmount)
        {
            clsShaligram = new clsShaligram();
            if (clsShaligram.IsValidCoupon(txtCoupon, TotalAmmount))
            {
                return Json("OK", JsonRequestBehavior.AllowGet);
            }
            return Json("Bad", JsonRequestBehavior.AllowGet);
        }

        public JsonResult PlaceOrder(int UserId, int TotalAmmount, int WithGST, string Coupon)
        {
            clsShaligram = new clsShaligram();
            if (clsShaligram.PlaceOrder(UserId, TotalAmmount, WithGST, Coupon))
            {
                return Json("OK", JsonRequestBehavior.AllowGet);
            }
            return Json("Bad", JsonRequestBehavior.AllowGet);
        }
    }
}