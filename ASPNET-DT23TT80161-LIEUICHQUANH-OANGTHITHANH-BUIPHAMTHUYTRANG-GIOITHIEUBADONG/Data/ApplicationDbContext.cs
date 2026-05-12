using BaDongTourism.Models;
using Microsoft.EntityFrameworkCore;

namespace BaDongTourism.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Contact> Contacts { get; set; }
    }
}
