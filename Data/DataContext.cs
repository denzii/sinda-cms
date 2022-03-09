using Microsoft.EntityFrameworkCore;
using SindaCMS.Helpers;
using SindaCMS.Models;

namespace SindaCMS.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) { }

        public DbSet<Site> Sites { get; set; }

        public DbSet<Tab> Tabs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}
