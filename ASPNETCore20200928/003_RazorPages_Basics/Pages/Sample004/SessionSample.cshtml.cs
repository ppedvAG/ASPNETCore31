using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _003_RazorPages_Basics.Pages.Sample004
{
    public class SessionSampleModel : PageModel
    {
        public void OnGet()
        {
            HttpContext.Session.SetString("Chef", "Hannes Preishuber");

        }
    }
}
