using AutoMapper;
using Dominio.Administrador;
using Dominio.Mapper;

namespace Aplicacion.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Contrato, ContratoDTO>().ReverseMap(); 
        }
    }
}
