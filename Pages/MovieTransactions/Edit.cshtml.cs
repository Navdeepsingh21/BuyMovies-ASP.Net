using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BuyMovies.Business;
using BuyMovies.Database;

namespace BuyMovies.Pages.MovieTransactions
{
    //Updates a transaction.
    public class EditModel : PageModel
    {
        //Uses the database contex to connect to database.
        private readonly BuyMovies.Database.BuyMoviesContext _context;

        public EditModel(BuyMovies.Database.BuyMoviesContext context)
        {
            _context = context;
        }

        //Holds movie transaction.
        [BindProperty]
        public MovieTransaction MovieTransaction { get; set; }


        //Gets  details uses  a lamda query to get transaction.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MovieTransaction =  _context.MovieTransaction
                .Include(m => m.Customer)
                .Include(m => m.Movie).FirstOrDefault(m => m.Id == id);

            if (MovieTransaction == null)
            {
                return NotFound();
            }
           ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "CustomerName");
           ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "MovieName");
            return Page();
        }

        //Updates the transaction.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MovieTransaction).State = EntityState.Modified;

            try
            {
                 _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieTransactionExists(MovieTransaction.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        //Uses a lamda to check  existance.
        private bool MovieTransactionExists(int id)
        {
            return _context.MovieTransaction.Any(e => e.Id == id);
        }
    }
}
