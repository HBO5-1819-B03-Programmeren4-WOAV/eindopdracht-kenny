using System.Collections.Generic;
using B03.EE.BlanckeK.Lib.DTO;
using B03.EE.BlanckeK.Lib.Helpers;
using B03.EE.BlanckeK.Lib.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace B03.EE.BlanckeK.Web.Controllers
{
    public class QuizController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private const string BaseUri = "https://localhost:44342/api/Quiz";

        public QuizController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            ViewBag.UserId = _userManager.GetUserId(HttpContext.User);
            string quizUri = $"{BaseUri}/basic";
            return View(ApiConverter.GetApiResult<List<QuizBasic>>(quizUri));
        }

        public IActionResult PlayQuiz(string id)
        {
            string quizDetailUri = $"{BaseUri}/{id}";
            var quizDetail = ApiConverter.GetApiResult<Quiz>(quizDetailUri);
            return View(quizDetail);
        }
    }
}