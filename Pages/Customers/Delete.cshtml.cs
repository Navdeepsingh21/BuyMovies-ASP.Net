using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BuyMovies.Business;
using BuyMovies.Database;

namespace BuyMovies.Pages.Customers
{
    //Removes a customer.
    public class DeleteModel : PageModel
    {
        //Uses the database contex to connect to database.
        private readonly BuyMovies.Database.BuyMoviesContext _context;

        public DeleteModel(BuyMovies.Database.BuyMoviesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Customer Customer { get; set; }

        //Gets the delete form. uses a lamda query to get customer.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer =  _context.Customer.FirstOrDefault(m => m.Id == id);

            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }

        //Deletes the customer. uses a linq uery to check existance.
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = (from customer in _context.Customer 
                       where customer.Id == id select customer).FirstOrDefault();

            if (Customer != null)
            {
                _context.Customer.Remove(Customer);
                 _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
