using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BuyMovies.Business;
using BuyMovies.Database;

namespace BuyMovies.Pages.MovieTransactions
{
    //Creates  a   transaction
    public class CreateModel : PageModel
    {
        //Uses the database contex to connect to database.
        private readonly BuyMovies.Database.BuyMoviesContext _context;

        public CreateModel(BuyMovies.Database.BuyMoviesContext context)
        {
            _context = context;
        }


        //Gets create transaction form.

        public IActionResult OnGet()
        {
        ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "CutomerExternalId");
        ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "MovieName");
            return Page();
        }

        //Holds movie transaction model.
        [BindProperty]
        public MovieTransaction MovieTransaction { get; set; }

        //Adds a transaction to database.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MovieTransaction.Add(MovieTransaction);
             _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}