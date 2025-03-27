using AutoMapper;
using TreinoApp.API.Services;
using TreinoApp.Domain.BoundedContexts.UsuarioContext.DataTransferObject;
using TreinoApp.Domain.BoundedContexts.UsuarioContext.Entities;

namespace TreinoApp.Application.Services.TreinoContext;

public sealed class TreinoService
{
    private readonly IMapper _mapper;
    private readonly TreinoRepository _treinoRepository;

    public TreinoService(IMapper mapper, TreinoRepository treinoRepository)
    {
        _mapper = mapper;
        _treinoRepository = treinoRepository;
    }

    public async Task AdicionarTreino(CreateTreinoDto createTreinoDto)
    {
        var treino = _mapper.Map<Treino>(createTreinoDto);
        await _treinoRepository.AdicionarTreino(treino);
    }

    public async Task<IEnumerable<Treino>> GetTodosOsTreinos(int take = 5, int skip = 0)
    {
        var treinos = await _treinoRepository.GetTodosOsTreinos();
        return treinos;
    }

    public async Task AtualizarTreino(int id, CreateTreinoDto createTreinoDto)
    {
        var treinoAtualizar = await _treinoRepository.GetTreinoPorId(id);

        _mapper.Map(createTreinoDto, treinoAtualizar);

        await _treinoRepository.AtualizarTreino(treinoAtualizar);
    }

    public async Task RemoverTreino(int id)
    {
        await _treinoRepository.RemoverTreino(id);
    }

    public async Task<Treino> GetTreinoPorId(int id)
    {
        var treino = await _treinoRepository.GetTreinoPorId(id);
        return treino;
    }

    public async Task<CreateTreinoDto> GetTreinoParaAtualizar(int id)
    {
        var treino = await _treinoRepository.GetTreinoParaAtualizar(id);

        var treinoDto = _mapper.Map<CreateTreinoDto>(treino);

        return treinoDto;
    }

    public async Task<Treino?> GetTreinoMaisRapido2km()
    {
        return await _treinoRepository.GetTreinoMaisRapido2km();
    }

    public async Task<Treino?> GetTreinoMaisDistante()
    {
        return await _treinoRepository.GetTreinoMaisDistante();
    }

    public async Task<Treino?> GetTreinoMaisLongo()
    {
        return await _treinoRepository.GetTreinoMaisLongo();
    }

    public async Task<Treino?> GetTreinoPorData(DateTime data)
    {
        return await _treinoRepository.GetTreinoPorData(data);
    }

    public async Task<List<Treino>> GetTodasCorridasDoMes(DateTime data)
    {
        return await _treinoRepository.GetTodasCorridasDoMes(data);
    }

    public async Task<List<Treino>> GetTodasCorridasDoAno(DateTime data)
    {
        return await _treinoRepository.GetTodasCorridasDoAno(data);
    }

    public async Task<List<Treino>> GetTodasCorridasDoUltimoMes(DateTime data)
    {
        return await _treinoRepository.GetTodasCorridasDoUltimoMes(data);
    }

    public async Task<List<Treino>> GetTodasCorridasDoUltimoAno(DateTime data)
    {
        return await _treinoRepository.GetTodasCorridasDoUltimoAno(data);
    }
}
