using GroceryClassLibrary.Model;
using GroceryClassLibrary.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
//using GroceryClassLibrary;
namespace GroceryCalculator.Controllers
{
    public class GroceryCalculatorController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
       
}
}
