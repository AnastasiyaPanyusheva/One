using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Pan_lab6.Models;
using System.IO;
using System.Text;

namespace Pan_lab6.Controllers
{
    public class NotebookController : Controller
    {
        static List<Note> model;
        public string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", "myDB");
        public NotebookController()
        {
            if (System.IO.File.Exists(dbPath))
            {
                var text = System.IO.File.ReadAllText(dbPath);
                model = JsonConvert.DeserializeObject<List<Note>>(text);
            }
        }

        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Save([Bind] Note note)
        {
            if (note.Name == "") return Json("error");
            if (model == null) model = new List<Note>();
            for (int i = 0; i < model.Count; i++)
            {
                if (model[i].Name == note.Name)
                {
                    model[i].Text = note.Text;
                    System.IO.File.WriteAllText(dbPath, JsonConvert.SerializeObject(model));
                    return Json("success");
                }
            }
            model.Add(new Note(note.Name,note.Text));
            System.IO.File.WriteAllText(dbPath, JsonConvert.SerializeObject(model));
            return Json("success"); 
        }
        public JsonResult Load()
        {
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Image(string name)
        {
             return File(name.ToImage().ToStream(), "image/png");
        }
        public ActionResult Select(string name)
        {
            ViewBag.notebookName = name;
            return View("Index");
        }
        public ActionResult CreatePage()
        {
            ViewBag.notebookName = "";
            return View("Create");
        }
    }
}