using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server_todo.Data.Entities;

namespace TodoWebApp_Server_v2.Data.Configs
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure( EntityTypeBuilder<User> builder )
        {
            builder.HasAnnotation("Relational:TableName", "User");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Theme).HasMaxLength(50);
            builder.Property(x => x.Language).HasMaxLength(50);
            builder.Property(x => x.Image).HasColumnType("nvarchar(max)");
        }
    }
}
