using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BuyMovies.Business;
using BuyMovies.Database;

namespace BuyMovies.Pages.Comments
{
    //Creates a comment.
    public class CreateModel : PageModel
    {
        //Uses the database contex to connect to database.
        private readonly BuyMovies.Database.BuyMoviesContext _context;

        public CreateModel(BuyMovies.Database.BuyMoviesContext context)
        {
            _context = context;
        }

        //Gets the create commnet form
        public IActionResult OnGet()
        {
        ViewData["CustomerId"] = new SelectList(_context.Set<Customer>(), "Id", "CustomerName");
            return Page();
        }

        [BindProperty]
        public Comment Comment { get; set; }

        //Adds a comment to the databse.
        public  IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Comment.Add(Comment);
             _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}