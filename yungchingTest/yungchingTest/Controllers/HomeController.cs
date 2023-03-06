using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using yungchingTest.Models;
using yungchingTest.Data;
using yungchingTest.Server;

namespace yungchingTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly MealServer _MealServer;

        public HomeController(MealServer MealServer)
        {
            _MealServer = MealServer;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Query()
        {
            return View();
        }
        public IActionResult SerchResult(string key)
        {
            
            List<Meal> result = _MealServer.QueryByKey(key);
            return View(result);
        }


        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Update()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}