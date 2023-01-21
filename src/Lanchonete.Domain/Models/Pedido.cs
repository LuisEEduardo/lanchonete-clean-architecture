namespace Lanchonete.Domain.Models;

public class Pedido : Entity
{
    public Pedido()
    {
        StatusPedido = StatusPedido.EmAndamento;
        Lanches = new List<Lanche>();
        DataHora = DateTime.Now;
    }

    public DateTime DataHora { get; private set; }
    public StatusPedido StatusPedido { get; private set; }
    public IList<Lanche> Lanches { get; private set; }

    public void AdicionarLanche(Lanche lanche)
    {
        Lanches.Add(lanche);
    }

    public void RemoverLanche(Lanche lanche)
    {
        Lanches.Remove(lanche);
    }

    public void AlterarStatus(StatusPedido statusPedido)
    {
        StatusPedido = statusPedido;
    }

}
