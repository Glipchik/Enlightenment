using EnlightenmentApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnlightenmentApp.DAL.DataContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            if (Database.IsRelational())
            {
                Database.Migrate();
            }
        }
        public DbSet<SectionEntity> Sections { get; set; }
        public DbSet<ModuleEntity> Modules { get; set; }
        public DbSet<ModuleReviewEntity> ModuleReviews { get; set; }
        public DbSet<TagEntity> Tags { get; set; }
        public DbSet<PathEntity> Paths { get; set; }
    }
}
