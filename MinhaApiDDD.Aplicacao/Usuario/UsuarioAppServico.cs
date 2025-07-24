using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MinhaApiDDD.Dominio.Usuario.Entidade;
using MinhaApiDDD.Dominio.Usuario.Interfaces;
using MinhaApiDDD.Aplicacao.Usuario.Interface;

using AutoMapper;

namespace MinhaApiDDD.Aplicacao.Usuario
{
    public class UsuarioAppServico : IUsuarioAppServico

    {
        private readonly IUsuarioServico UsuarioServico;
        private readonly IMapper Mapper;
        public UsuarioAppServico(IUsuarioServico usuarioServico, IMapper mapper) 
        {
            this.UsuarioServico = usuarioServico;
            this.Mapper = mapper;
        }

        public void InserirUsuario(UsuarioRequest usuario)
        {
            UsuarioEntidade entidade = Mapper.Map<UsuarioEntidade>(usuario);
            UsuarioServico.Inserir(entidade);
        }

        public List<UsuarioResponse> ListarUsuarios()
        {
            var entidade = UsuarioServico.ListarUsuarios();
            List<UsuarioResponse> usuario = Mapper.Map<List<UsuarioResponse>>(entidade);
            return usuario;
        }
    }
}
