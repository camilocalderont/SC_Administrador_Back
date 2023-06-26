using AutoMapper;
using Dominio.Administrador;
using WebApi.Requests;

namespace WebApi.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {           
            CreateMap<Usuario,UsuarioCreateRequest>().ReverseMap();
            CreateMap<Usuario,UsuarioUpdateRequest>().ReverseMap();
            CreateMap<UsuarioRol,UsuarioRolCreateRequest>().ReverseMap();

        }
    }
}
