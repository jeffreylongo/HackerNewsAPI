using HackerNewsAPI.Services;
using System.Web.Mvc;

namespace HackerNewsAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //get the news
            var hotNews = StoryServices.GetStories();

            return View(hotNews);
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