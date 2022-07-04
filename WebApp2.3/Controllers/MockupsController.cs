using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp2._3.Models;

namespace WebApp2._3.Controllers
{
    public class MockupsController : Controller
    {
        private readonly ILogger<MockupsController> _logger;

        public MockupsController(ILogger<MockupsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Mockups()
        {
            return View();
        }

        static readonly QuizViewModel quiz = new QuizViewModel();

        public IActionResult Quiz()
        {
            quiz.SetRandomValues();
            ViewBag.Question = quiz.question;
            return View();
        }

        [ActionName("Result")]
        public IActionResult QuizResult()
        {
            ViewBag.RightAnswersCount = quiz.rightAnswersCount;
            ViewBag.AnswersCount = quiz.answersCount;
            ViewBag.Results = quiz.Results;
            return View();
        }

        [HttpPost]
        [ActionName("Quiz")]
        public IActionResult QuizNext(int answer)
        {
            quiz.UppdateResults(answer);
            quiz.SetRandomValues();
            ViewBag.Question = quiz.question;
            return View("Quiz");
        }

        public IActionResult QuizFinish(int answer)
        {
            quiz.UppdateResults(answer);
            ViewBag.RightAnswersCount = quiz.rightAnswersCount;
            ViewBag.AnswersCount = quiz.answersCount;
            ViewBag.Results = quiz.Results;
            return View("Result");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}