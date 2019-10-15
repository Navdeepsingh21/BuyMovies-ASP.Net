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
    //Removes a movie.
    public class DeleteModel : PageModel
    {
        //Uses the database contex to connect to database.
        private readonly BuyMovies.Database.BuyMoviesContext _context;

        public DeleteModel(BuyMovies.Database.BuyMoviesContext context)
        {
            _context = context;
        }

        //Holds movie model.
        [BindProperty]
        public Movie Movie { get; set; }

        //Gets the delete form .uses lamda query.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie =  _context.Movie.FirstOrDefault(m => m.Id == id);

            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }

        //Delete movie from database. uses linq query to check existance.
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie =(from movie  in _context.Movie
                   where movie.Id == id select movie).FirstOrDefault();

            if (Movie != null)
            {
                _context.Movie.Remove(Movie);
                _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
