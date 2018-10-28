using BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyPractice.Controllers
{
    public class HomeController : Controller
    {
        clsCategory Cat = null;
        public ActionResult Category()
        {            
            try
            {                
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {}            
            return View();
        }

        public JsonResult ListCategory()
        {
            Cat = new clsCategory();            
            var list = new SelectList(Cat.ListCatagory(),"cid", "Category");
            return Json(new {data= list }, JsonRequestBehavior.AllowGet);
        }
    }
}