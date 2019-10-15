using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BuyMovies.Business;
using BuyMovies.Database;

namespace BuyMovies.Pages.Comments
{
    //Get comment details.
    public class DetailsModel : PageModel
    {
        //Uses the database contex to connect to database.
        private readonly BuyMovies.Database.BuyMoviesContext _context;

        public DetailsModel(BuyMovies.Database.BuyMoviesContext context)
        {
            _context = context;
        }

        //Holds comment model.
        public Comment Comment { get; set; }

        //Gets a comment uses a lamda query to get comment with customer.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Comment =  _context.Comment
                .Include(c => c.Customer).FirstOrDefault(m => m.Id == id);

            if (Comment == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
