namespace Infra.Mappers
{
    using AutoMapper;
    using DTO;
    using Infra.Context;
    class PerfilProfile : Profile
    {

        public PerfilProfile()
        {
            CreateMap<Perfil, PerfilDTO>()
            .ForMember(dest => dest.Codigo, map => map.MapFrom(source => source.codigo))
             .ForMember(dest => dest.Nome, map => map.MapFrom(source => source.nome))
             .ReverseMap();
        }

    }
}
