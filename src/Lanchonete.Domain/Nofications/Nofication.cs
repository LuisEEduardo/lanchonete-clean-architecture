namespace Lanchonete.Domain;

public class Nofication
{
    public Nofication(string message)
    {
        Message = message;
    }

    public string Message { get; set; }
}
