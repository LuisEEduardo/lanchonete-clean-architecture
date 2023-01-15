namespace Lanchonete.Domain.Models;

public class Lanche : Entity
{
    public Lanche(string nome, string descricao, double preco)
    {
        Nome = nome.Trim();
        Descricao = descricao.Trim();
        Preco = preco;
        Status = true;
    }

    public string Nome { get; private set; }
    public string Descricao { get; private set; }
    public double Preco { get; private set; }
    public bool Status { get; private set; }

    public void Editar(string nome, string descricao, double preco)
    {
        Nome = nome.Trim();
        Descricao = descricao.Trim();
        Preco = preco;
    }

    public void AlterarStatus(bool status)
    {
        Status = status;
    }

}
