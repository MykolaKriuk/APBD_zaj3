namespace APBD_containers_zaj3.Exceptions;

public class OverfillException : System.Exception
{
    public OverfillException ()
    {
    }

    public OverfillException(string message) : base(message)
    {
    }

    public OverfillException(string message, System.Exception inner) : base(message, inner)
    {
    }
}