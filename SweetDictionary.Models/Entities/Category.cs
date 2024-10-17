using Core.Entities;

namespace SweetDictionary.Models.Entities;

public class Category : Entity<int>
{
    public string Name { get; set; }
    public List<Post> Posts { get; set; }
}