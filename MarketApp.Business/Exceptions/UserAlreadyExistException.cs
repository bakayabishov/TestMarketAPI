namespace MarketApp.Business.Exceptions;

[Serializable]
public class UserAlreadyExistException : Exception
{
    public string UserName { get; }
    public UserAlreadyExistException(string message)
        : base(message) { }
    
    public UserAlreadyExistException(string message, string username)
        : this(message)
    {
        UserName = username;
    }
}