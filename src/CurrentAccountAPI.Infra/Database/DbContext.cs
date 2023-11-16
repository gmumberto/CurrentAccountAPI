using CurrentAccountAPI.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace CurrentAccountAPI.Infra.Database
{
    public class DbContextClass : DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass> contextOptions) : base(contextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DbContextClass).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Customer> customer { get; set; }
        public DbSet<Transaction> transaction { get; set; }
    }
}

