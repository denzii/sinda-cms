using Microsoft.EntityFrameworkCore;
using SindaCMS.Helpers;
using SindaCMS.Models;

namespace SindaCMS.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) { }

        public DbSet<Page> Pages { get; set; }
        public DbSet<Site> Sites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}
