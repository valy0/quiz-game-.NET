using Quiz_Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quiz_Game.Controllers
{
    public class SettingsController : Controller
    {
        private SettingsContext sc = new SettingsContext();

        // GET: /Settings/
        public ActionResult Index()
        {
            return View();
        }

        // POST: /Settings/
        [HttpPost]
        public ActionResult Index(SettingsModel model)
        {
            if (ModelState.IsValid)
            {
                Settings s = sc.QuizSettings.Find(sc.QuizSettings.Where(x => x.Name == "GameMode").FirstOrDefault().SettingsID);
                if (s != null)
                {
                    s.Value = model.Value;
                    sc.SaveChanges();
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
