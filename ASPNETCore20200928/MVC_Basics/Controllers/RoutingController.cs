using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Basics.Controllers
{
    public class RoutingController : Controller
    {

        [Route("Kevin")] //Attribute Routing
        [Route("Kevin/Index2")]
        public IActionResult Index()
        {
            return View();
        }


        [Route("Kevin/Details/{id:int}")] // Attribute-Routing mit Contraints -> Parameter die übergeben werden, sind typisiert
        public IActionResult Details(int id)
        {
            ViewBag.Id = id;
            return View();
        }
    }
}
