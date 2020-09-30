using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _003_RazorPages_Basics.Pages.Sample004
{
    [ResponseCache (VaryByHeader = "User-Agent" , Location = ResponseCacheLocation.Any, Duration = 30)]
    public class CachingSample2Model : PageModel
    {
        public void OnGet()
        {
        }
    }
}
