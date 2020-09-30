
using MVC_Basics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;

namespace MVC_Basics.ViewModels
{
    public class BlogCommentViewModel
    {
        public BlogCommentViewModel()
        {
            Blogs = new List<Blog>();
            Comments = new List<Comment>();
        }
        public IList<Blog> Blogs { get; set; }

        public IList<Comment> Comments { get; set; }
    }
}
