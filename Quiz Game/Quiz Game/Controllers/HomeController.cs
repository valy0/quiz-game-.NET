using Quiz_Game.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quiz_Game.Controllers
{
    public class HomeController : Controller
    {
        private QuoteContext qc = new QuoteContext();
        private SettingsContext sc = new SettingsContext();
        private AnswersContext ac = new AnswersContext();

        // GET: /Home/
        public ActionResult Index()
        {
            // get game mode
            int gameMode = sc.QuizSettings.Where(s => s.Name == "GameMode").FirstOrDefault().Value;

            // get random quote based on game mode
            Quote q = qc.Quotes.Where(x => x.GameMode == gameMode).OrderBy(r => Guid.NewGuid()).FirstOrDefault();

            // create model that will be passed to the view
            QuizModel model = new QuizModel();

            // set the models variables from the random quote we picked
            model.QuoteText = q.QuoteText;
            if (gameMode == 0)
                model.Answers = ac.Answers.Where(x => x.QuoteID == q.QuoteID).OrderBy(r => Guid.NewGuid()).Take(1).ToList();
            else
                model.Answers = ac.Answers.Where(x => x.QuoteID == q.QuoteID).OrderBy(r => Guid.NewGuid()).Take(3).ToList();

            model.GameMode = gameMode;

            // pass the quiz model to the view
            return View(model);
        }

        // GET: /Home/CheckAnswer
        public ActionResult CheckAnswer(int quoteid = -1)
        {
            if (quoteid == -1)
                return View();
            else
            {
                AnswersContext ac = new AnswersContext();
                List<Answer> ret = ac.Answers.Where(x => x.QuoteID == quoteid && x.Correct).ToList();
                return Json(ret, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
