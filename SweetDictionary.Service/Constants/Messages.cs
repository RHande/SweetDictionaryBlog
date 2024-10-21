namespace SweetDictionary.Service.Constants;

public static class Messages
{
    public const string PostAddedMessage = "Post added successfully";
    public const string PostUpdatedMessage = "Post updated successfully";
    public const string PostDeletedMessage = "Post deleted successfully";
    public const string PostFetchedMessage = "Post fetched successfully";
    public static string PostIsNotPresentMessage(Guid id) => $"Post with id {id} is not present";
}