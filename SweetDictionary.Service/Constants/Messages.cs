namespace SweetDictionary.Service.Constants;

public static class Messages
{
    public const string PostAddedMessage = "Post added successfully";
    public const string PostUpdatedMessage = "Post updated successfully";
    public const string PostDeletedMessage = "Post deleted successfully";
    public const string PostFetchedMessage = "Post fetched successfully";
    public static string PostIsNotPresentMessage(Guid id) => $"Post with id {id} is not present";
    
    // Category Messages
    public const string CategoryAddedMessage = "Category added successfully";
    public const string CategoryUpdatedMessage = "Category updated successfully";
    public const string CategoryDeletedMessage = "Category deleted successfully";
    public const string CategoryFetchedMessage = "Category fetched successfully";
    public static string CategoryIsNotPresentMessage(int id) => $"Category with id {id} is not present";
}