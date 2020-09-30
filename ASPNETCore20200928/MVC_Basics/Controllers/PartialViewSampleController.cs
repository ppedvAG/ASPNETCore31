using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_Basics.ViewModels;

namespace MVC_Basics.Controllers
{
    public class PartialViewSampleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RenderPartialSample()
        {
            return View();
        }

        public IActionResult ShowPartialViewWithViewModel()
        {
            BlogCommentViewModel vm = new BlogCommentViewModel();
            vm.Blogs.Add(new Blog { Title = "Das letzte .NET Framework 4.8", CreateAt = DateTime.Now, Text = "Totgesagt leben länger!" });
            vm.Blogs.Add(new Blog { Title = ".NET Core", CreateAt = DateTime.Now, Text = "Auf zu neuen Ufern" });

            vm.Comments.Add(new Models.Comment { CreateAt = DateTime.Now, Message = "Super" });
            vm.Comments.Add(new Models.Comment { CreateAt = DateTime.Now, Message = "Toll" });
            vm.Comments.Add(new Models.Comment { CreateAt = DateTime.Now, Message = "Muss wieder lernen...hilfe!" });
            vm.Comments.Add(new Models.Comment { CreateAt = DateTime.Now, Message = "Ich muss weg :D" });

            return View(vm);
        }

        public IActionResult LoadPartialOverGetMethod()
        {
            BlogCommentViewModel vm = new BlogCommentViewModel();
            vm.Blogs.Add(new Blog { Title = "Das letzte .NET Framework 4.8", CreateAt = DateTime.Now, Text = "Totgesagt leben länger!" });
            vm.Blogs.Add(new Blog { Title = ".NET Core", CreateAt = DateTime.Now, Text = "Auf zu neuen Ufern" });

            vm.Comments.Add(new Models.Comment { CreateAt = DateTime.Now, Message = "Super" });
            vm.Comments.Add(new Models.Comment { CreateAt = DateTime.Now, Message = "Toll" });
            vm.Comments.Add(new Models.Comment { CreateAt = DateTime.Now, Message = "Muss wieder lernen...hilfe!" });
            vm.Comments.Add(new Models.Comment { CreateAt = DateTime.Now, Message = "Ich muss weg :D" });

            return View(vm);
        }

        public IActionResult OnGetMyPartial() =>
            new PartialViewResult
            {
                ViewName = "_Zeit",
                ViewData = ViewData //Erklärung kommt gleich
            };
    }
}
