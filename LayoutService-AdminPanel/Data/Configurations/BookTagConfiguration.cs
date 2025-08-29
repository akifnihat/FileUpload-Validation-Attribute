using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LayoutService_AdminPanel.Models;

namespace LayoutService_AdminPanel.Data.Configurations
{
    public class BookTagConfiguration : IEntityTypeConfiguration<BookTag>
    {
        public void Configure(EntityTypeBuilder<BookTag> builder)
        {
            builder.HasKey(bt => new { bt.TagId, bt.BookId });
        }
    }
}
