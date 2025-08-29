using LayoutService_AdminPanel.Models;
using Microsoft.EntityFrameworkCore;

namespace LayoutService_AdminPanel.Data
{
    public class PustokDbContext(DbContextOptions<PustokDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PustokDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookImage> BookImages { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<BookTag> BookTags { get; set; }
        public DbSet<Setting> Settings { get; set; }

    }
}
