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
    //Deletes a comment.
    public class DeleteModel : PageModel
    {
        //Uses the database contex to connect to database.
        private readonly BuyMovies.Database.BuyMoviesContext _context;

        public DeleteModel(BuyMovies.Database.BuyMoviesContext context)
        {
            _context = context;
        }


        //Holds a comment model.
        [BindProperty]
        public Comment Comment { get; set; }

        //Gets a delete form. uses a lamda query to get comment.
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

        //Removes the comment from database. uses a linq query to check existance.
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Comment =  (from comment in _context.Comment where comment.Id == id select comment).FirstOrDefault();

            if (Comment != null)
            {
                _context.Comment.Remove(Comment);
                 _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
