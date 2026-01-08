

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MoviesAPI.Configurations
{
    public class GenreConfig : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .HasMaxLength(100).HasColumnName("Name").HasColumnType("VARCHAR");
            builder.Property(x => x.Description)
                .HasMaxLength(500).HasColumnName("Description").HasColumnType("VARCHAR");
        }
    }
}
