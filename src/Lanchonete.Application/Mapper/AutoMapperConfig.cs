using AutoMapper;
using Lanchonete.Application.ViewModels;
using Lanchonete.Domain.Models;

namespace Lanchonete.Application.Mapper;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<Lanche, LancheViewModel>().ReverseMap();
        CreateMap<Pedido, PedidoViewModel>().ReverseMap();
    }
}
