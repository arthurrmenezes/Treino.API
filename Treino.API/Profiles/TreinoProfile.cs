using AutoMapper;
using Treino.API.DataBase.Dtos.Treino;
using Treino.API.Models;

namespace Treino.API.Profiles;

public class TreinoProfile : Profile
{
    public TreinoProfile()
    {
        CreateMap<TreinoDto, TreinoModel>();
    }
}
