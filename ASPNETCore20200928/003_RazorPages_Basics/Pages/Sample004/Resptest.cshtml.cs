using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _003_RazorPages_Basics.Pages.Sample004
{
    public class ResptestModel : PageModel
    {
        public void OnGet()
        {
        }

        public void OnGetUmleitung()
        {
            Response.Redirect("SessionSample");
            
        }
    }
}
