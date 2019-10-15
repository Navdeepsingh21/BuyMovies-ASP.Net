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
    //Gets all comments.
    public class IndexModel : PageModel
    {
        //Uses the database contex to connect to database.
        private readonly BuyMovies.Database.BuyMoviesContext _context;

        public IndexModel(BuyMovies.Database.BuyMoviesContext context)
        {
            _context = context;
        }

        //Holds a comment model.
        public IList<Comment> Comment { get;set; }

        //Gets commenst using a lamda query.
        public void OnGet()
        {
            Comment =  _context.Comment
                .Include(c => c.Customer).ToList();
        }
    }
}
