using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server_todo.Data.Entities;

namespace server_todo.Data.Configs
{
    public class TaskTodoConfig : IEntityTypeConfiguration<TaskTodo>
    {
        public void Configure( EntityTypeBuilder<TaskTodo> builder )
        {
            builder.HasAnnotation("Relational:TableName", "TaskTodo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x => x.Priority).HasMaxLength(50);
            builder.Property(x => x.Due_Date).HasColumnType("nvarchar(max)");
            builder.Property(x => x.CreatedAt).HasColumnType("nvarchar(max)");

            //For Section
            builder.HasOne(x => x.Section).WithMany(x => x.TaskTodos).HasForeignKey(x => x.Section_id).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
