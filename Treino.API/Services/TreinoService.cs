using AutoMapper;
using Treino.API.DataBase.Dtos.Treino;
using Treino.API.Models;
using TreinoAPI.DataBase;
using TreinoAPI.Exceptions;

namespace Treino.API.Services;

public class TreinoService
{
    private TreinoContext treinoContext;
    private IMapper mapper;

    public TreinoService(TreinoContext treinoContext, IMapper mapper)
    {
        this.treinoContext = treinoContext;
        this.mapper = mapper;
    }

    public void AdicionarTreino(TreinoDto treinoDto)
    {
        TreinoModel treino = mapper.Map<TreinoModel>(treinoDto);
        treinoContext.Treinos.Add(treino);
        treinoContext.SaveChanges();
    }

    public IEnumerable<TreinoModel> MostrarTodosOsTreinos()
    {
        if (treinoContext.Treinos.Count() == 0)
        {
            throw new TreinoNotFoundException("Nenhum treino foi cadastrado.");
        }
        return treinoContext.Treinos.ToList();
    }

    public void AtualizarTreino(int id, TreinoDto treinoDto)
    {
        var treinoAAtualizarModel = GetTreinoPorId(id);

        if (treinoAAtualizarModel is null)
        {
            throw new TreinoNotFoundException("Nenhum treino foi encontrado.");
        }

        mapper.Map(treinoDto, treinoAAtualizarModel);
        
        treinoContext.Treinos.Update(treinoAAtualizarModel);
        treinoContext.SaveChanges();
    }

    public void RemoverTreino(int id)
    {
        var treino = treinoContext.Treinos.FirstOrDefault(t => t.Id.Equals(id));

        if (treino is null)
        {
            throw new TreinoNotFoundException("Nenhum treino foi encontrado com esse Id.");
        }
        treinoContext.Treinos.Remove(treino!);
        treinoContext.SaveChanges();
    }

    public TreinoModel GetTreinoPorId(int id)
    {
        var treino = treinoContext.Treinos.FirstOrDefault(t => t.Id.Equals(id));
        
        if (treino is null)
        {
            throw new TreinoNotFoundException($"Nenhum treino com ID {id} foi encontrado.");
        }
        treinoContext.Update(treino);
        treinoContext.SaveChanges();
        return treino;
    }

    public TreinoModel MostrarTreinoMaisRapido2km()
    {
        var treinoMaisRapido = treinoContext.Treinos.OrderBy(t => t.Tempo)
            .Where(t => t.Distancia >= 2.00)
            .FirstOrDefault();

        if (treinoMaisRapido is null)
        {
            throw new TreinoNotFoundException("Nenhum treino acima de 2km foi encontrado.");
        }
        return treinoMaisRapido;
    }

    public TreinoModel MostrarTreinoMaisDistante()
    {
        var treinoMaisDistante = treinoContext.Treinos.OrderByDescending(t => t.Distancia).FirstOrDefault();
        
        if (treinoMaisDistante is null)
        {
            throw new TreinoNotFoundException("Nenhum treino foi encontrado.");
        }
        return treinoMaisDistante;
    }

    public TreinoModel MostrarTreinoMaisLongo()
    {
        var treinoMaisLongo = treinoContext.Treinos.OrderByDescending(t => t.Tempo).FirstOrDefault();
        
        if (treinoMaisLongo is null)
        {
            throw new TreinoNotFoundException("Nenhum treino foi encontrado.");
        }
        return treinoMaisLongo;
    }
}