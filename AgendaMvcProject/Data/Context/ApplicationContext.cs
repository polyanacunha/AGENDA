using AgendaMvcProject.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaMvcProject.Data.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
        }
    

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
<<<<<<< HEAD:AgendaMvcProject/Data/Context/ApplicationContext.cs
        public DbSet<Contact> Contacts { get; set; }
=======
        public DbSet<Address> Addresses { get; set; }
>>>>>>> origin/Andress:AgendaMvcProject/Application/ApplicationContext.cs

        // With this approach, you no longer need to hard-code the connection string in the OnConfiguring method, 
        //and you can easily switch between different database providers and connection strings just by modifying the appsettings.json file.
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //     => optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=postgres;Username=postgres;Password=changeme");
    }
}
