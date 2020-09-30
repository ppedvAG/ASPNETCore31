using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_Basics.Models;
using MVC_Basics.ViewModels;

namespace MVC_Basics.Controllers
{
    public class DynamicViewController : Controller //MVC leitet von der Klasse Controller ab
    {
        public IActionResult Index()
        {

            BlogCommentViewModel vm = new BlogCommentViewModel();
            vm.Blogs.Add(new Blog { Title = "Das letzte .NET Framework 4.8", CreateAt = DateTime.Now, Text = "Totgesagt leben länger!" });
            vm.Blogs.Add(new Blog { Title = ".NET Core", CreateAt = DateTime.Now, Text = "Auf zu neuen Ufern" });

            vm.Comments.Add(new Models.Comment { CreateAt = DateTime.Now, Message = "Super" });
            vm.Comments.Add(new Models.Comment { CreateAt = DateTime.Now, Message = "Toll" });
            vm.Comments.Add(new Models.Comment { CreateAt = DateTime.Now, Message = "Muss wieder lernen...hilfe!" });
            vm.Comments.Add(new Models.Comment { CreateAt = DateTime.Now, Message = "Ich muss weg :D" });


            dynamic myDynamicModel = new ExpandoObject();
            myDynamicModel.Blogs = vm.Blogs;
            myDynamicModel.Comments = vm.Comments;


            return View(myDynamicModel);
        }
    }
}
