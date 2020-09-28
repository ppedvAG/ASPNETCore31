using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _003_RazorPages_Basics.Pages.Sample001
{
    public class Calc1Model : PageModel
    {
        public int Ergebnis { get; set; }

        public void OnGet()
        {
            Ergebnis = 0;
        }
        //Um diese Get-Methode aufzurufen, muss folgende URL eingegeben werden -> calc?handler=Hannes
        public void OnGetHannes() 
        {
            Ergebnis = 42;
        }


        public void OnPost() // Wenn Submit Button geklickt wurde-> Wird der Post-Block ausgeführt
        {
            int eins = int.Parse(Request.Form["eins"].FirstOrDefault());
            int zwei = int.Parse(Request.Form["zwei"].FirstOrDefault());
            Ergebnis = eins + zwei;
        }



    }
}
