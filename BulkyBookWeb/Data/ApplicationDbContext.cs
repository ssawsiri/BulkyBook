    using BulkyBookWeb.Models;
    using Microsoft.EntityFrameworkCore;

    namespace BulkyBookWeb.Data
    {
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options) 
            {
            
            }

            public DbSet<Catagory> Catagories { get; set; } // creating the table from the Catagory Model this code first
        }
    }
