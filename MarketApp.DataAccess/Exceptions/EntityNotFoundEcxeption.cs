namespace MarketApp.DataAccess.Exceptions;

public class EntityNotFoundException : Exception 
    {
    public string UserName { get; }
    public EntityNotFoundException(string message)
        : base(message) { }
    
    public EntityNotFoundException(string message, string username)
        : this(message)
    {
        UserName = username;
    }
}