using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_Basics.Models;

namespace MVC_Basics.Controllers
{
    public class StateManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult ViewDataSample()
        {
            ViewData["CoronaID"] = 123;
            ViewData["IrgendEinEintrag"] = "Das Wetter ist schön";

            return View();
        }
        public IActionResult ViewBagSample()
        {
            ViewBag.UserId = 101;
            ViewBag.Name = "John";
            ViewBag.Age = 31;


            return View();
        }


        public IActionResult TempDataFirst()
        {
            TempData["UserId"] = 777;
            TempData.Keep();
            return View();
        }

        public IActionResult TempDataSecond()
        {
            var userId = TempData["UserId"] ?? null;
            TempData.Keep();
            return View();
        }

        public IActionResult TempDataThird()
        {
            var userId = TempData["UserId"] ?? null;
            //TempData.Keep();
            return View();
        }
        public IActionResult TempDataFour()
        {
            var userId = TempData["UserId"] ?? null;
            //TempData.Keep();
            return View();
        }

        public IActionResult SessionInit()
        {
            //Beispiel1 - Initialisieren mit einfachen Variablen
            HttpContext.Session.SetString("Name", "Andre");
            HttpContext.Session.SetInt32("Age", 33);


            Movie myMovie = new Movie()
            {
                ID = 123,
                Title = "Pippi Langstrumpf",
                Genre = "Trickfilm",
                ReleaseDate = DateTime.Now,
                Price = 10
            };

            string jsonString = JsonSerializer.Serialize(myMovie);

            HttpContext.Session.SetString("MovieObj", jsonString);

            return View();
        }
    }
}
