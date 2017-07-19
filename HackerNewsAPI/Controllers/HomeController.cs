using HackerNewsAPI.Models;
using HackerNewsAPI.Services;
using System.Web.Mvc;

namespace HackerNewsAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(NewsSearchModel searchModel)
        {
            //get the news
            var hotNews = StoryServices.GetStories(searchModel);

            return View(hotNews);
        }

        public ActionResult Search(NewsSearchModel searchModel)
        {
            var hotNews = StoryServices.GetStories(searchModel);
            return PartialView("_newsList", hotNews);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}