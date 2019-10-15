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

namespace BuyMovies.Pages.Comments
{
    //Edits a comment.
    public class EditModel : PageModel
    {
        //Uses the database contex to connect to database.
        private readonly BuyMovies.Database.BuyMoviesContext _context;

        public EditModel(BuyMovies.Database.BuyMoviesContext context)
        {
            _context = context;
        }

        //Holds comment model.
        [BindProperty]
        public Comment Comment { get; set; }

        //Gets the comment form .uses a lamda query.
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
           ViewData["CustomerId"] = new SelectList(_context.Set<Customer>(), "Id", "CustomerName");
            return Page();
        }

         //Updates the comment.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Comment).State = EntityState.Modified;

            try
            {
                 _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentExists(Comment.Id))
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

        //Check existance uses a lamda.
        private bool CommentExists(int id)
        {
            return _context.Comment.Any(e => e.Id == id);
        }
    }
}
