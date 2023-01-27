namespace Lanchonete.Application.ViewModels;

public class LancheViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public double Preco { get; set; }
    public bool Status { get; set; }
}
