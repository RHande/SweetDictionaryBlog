using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SweetDictionary.Models.Entities;

namespace SweetDictionary.Repository.Configurations;

public class CategoryConfigiration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories").HasKey(c => c.Id);
        builder.Property(c=>c.Id).HasColumnName("CategoryId");
        builder.Property(c=>c.CreatedTime).HasColumnName("CreatedTime");
        builder.Property(c=>c.UpdatedTime).HasColumnName("UpdatedTime");
        builder.Property(c => c.Name).HasColumnName("Category_Name");
        builder.HasMany(x => x.Posts);
        builder.Property(c => c.Name).IsRequired().HasMaxLength(50);
        
        builder.HasMany(c => c.Posts).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasData(
            new Category()
            {
                Id = 1,
                Name = "Yazılım",
                CreatedTime = DateTime.Now
            });
    }
}