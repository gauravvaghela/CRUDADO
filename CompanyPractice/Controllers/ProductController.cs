using BAL;
using BAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyPractice.Controllers
{
    public class ProductController : Controller
    {
        clsProduct Prod = null;
        clsCategory Cat = null;

        [HttpGet]
        public ActionResult ProductList(string search,string sorting_order)
        {
            Prod = new clsProduct();
            var result = Prod.ProductList().ToList();
            ViewBag.SortingProductName = string.IsNullOrWhiteSpace(sorting_order) ? "ProductName_Desc" : "";            
            ViewBag.SortingPrice = sorting_order == "Price" ? "Price_Desc" : "Price";
            ViewBag.SortingModel = sorting_order == "Model" ? "Model_Desc" : "Model";
            if (search != null && search != "")
            {
                result = result.Where(c => c.ProductName.ToUpper().Contains(search.ToUpper()) || c.Price.ToString().Contains(search.ToUpper())
                                        || c.Model.ToUpper().Contains(search.ToUpper())).ToList();
            }

            switch (sorting_order)
            {
                case "ProductName_Desc":
                    result = result.OrderByDescending(x => x.ProductName).ToList();
                    break;
                case "Price":
                    result = result.OrderBy(x => x.Price).ToList();
                    break;
                case "Price_Desc":
                    result = result.OrderByDescending(x => x.Price).ToList();
                    break;
                case "Model":
                    result = result.OrderBy(x => x.Price).ToList();
                    break;
                case "Model_Desc":
                    result = result.OrderByDescending(x => x.Price).ToList();
                    break;
                default:
                    result = result.OrderBy(x => x.ProductName).ToList();
                    break;
            }
            return View(result);
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            Cat = new clsCategory();            
            ViewBag.Category = Cat.ListCatagory().Select(i => new SelectListItem() { Text = i.CategoryName, Value = i.cid.ToString() }).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(MainProduct objMP)
        {             
            Prod = new clsProduct();
            try
            {
                if (ModelState.IsValid)
                {
                    if (Prod.AddProduct(objMP.Pid, objMP.ProductName, objMP.Price, objMP.Model, objMP.Color, objMP.Cid))
                    {
                        return RedirectToAction("ProductList", "Product");
                    }
                }                                
            }
            catch (Exception)
            {

                throw;
            }            
            return View();
        } 
               
        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            Prod = new clsProduct();
            Cat = new clsCategory();
            ViewBag.Category = Cat.ListCatagory().Select(i => new SelectListItem() { Text = i.CategoryName, Value = i.cid.ToString()}).ToList();
            return View(Prod.ProductList().Find(x => x.Pid == id));
        }       

        [HttpPost]
        public ActionResult UpdateProduct(MainProduct objMP)
        {
            Prod = new clsProduct();
            try
            {
                if (ModelState.IsValid)
                {
                    if (Prod.AddProduct(objMP.Pid, objMP.ProductName, objMP.Price, objMP.Model, objMP.Color, objMP.Cid))
                    {
                        return RedirectToAction("ProductList", "Product");
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }                        
            return View();
        }

        public ActionResult Delete(int id)
        {
            Prod = new clsProduct();
            if (Prod.DeleteProduct(id))
            {
                return RedirectToAction("ProductList", "Product");
            }
            return View();
        }
    }
}