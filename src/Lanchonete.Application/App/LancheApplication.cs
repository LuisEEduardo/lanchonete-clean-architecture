using AutoMapper;
using Lanchonete.Application.Interface;
using Lanchonete.Application.ViewModels;
using Lanchonete.Domain.Interfaces;
using Lanchonete.Domain.Interfaces.Repositories;
using Lanchonete.Domain.Models;
using Lanchonete.Domain.Validations;

namespace Lanchonete.Application.App;

public class LancheApplication : BaseApplication, ILancheApplication
{
    private readonly ILancheRepository _repository;
    private readonly IMapper _mapper;

    public LancheApplication(ILancheRepository repository,
                             IMapper mapper,
                             INotifier notifier) : base(notifier)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<LancheViewModel> ObterPorId(Guid id)
        => _mapper.Map<LancheViewModel>(await _repository.GetById(id));

    public async Task<IList<LancheViewModel>> ObterTodos()
        => _mapper.Map<IList<LancheViewModel>>(await _repository.GetAll());

    public async Task Atualizar(LancheViewModel viewModel)
    {
        if (!ExecutarValidacao(new LancheValidation(), _mapper.Map<Lanche>(viewModel)))
            return;

        var entidade = await _repository.GetById(viewModel.Id);

        if (entidade is null)
        {
            Notificar("Lanche inválido");
            return;
        }

        entidade.Editar(viewModel.Nome, viewModel.Descricao, viewModel.Preco);

        await _repository.Update(entidade);
    }

    public async Task Criar(LancheViewModel viewModel)
    {
        if (!ExecutarValidacao(new LancheValidation(), _mapper.Map<Lanche>(viewModel)))
            return;

        var model = new Lanche(viewModel.Nome, viewModel.Descricao, viewModel.Preco);

        await _repository.Post(model);
    }

    public async Task Remover(Guid id)
    {
        var entidade = await _repository.GetById(id);

        if (entidade is null)
        {
            Notificar("Lanche inválido");
            return;
        }

        await _repository.Remove(id);
    }
}
