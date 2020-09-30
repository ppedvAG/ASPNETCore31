using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Movie
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;

        public CreateModel(RazorPagesMovie.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty] //Hält die Daten im Context
        public RazorPagesMovie.Models.Movie Movie { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            // Logische Prüfungen auf den Inhalt des Datensatzen z.b BlackListe
            if (Movie.Title == "Kevin allein zu hause")
                ModelState.AddModelError(string.Empty, "Warum gerade dieser Film :-) .");

            // Ob alles korrekt ist (DataAnno
            if (!ModelState.IsValid) // Prüft ob das Formular valide ausgefüllt wurde -> Zum Einsatz kommt im Hintergrund diejQuery.Validation Library
            {
                // Bei einem Fehler, wird die Seite mit den Vorhandenen Eintragungen + Fehlermeldungen angezeigt
                return Page();
            }

            _context.Movie.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index"); //Verlinkung via Code
        }
    }
}
