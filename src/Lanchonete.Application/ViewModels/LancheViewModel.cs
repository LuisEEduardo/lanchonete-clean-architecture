namespace Lanchonete.Application.ViewModels;

public class LancheViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; private set; }
    public string Descricao { get; private set; }
    public double Preco { get; private set; }
    public bool Status { get; private set; }
}
