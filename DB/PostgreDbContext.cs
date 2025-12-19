using cookies_authentication.DB.Tables;
using Microsoft.EntityFrameworkCore;

namespace cookies_authentication.DB
{
    public class PostgreDbContext : DbContext
    {
        public DbSet<UsersTable>? Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql($"Server=localhost;Port=5432;User Id={Environment.GetEnvironmentVariable("DB_USER")};Password={Environment.GetEnvironmentVariable("DB_PASSWORD")};Database={Environment.GetEnvironmentVariable("DB_NAME")};");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UsersTable>().ToTable("users");
        }
    }
}
