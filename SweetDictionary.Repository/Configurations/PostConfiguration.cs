using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SweetDictionary.Models.Entities;

namespace SweetDictionary.Repository.Configurations;

public class PostConfiguration: IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("Posts").HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnName("PostId");
        builder.Property(p => p.CreatedTime).HasColumnName("CreatedTime");
        builder.Property(p => p.UpdatedTime).HasColumnName("UpdatedTime");
        builder.Property(p => p.Title).HasColumnName("Title");
        builder.Property(p => p.Content).HasColumnName("Content");
        builder.Property(p => p.AuthorId).HasColumnName("AuthorId");
        builder.Property(p => p.CategoryId).HasColumnName("CategoryId");
        
        
        builder.HasOne(p => p.Author).WithMany(u => u.Posts).HasForeignKey(p => p.AuthorId).OnDelete(DeleteBehavior.NoAction);
        builder.HasMany(p => p.Comments).WithOne(c => c.Post).HasForeignKey(c => c.PostId).OnDelete(DeleteBehavior.NoAction);
        
        builder.Navigation(p => p.Category).AutoInclude();
        builder.Navigation(p => p.Author).AutoInclude();
        builder.Navigation(p => p.Comments).AutoInclude();
    }
}