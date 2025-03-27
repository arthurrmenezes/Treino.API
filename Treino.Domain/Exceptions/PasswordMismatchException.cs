namespace Users.API.Exceptions;

public class PasswordMismatchException : Exception
{
    public PasswordMismatchException() { }

    public PasswordMismatchException(string message) : base(message) { }
}
