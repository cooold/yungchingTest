using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using yungchingTest.Models;
using yungchingTest.Data;
using yungchingTest.Server;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
        [HttpGet]
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
            List<Meal> result = _MealServer.QueryAll();
            return View(result);
        }
        [HttpPost]
        public IActionResult Update(Meal meal)
        {
            _MealServer.upgateMeal(meal);
            return RedirectToAction("Update");
        }


        public IActionResult Delete()
        {
            return View();
        }
    }
}