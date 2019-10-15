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
    //Gets all the customers.
    public class IndexModel : PageModel
    {
        //Uses the database contex to connect to database.
        private readonly BuyMovies.Database.BuyMoviesContext _context;

        public IndexModel(BuyMovies.Database.BuyMoviesContext context)
        {
            _context = context;
        }

        //Holds customer list model.
        public IList<Customer> Customer { get;set; }

        //Gets all customers using a linq query.
        public void OnGetAsync()
        {
            Customer = (from customer in _context.Customer select customer).ToList();
        }
    }
}
