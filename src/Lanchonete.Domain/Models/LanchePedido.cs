namespace Lanchonete.Domain.Models;

public class LanchePedido
{
    public Guid LancheId { get; set; }
    public Lanche Lanche { get; set; }

    public Guid PedidoId { get; set; }
    public Pedido Pedido { get; set; }
}
