using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class ApplicationContext : DbContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Address> Addresses { get; set; }

    }
}
