using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BuyMovies.Business;
using BuyMovies.Database;

namespace BuyMovies.Pages.Customers
{
    //Creates a customer.
    public class CreateModel : PageModel
    {
        //Uses the database contex to connect to database.
        private readonly BuyMovies.Database.BuyMoviesContext _context;

        public CreateModel(BuyMovies.Database.BuyMoviesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        //Holds a customer model.
        [BindProperty]
        public Customer Customer { get; set; }

        //Adds a customer to database.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Customer.Add(Customer);
             _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}