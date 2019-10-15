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
    //Gets all  transactions.
    public class IndexModel : PageModel
    {
        //Uses the database contex to connect to database.
        private readonly BuyMovies.Database.BuyMoviesContext _context;

        public IndexModel(BuyMovies.Database.BuyMoviesContext context)
        {
            _context = context;
        }

        //Holds all transactions details.
        public IList<MovieTransaction> MovieTransaction { get;set; }

        //Gets all transactions using  a lamda query.
        public void OnGetAsync()
        {
            MovieTransaction =  _context.MovieTransaction
                .Include(m => m.Customer)
                .Include(m => m.Movie).ToList();
        }
    }
}
