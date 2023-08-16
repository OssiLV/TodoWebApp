using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server_todo.Data.Entities;

namespace server_todo.Data.Configs
{
    public class ColorConfig : IEntityTypeConfiguration<Color>
    {
        public void Configure( EntityTypeBuilder<Color> builder )
        {
            builder.HasKey(x => x.Id);
            builder.HasAnnotation("Relational:TableName", "Color");
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x => x.TailwindBgHexCode).HasMaxLength(50);


            builder.HasData(
                new Color { Id = 1, TailwindBgHexCode = "bg-[#6d28d9]", Name = "Violet" },
                new Color { Id = 2, TailwindBgHexCode = "bg-[#dbeafe]", Name = "Light Blue" },
                new Color { Id = 3, TailwindBgHexCode = "bg-[#60a5fa]", Name = "Sky Blue" },
                new Color { Id = 4, TailwindBgHexCode = "bg-[#0d9488]", Name = "Teal" },
                new Color { Id = 5, TailwindBgHexCode = "bg-[#a3a3a3]", Name = "Charcoal" });
        }
    }
}
