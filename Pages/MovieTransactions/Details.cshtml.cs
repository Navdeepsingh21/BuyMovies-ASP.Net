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
    //Gets  transaction details.
    public class DetailsModel : PageModel
    {
        //Uses the database contex to connect to database.
        private readonly BuyMovies.Database.BuyMoviesContext _context;

        public DetailsModel(BuyMovies.Database.BuyMoviesContext context)
        {
            _context = context;
        }

        //Holds transaction model 
        public MovieTransaction MovieTransaction { get; set; }

        //Gets details uses a lamda query to get transaction details.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MovieTransaction = _context.MovieTransaction
                .Include(m => m.Customer)
                .Include(m => m.Movie).FirstOrDefault(m => m.Id == id);

            if (MovieTransaction == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
