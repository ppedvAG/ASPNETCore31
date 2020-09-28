using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _003_RazorPages_Basics.Pages.Sample003
{
    public class PartialViewSample2Model : PageModel
    {
        public string[] Tage { get; set; } = new string[7];

        public void OnGet()
        {
        }

        public PartialViewResult OnGetExcel()
        {
            for(int i = 0; i < 7; i++)
            {
                Tage[i] = Enum.GetName(typeof(DayOfWeek), i);
            }

            HttpContext.Response.ContentType = "application/vnd.ms-excel";

            return Partial("_Excel", this);
        }
    }
}
