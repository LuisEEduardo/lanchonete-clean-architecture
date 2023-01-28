namespace Lanchonete.Domain.Models;

public class Lanche : Entity
{
    public Lanche()
    {
    }

    public Lanche(string nome, string descricao, float preco)
    {
        Nome = nome.Trim();
        Descricao = descricao.Trim();
        Preco = preco;
        Status = true;
    }

    public string Nome { get; private set; }
    public string Descricao { get; private set; }
    public float Preco { get; private set; }
    public bool Status { get; private set; }

    public IList<LanchePedido> Pedidos { get; set; }

    public void Editar(string nome, string descricao, float preco)
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
