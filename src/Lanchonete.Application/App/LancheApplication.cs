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

    public async Task<IList<LancheViewModel>> ObterTodos(Guid id)
        => _mapper.Map<IList<LancheViewModel>>(await _repository.GetAll());

    public async Task Atualizar(LancheViewModel viewModel)
    {
        var entidade = _mapper.Map<Lanche>(viewModel);

        if (ExecutarValidacao(new LancheValidation(), entidade))
            return;

        await _repository.Update(entidade);
    }

    public async Task Criar(LancheViewModel viewModel)
    {
        var entidade = _mapper.Map<Lanche>(viewModel);

        if (ExecutarValidacao(new LancheValidation(), entidade))
            return;

        await _repository.Post(entidade);
    }

    public async Task Remover(Guid id)
    {
        await _repository.Remove(id);
    }
}
