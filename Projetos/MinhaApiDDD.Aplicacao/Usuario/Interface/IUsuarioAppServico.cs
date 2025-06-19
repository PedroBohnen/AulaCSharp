using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinhaApiDDD.DataTransfer.Usuario.Request;
using MinhaApiDDD.DataTransfer.Usuario.Response;
using MinhaApiDDD.Dominio.Usuario.Entidade;

namespace MinhaApiDDD.Aplicacao.Usuario.Interface
{
    public interface IUsuarioAppServico
    {
        void InserirUsuario(UsuarioRequest usuario);
        List<UsuarioResponse> ListarUsuarios();
    }
}
