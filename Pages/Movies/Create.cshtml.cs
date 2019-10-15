using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BuyMovies.Business;
using BuyMovies.Database;

namespace BuyMovies.Pages.Movies
{
    //Addes a movie.
    public class CreateModel : PageModel
    {
        //Uses the database contex to connect to database.
        private readonly BuyMovies.Database.BuyMoviesContext _context;

        public CreateModel(BuyMovies.Database.BuyMoviesContext context)
        {
            _context = context;
        }


        //Gets the create movies form.
        public IActionResult OnGet()
        {
            return Page();
        }

        //Holds the movies model.
        [BindProperty]
        public Movie Movie { get; set; }

        //Adds a movie to database.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Movie.Add(Movie);
             _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}