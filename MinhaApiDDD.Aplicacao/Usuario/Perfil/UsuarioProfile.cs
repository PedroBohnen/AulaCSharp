using AutoMapper;
using MinhaApiDDD.Dominio.Usuario.Entidade;

namespace MinhaApiDDD.Aplicacao.Usuario.Perfil
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile() 
        {
            CreateMap<UsuarioRequest, UsuarioEntidade>();
            CreateMap<UsuarioResponse, UsuarioEntidade>();
        }
}
