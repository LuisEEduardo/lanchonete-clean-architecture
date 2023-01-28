namespace Lanchonete.Domain.Models;

public class LanchePedido : Entity
{
    public LanchePedido()
    {
    }

    public LanchePedido(Guid lancheId, Guid pedidoId)
    {
        LancheId = lancheId;
        PedidoId = pedidoId;
    }

    public Guid LancheId { get; set; }
    public Lanche Lanche { get; set; }

    public Guid PedidoId { get; set; }
    public Pedido Pedido { get; set; }
}
