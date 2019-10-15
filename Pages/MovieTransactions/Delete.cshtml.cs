using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BuyMovies.Business;
using BuyMovies.Database;

namespace BuyMovies.Pages.MovieTransactions
{
    //Removes a transaction
    public class DeleteModel : PageModel
    {
        //Uses the database contex to connect to database.
        private readonly BuyMovies.Database.BuyMoviesContext _context;

        public DeleteModel(BuyMovies.Database.BuyMoviesContext context)
        {
            _context = context;
        }

        //Holds a movie transaction.
        [BindProperty]
        public MovieTransaction MovieTransaction { get; set; }

        //Gets delete form uses a lamda query to get details.
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
            return Page();
        }

        //Deletes the transaction from databse. uses a linq query to fetch  transaction.
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MovieTransaction = (from movieTransaction in _context.MovieTransaction
                               where movieTransaction.Id == id select movieTransaction).FirstOrDefault();

            if (MovieTransaction != null)
            {
                _context.MovieTransaction.Remove(MovieTransaction);
                 _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
