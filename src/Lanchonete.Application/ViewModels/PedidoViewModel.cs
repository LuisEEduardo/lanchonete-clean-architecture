using Lanchonete.Domain.Models;

namespace Lanchonete.Application.ViewModels;

public class PedidoViewModel
{
    public Guid Id { get; set; }
    public DateTime DataHora { get; set; }
    public StatusPedido StatusPedido { get; set; }
    public IList<LancheViewModel> Lanches { get; set; }
    public IList<Guid> LanchesIds { get; set; }
}
