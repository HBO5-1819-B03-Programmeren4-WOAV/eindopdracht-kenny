using System.Collections.Generic;
using System.Threading.Tasks;
using B03.EE.BlanckeK.Lib.DTO;
using B03.EE.BlanckeK.Lib.Helpers;
using B03.EE.BlanckeK.Lib.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace B03.EE.BlanckeK.Web.Controllers
{
    public class QuizController : Controller
    {
        #region variables
        private readonly UserManager<IdentityUser> _userManager;
        private const string BaseUri = "https://localhost:44342/api/Quiz";
        #endregion

        #region Constructor
        public QuizController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        #endregion


        public IActionResult Index()
        {
            ViewBag.UserId = _userManager.GetUserId(HttpContext.User);
            string quizUri = $"{BaseUri}/basic";
            List<QuizBasic> quizBasic = ApiConverter.GetApiResult<List<QuizBasic>>(quizUri);
            return quizBasic == null ? View("Error") : View(quizBasic);
        }

        #region Play Button
        public IActionResult PlayQuiz(string id)
        {
            string quizDetailUri = $"{BaseUri}/{id}";
            Quiz quizDetail = ApiConverter.GetApiResult<Quiz>(quizDetailUri);
            return quizDetail == null ? View("Error") : View(quizDetail);
        }
        #endregion

        public IActionResult CreateQuiz()
        {
            ViewBag.UserId = _userManager.GetUserId(HttpContext.User);
            ViewBag.Mode = "Create";
            return View("EditQuiz", null);
        }

        public IActionResult EditQuiz(string id)
        {
            ViewBag.UserId = _userManager.GetUserId(HttpContext.User);
            ViewBag.Mode = "Edit";
            string quizDetailUri = $"{BaseUri}/{id}";
            Quiz quizDetail = ApiConverter.GetApiResult<Quiz>(quizDetailUri);
            return quizDetail == null ? View("Error") : View("EditQuiz",quizDetail);
        }

        public async Task<IActionResult> DeleteQuiz(string id)
        {
            await ApiConverter.DelCallApi<Quiz>($"{BaseUri}/{id}");
            return RedirectToAction("Index");
        }
    }
}