using AutoMapper;
using TreinoApp.Domain.BoundedContexts.UsuarioContext.DataTransferObject;
using TreinoApp.Domain.BoundedContexts.UsuarioContext.Entities;

namespace TreinoApp.API.Profiles;

public class TreinoProfile : Profile
{
    public TreinoProfile()
    {
        CreateMap<CreateTreinoDto, Treino>();
        CreateMap<Treino, CreateTreinoDto>();
    }
}
