using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server_todo.Data.Entities;

namespace server_todo.Data.Configs
{
    public class SectionConfig : IEntityTypeConfiguration<Section>
    {
        public void Configure( EntityTypeBuilder<Section> builder )
        {
            builder.HasKey( x => x.Id );
            builder.HasAnnotation("Relational:TableName", "Section");
            builder.Property(x => x.Name).HasMaxLength(50);

            builder.HasOne(x => x.Project).WithMany( x => x.Sections ).HasForeignKey( x => x.Project_id ).OnDelete(DeleteBehavior.Cascade);


        }
    }
}
