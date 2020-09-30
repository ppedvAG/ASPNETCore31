using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _003_RazorPages_Basics.Pages.Sample004
{
    public class CookieTestModel : PageModel
    {
        public void OnGet()
        {
            var options = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(30),
                HttpOnly = false,
                IsEssential = true
            };

            Response.Cookies.Append("Kevin", "Wert", options);
            var o = Request.Cookies["Kevin"];

        }
    }
}
