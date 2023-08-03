using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server_todo.Data.Entities;

namespace server_todo.Data.Configs
{
    public class ProjectConfig : IEntityTypeConfiguration<Project>
    {
        public void Configure( EntityTypeBuilder<Project> builder )
        {
            builder.HasKey( x => x.Id );
            builder.HasAnnotation("Relational:TableName", "Project");
            builder.Property(x => x.Name).HasMaxLength(50);

            //For User
            builder.HasOne(x => x.User).WithMany(x => x.Projects).HasForeignKey(x => x.User_id).OnDelete(DeleteBehavior.Cascade);

            //For Color
            builder.HasOne(x => x.Color).WithMany(x => x.Projects).HasForeignKey(x => x.Color_id).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
