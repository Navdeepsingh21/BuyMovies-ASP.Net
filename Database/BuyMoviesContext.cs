using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BuyMovies.Business;

namespace BuyMovies.Database
{

    //Responsible for mapping business objects  and connecting to the database. 
    public class BuyMoviesContext : DbContext
    {
        public BuyMoviesContext (DbContextOptions<BuyMoviesContext> options)
            : base(options)
        {
        }

        public DbSet<BuyMovies.Business.Comment> Comment { get; set; }

        public DbSet<BuyMovies.Business.Customer> Customer { get; set; }

        public DbSet<BuyMovies.Business.Movie> Movie { get; set; }

        public DbSet<BuyMovies.Business.MovieTransaction> MovieTransaction { get; set; }
    }
}
