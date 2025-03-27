namespace TreinoApp.Domain.Exceptions;

public class TreinoNotFoundException : Exception
{
    public TreinoNotFoundException() { }
    
    public TreinoNotFoundException(string message) : base(message) { }
}
