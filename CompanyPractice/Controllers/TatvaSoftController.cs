using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyPractice.Controllers
{
    public class TatvaSoftController : Controller
    {
        // GET: TatvaSoft
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ThirdSundayOfEachMonth(DateTime startdate, DateTime enddate, string Days, int NumberofDays, int Monthsforskip)
        {
            List<DateTime> result = new List<DateTime>();
            int sundaymonthcount = 0;
            //int Count = 0;            
            DateTime currentMonth = new DateTime(startdate.Year, startdate.Month, startdate.Day);
            for (DateTime traverser = new DateTime(startdate.Year, startdate.Month, startdate.Day); traverser <= enddate; traverser = traverser.AddDays(1))
            {
                if (currentMonth.Month != traverser.Month)
                {
                    sundaymonthcount = 0;
                    currentMonth = traverser;
                }
                if (traverser.DayOfWeek.ToString() == Days)
                {
                    //Count++;
                    //if (Count == NumberofDays)
                    //{
                    sundaymonthcount++;
                    //}
                }
                if (sundaymonthcount == NumberofDays)
                {
                    result.Add(traverser);
                    sundaymonthcount = 0;
                    traverser = new DateTime(traverser.Year, traverser.Month, 1).AddMonths(Monthsforskip);
                }

            }
            List<string> V = new List<string>();
            foreach (var i in result)
            {
                V.Add(i.ToString("MMM dd, yyyy"));
            }
            //if (Session["test"] == null)
            //{
            //    Session["test"] = V;
            //}
            //else
            //{
            //    List<string> list = (List<string>)Session["test"];
            //    V.AddRange(list);
            //    Session["test"] = V;
            //}
            //return Json((List<string>)Session["test"], JsonRequestBehavior.AllowGet);
            return Json(V, JsonRequestBehavior.AllowGet);
        }
    }
}