namespace Lanchonete.Domain.Models;

public class Pedido : Entity
{
    public Pedido()
    {
        StatusPedido = StatusPedido.EmAndamento;
        Lanches = new List<LanchePedido>();
        DataHora = DateTime.Now;
    }

    public DateTime DataHora { get; private set; }
    public StatusPedido StatusPedido { get; private set; }
    public IList<LanchePedido> Lanches { get; private set; }

    public void AlterarStatus(StatusPedido statusPedido)
    {
        StatusPedido = statusPedido;
    }

}
