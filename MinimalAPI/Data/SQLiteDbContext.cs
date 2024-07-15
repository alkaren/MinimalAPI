using Microsoft.EntityFrameworkCore;
using MinimalAPI.Entities;

namespace MinimalAPI.Data
{
    public class SQLiteDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("Data Source=myapp.db");

        public DbSet<RuleCarProduction> RuleCarProductions => Set<RuleCarProduction>();
        public DbSet<TransactionCarProduction> TransactionCarProductions => Set<TransactionCarProduction>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RuleCarProduction>().HasData(
                new RuleCarProduction { Id = 1, DayName = "Senin", SequenceDay = 1, Priority = 2, TotalProduction = 4 },
                new RuleCarProduction { Id = 2, DayName = "Selasa", SequenceDay = 2, Priority = 1, TotalProduction = 5 },
                new RuleCarProduction { Id = 3, DayName = "Rabu", SequenceDay = 3, Priority = 2, TotalProduction = 1 },
                new RuleCarProduction { Id = 4, DayName = "Kamis", SequenceDay = 4, Priority = 1, TotalProduction = 7 },
                new RuleCarProduction { Id = 5, DayName = "Jumat", SequenceDay = 5, Priority = 1, TotalProduction = 6 },
                new RuleCarProduction { Id = 6, DayName = "Sabtu", SequenceDay = 6, Priority = 2, TotalProduction = 4 },
                new RuleCarProduction { Id = 7, DayName = "Minggu", SequenceDay = 7, Priority = 0, TotalProduction = 0 }
            );

            modelBuilder.Entity<TransactionCarProduction>().Property(e => e.Id).ValueGeneratedOnAdd();
        }
    }
}

/* 
    PM> Install-Package Microsoft.EntityFrameworkCore
    PM> Install-Package Microsoft.EntityFrameworkCore.Sqlite
    PM> Install-Package Microsoft.EntityFrameworkCore.Tools
    PM> add-migration init
    PM> update-database
*/