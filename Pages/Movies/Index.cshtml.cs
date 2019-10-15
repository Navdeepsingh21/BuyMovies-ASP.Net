using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BuyMovies.Business;
using BuyMovies.Database;

namespace BuyMovies.Pages.Movies
{
    //Gets all movies .
    public class IndexModel : PageModel
    {
        //Uses the database contex to connect to database.
        private readonly BuyMovies.Database.BuyMoviesContext _context;

        public IndexModel(BuyMovies.Database.BuyMoviesContext context)
        {
            _context = context;
        }

        //Holds movies model.
        public IList<Movie> Movie { get;set; }

        //Gets all movies. uses a linq query.
        public void OnGet()
        {
            Movie = (from movie in _context.Movie select movie).ToList();
        }
    }
}
