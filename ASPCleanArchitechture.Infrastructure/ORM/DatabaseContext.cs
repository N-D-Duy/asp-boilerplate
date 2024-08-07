using ASPCleanArchitechture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace ASPCleanArchitechture.Infrastructure.ORM
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            try
            {
                var databaseCreator = Database.GetService<IRelationalDatabaseCreator>() as RelationalDatabaseCreator;
                if(databaseCreator != null)
                {
                    if (!databaseCreator.CanConnect()) databaseCreator.Create();
                    if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>().HasKey(t => t.Id);
            modelBuilder.Entity<Todo>().Property(t => t.Title).IsRequired();
            modelBuilder.Entity<Todo>().Property(t => t.Description).IsRequired();
            modelBuilder.Entity<Todo>().Property(t => t.IsCompleted).IsRequired();
        }
    }
}
