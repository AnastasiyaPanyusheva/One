using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace _1lab.Controllers
{
    public class HomeController : Controller
    {
        string a = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", "data.txt");
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About(string t)
        {
            ViewBag.Message = "Запись в файл";
            var a = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data","data.txt");
            System.IO.File.AppendAllText(a, t + Environment.NewLine);
            
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Чтение из файла";
            ViewBag.myText = System.IO.File.ReadAllLines(a);
            return View();
        }
    }
}