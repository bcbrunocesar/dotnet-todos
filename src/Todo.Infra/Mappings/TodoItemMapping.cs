
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Domain.Entities;

namespace Todo.Infra.Mappings
{
    public class TodoItemMapping : IEntityTypeConfiguration<TodoItem>
    {
        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
            builder.ToTable("Todo");

            builder.Property(x => x.Id);
            builder.Property(x => x.User)
                .HasMaxLength(120)
                .HasColumnType("varchar(120)");

            builder.Property(x => x.Title)
                .HasMaxLength(160)
                .HasColumnType("varchar(160)");

            builder.Property(x => x.Done).HasColumnType("bit");
            builder.Property(x => x.Date);
            builder.Property(x => x.User);
        }
    }
}