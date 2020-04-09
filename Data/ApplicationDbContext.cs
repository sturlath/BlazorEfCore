using Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<MySettings> Settings { get; set; }
        public DbSet<PostalSystem> PostalSystem { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }


    }
}