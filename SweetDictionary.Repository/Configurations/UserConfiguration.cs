using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SweetDictionary.Models.Entities;

namespace SweetDictionary.Repository.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users").HasKey(c => c.Id);
        builder.Property(c => c.Id).HasColumnName("UserId");
        builder.Property(c => c.CreatedTime).HasColumnName("CreatedTime");
        builder.Property(c => c.UpdatedTime).HasColumnName("UpdatedTime");
        builder.Property(c => c.Username).HasColumnName("Username");
        builder.Property(c => c.FirstName).HasColumnName("FirstName");
        builder.Property(c => c.LastName).HasColumnName("LastName");
        builder.Property(c => c.Email).HasColumnName("Email");
        builder.Property(c => c.Password).HasColumnName("Password");

        builder.HasMany(u => u.Posts).WithOne(p => p.Author).HasForeignKey(p => p.AuthorId);
        builder.HasMany(u => u.Comments).WithOne(c => c.User).HasForeignKey(c => c.UserId);

        builder.HasData(
            new User()
            {
                Id = 1,
                Username = "admin",
                FirstName = "İsmail",
                LastName = "Yılmaz",
                Email = "ismail@gmail.com",
                Password = "123456",
                CreatedTime = DateTime.Now,
            });

        builder.Navigation(u => u.Posts).AutoInclude();
    }
}