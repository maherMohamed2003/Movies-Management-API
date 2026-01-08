using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MoviesAPI.Configurations
{
    public class MovieConfig : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title)
                .HasMaxLength(100).HasColumnName("Name").HasColumnType("VARCHAR");
        }
    }
}
