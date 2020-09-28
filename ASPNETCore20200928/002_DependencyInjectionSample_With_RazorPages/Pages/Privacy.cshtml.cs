using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _002_DependencyInjections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace _002_DependencyInjectionSample_With_RazorPages.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger, ICar car)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
