using FluentValidation;
using Lanchonete.Domain.Models;

namespace Lanchonete.Domain.Validations;

public class PedidoValidation : AbstractValidator<Pedido>
{
    public PedidoValidation()
    {
        
    }
}
