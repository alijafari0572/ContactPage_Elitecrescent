using Microsoft.EntityFrameworkCore;
using Entities;
namespace DataLayer
{
    public class ContactDbContext:DbContext
    {
        public ContactDbContext( DbContextOptions options)
        : base(options)
        {
            
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}