using AutoMapper;
using Lanchonete.Application.Interface;
using Lanchonete.Application.ViewModels;
using Lanchonete.Domain.Interfaces;
using Lanchonete.Domain.Interfaces.Repositories;
using Lanchonete.Domain.Models;

namespace Lanchonete.Application.App;

public class PedidoApplication : BaseApplication, IPedidoApplication
{
    private readonly IPedidoRepository _pedidoRepository;
    private readonly ILanchePedidoRepository _lanchePedidoRepository;
    private readonly ILancheRepository _lancheRepository;
    private readonly IMapper _mapper;

    public PedidoApplication(IPedidoRepository pedidoRepository,
                             ILanchePedidoRepository lanchePedidoRepository,
                             ILancheRepository lancheRepository,
                             IMapper mapper,
                             INotifier notifier) : base(notifier)
    {
        _pedidoRepository = pedidoRepository;
        _lanchePedidoRepository = lanchePedidoRepository;
        _lancheRepository = lancheRepository;
        _mapper = mapper;
    }

    public async Task AlterarStatusPedido(Guid pedidoId, StatusPedido statusPedido)
    {
        var pedido = await _pedidoRepository.GetById(pedidoId);

        if (pedido is null)
        {
            Notificar("Pedido inválido");
            return;
        }

        pedido.AlterarStatus(statusPedido);

        await _pedidoRepository.Update(pedido);
    }

    public async Task Criar(IList<Guid> lanchesIds)
    {
        var pedido = new Pedido();
        List<LanchePedido> lanchePedidos = new();

        await AdicionarLanches(lanchesIds, pedido.Id);

        await _pedidoRepository.Post(pedido);
        await _lanchePedidoRepository.PostRange(lanchePedidos);
    }

    public async Task<PedidoViewModel> ObterPorId(Guid id)
    {
        var pedido = await _pedidoRepository.ObterPedidoCompleto(id);

        if (pedido is null)
        {
            Notificar("Pedido inválido");
            return null;
        }

        return new PedidoViewModel
        {
            Id = pedido.Id,
            DataHora = pedido.DataHora,
            StatusPedido = pedido.StatusPedido,
            Lanches = _mapper.Map<IList<LancheViewModel>>(pedido.Lanches.Select(x => x.Lanche))
        };
    }

    public async Task<IList<PedidoViewModel>> ObterTodos()
        => _mapper.Map<IList<PedidoViewModel>>(await _pedidoRepository.GetAll());

    public async Task AdicionarLanche(IList<Guid> lanchesId, Guid pedidoId)
    {
        await PedidoValido(pedidoId);
        await AdicionarLanches(lanchesId, pedidoId);
    }

    public async Task RemoverLanche(IList<Guid> lanchesId, Guid pedidoId)
    {
        await PedidoValido(pedidoId);

        List<LanchePedido> lanchesPedido = new();

        foreach (var lancheId in lanchesId)
        {
            var lanchePedido = await _lanchePedidoRepository.ObterLanchePedido(pedidoId, lancheId);

            if (lanchePedido is null)
            {
                Notificar("Lanche não está no pedido");
                return;
            }

            lanchesPedido.Add(lanchePedido);
        }

        await _lanchePedidoRepository.RemoverLanchesPedidos(lanchesPedido);
    }

    private async Task AdicionarLanches(IList<Guid> lanchesIds, Guid pedidoId)
    {
        List<LanchePedido> lanchePedidos = new();

        foreach (var lancheId in lanchesIds)
        {
            await LancheValido(lancheId);

            lanchePedidos.Add(new LanchePedido(lancheId, pedidoId));
        }

        await _lanchePedidoRepository.PostRange(lanchePedidos);
    }

    private async Task<bool> PedidoValido(Guid pedidoId)
    {
        var pedido = await _pedidoRepository.GetById(pedidoId);

        if (pedido is null)
        {
            Notificar("Pedido inválido");
            return false;
        }

        return true;
    }

    private async Task<bool> LancheValido(Guid lancheId)
    {
        var lanche = await _lancheRepository.GetById(lancheId);

        if (lanche is null)
        {
            Notificar("Lanche inválido");
            return false;
        }

        return true;
    }

}
