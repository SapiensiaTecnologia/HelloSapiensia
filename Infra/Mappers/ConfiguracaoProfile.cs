namespace Infra.Mappers
{
    using AutoMapper;
    using DTO;
    using Infra.Context;
    class ConfiguracaoProfile : Profile
    {

        public ConfiguracaoProfile()
        {
            CreateMap<Configuracao, ConfiguracaoDTO>()
            .ForMember(dest => dest.Codigo, map => map.MapFrom(source => source.codigo))
             .ForMember(dest => dest.Nome, map => map.MapFrom(source => source.nome))
             .ForMember(dest => dest.Valor, map => map.MapFrom(source => source.valor))
              .AfterMap((dest, source) =>
              {
                  if (source != null)
                  {
                      if(dest.Perfil != null)
                      {                         
                          source.PerfilId = dest.Perfil.codigo;
                          source.PerfilNome = dest.Perfil.nome;
                      }

                  }
              }).ReverseMap()
              .AfterMap((source, dest) =>
              {
                  if (source != null)
                  {
                      if (source.PerfilId > 0 )
                      {                          
                          dest.Perfil.codigo = source.PerfilId;
                          dest.perfil_id = source.PerfilId;
                      }

                  }
              });
        }

    }
}
