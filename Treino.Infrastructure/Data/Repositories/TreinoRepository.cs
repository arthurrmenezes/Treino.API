using Microsoft.EntityFrameworkCore;
using TreinoApp.Domain.BoundedContexts.UsuarioContext.Entities;
using TreinoApp.Domain.Exceptions;
using TreinoApp.Infrastructure.Data;

namespace TreinoApp.API.Services;

public sealed class TreinoRepository
{
    private DataContext _dataContext;

    public TreinoRepository(DataContext dataContext)
    {
        this._dataContext = dataContext;
    }

    public async Task AdicionarTreino(Treino treino)
    {
        if (treino is null) throw new TreinoNotFoundException("Erro ao cadastrar o treino.");
        await _dataContext.Treinos.AddAsync(treino);
        await _dataContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Treino>> GetTodosOsTreinos(int take = 5, int skip = 0)
    {
        if (_dataContext.Treinos.Count() == 0)
        {
            throw new TreinoNotFoundException("Nenhum treino foi cadastrado.");
        }
        return await _dataContext.Treinos.Skip(skip).Take(take).ToListAsync();
    }

    public async Task AtualizarTreino(Treino treino)
    {
        if (treino is null) throw new TreinoNotFoundException("Erro ao atualizar o treino.");

        _dataContext.Treinos.Update(treino);
        await _dataContext.SaveChangesAsync();
    }

    public async Task RemoverTreino(int id)
    {
        var treino = _dataContext.Treinos.FirstOrDefault(t => t.Id.Equals(id));

        if (treino is null)
        {
            throw new TreinoNotFoundException("Nenhum treino foi encontrado com esse Id.");
        }
        _dataContext.Treinos.Remove(treino!);
        await _dataContext.SaveChangesAsync();
    }

    public async Task<Treino> GetTreinoPorId(int id)
    {
        var treino = _dataContext.Treinos.FirstOrDefault(t => t.Id.Equals(id));
        
        if (treino is null)
        {
            throw new TreinoNotFoundException($"Nenhum treino com ID {id} foi encontrado.");
        }
        _dataContext.Update(treino);
        await _dataContext.SaveChangesAsync();
        return treino;
    }

    public async Task<Treino> GetTreinoParaAtualizar(int id)
    {
        var treino = await GetTreinoPorId(id);
        if (treino is null) throw new TreinoNotFoundException($"Nenhum treino com Id {id} foi encontrado.");

        return treino;
    }

    public async Task<Treino?> GetTreinoMaisRapido2km()
    {
        var treinoMaisRapido = _dataContext.Treinos.OrderBy(t => t.Tempo)
            .Where(t => t.Distancia >= 2.00)
            .FirstOrDefaultAsync();

        if (treinoMaisRapido is null)
        {
            throw new TreinoNotFoundException("Nenhum treino acima de 2km foi encontrado.");
        }
        return await treinoMaisRapido;
    }

    public async Task<Treino?> GetTreinoMaisDistante()
    {
        var treinoMaisDistante = _dataContext.Treinos.OrderByDescending(t => t.Distancia)
            .FirstOrDefaultAsync();
        
        if (treinoMaisDistante is null)
        {
            throw new TreinoNotFoundException("Nenhum treino foi encontrado.");
        }
        return await treinoMaisDistante;
    }

    public async Task<Treino?> GetTreinoMaisLongo()
    {
        var treinoMaisLongo = _dataContext.Treinos.OrderByDescending(t => t.Tempo)
            .FirstOrDefaultAsync();
        
        if (treinoMaisLongo is null)
        {
            throw new TreinoNotFoundException("Nenhum treino foi encontrado.");
        }
        return await treinoMaisLongo;
    }

    public async Task<Treino?> GetTreinoPorData(DateTime data)
    {
        var treino = _dataContext.Treinos.FirstOrDefaultAsync(t => t.Data.Equals(data));

        if (treino is null)
        {
            throw new TreinoNotFoundException("Não existe nenhum treino com esta data.");
        }

        return await treino;
    }

    public async Task<List<Treino>> GetTodasCorridasDoMes(DateTime data)
    {
        var treinos = await _dataContext.Treinos.Where(t => t.Data.Month.Equals(data.Month)).ToListAsync();

        if (treinos.Count == 0)
        {
            throw new TreinoNotFoundException("Nenhum treino foi registrado neste mês.");
        }
        return treinos;
    }

    public async Task<List<Treino>> GetTodasCorridasDoAno(DateTime data)
    {
        var treinos = await _dataContext.Treinos.Where(t => t.Data.Year.Equals(data.Year)).ToListAsync();
        if (treinos.Count == 0)
        {
            throw new TreinoNotFoundException("Nenhum treino foi registrado neste ano.");
        }
        return treinos;
    }

    public async Task <List<Treino>> GetTodasCorridasDoUltimoMes(DateTime data)
    {
        DateTime dataLimite = data.AddDays(-30);
        var treinos = await _dataContext.Treinos.Where(t => t.Data >= data).ToListAsync();
        if (treinos.Count == 0)
        {
            throw new TreinoNotFoundException("Nenhum treino foi registrado nos últimos 30 dias.");
        }
        return treinos;
    }

    public async Task <List<Treino>> GetTodasCorridasDoUltimoAno(DateTime data)
    {
        DateTime dataLimite = data.AddDays(-365);
        var treinos = await _dataContext.Treinos.Where(t => t.Data >= data).ToListAsync();
        if (treinos.Count == 0)
        {
            throw new TreinoNotFoundException("Nenhum treino foi registrado nos últimos 30 dias.");
        }
        return treinos;
    }
}