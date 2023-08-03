using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server_todo.Data.Entities;

namespace server_todo.Data.Configs
{
    public class SubTaskTodoConfig : IEntityTypeConfiguration<SubTaskTodo>
    {
        public void Configure( EntityTypeBuilder<SubTaskTodo> builder )
        {
            builder.HasKey( x => x.Id );
            builder.HasAnnotation("Relational:TableName", "SubTaskTodo");
            builder.Property(x => x.Due_Date).HasColumnType("nvarchar(max)");
            builder.Property(x => x.CreatedAt).HasColumnType("nvarchar(max)");

            builder.HasOne(x => x.TaskTodo).WithMany(x => x.SubTaskTodos).HasForeignKey(x => x.TaskTodo_id).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
