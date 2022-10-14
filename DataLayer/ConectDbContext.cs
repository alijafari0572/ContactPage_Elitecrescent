using Microsoft.EntityFrameworkCore;
using Entities;
namespace DataLayer
{
    public class ConectDbContext:DbContext
    {
        public ConectDbContext( DbContextOptions options)
        : base(options)
        {
            
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}