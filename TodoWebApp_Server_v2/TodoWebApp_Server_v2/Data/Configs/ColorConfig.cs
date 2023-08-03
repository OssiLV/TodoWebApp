using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server_todo.Data.Entities;

namespace server_todo.Data.Configs
{
    public class ColorConfig : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasAnnotation("Relational:TableName", "Color");
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x => x.TailwindBgHexCode).HasMaxLength(50);

        }
    }
}
