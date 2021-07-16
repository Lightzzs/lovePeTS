using senai_lovePets_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
            List<TipoUsuario> Listar();
            TipoUsuario BuscarPorId(int id);
            void Cadastrar(TipoUsuario novoTipoUsuario);
            void Atualizar(int id, TipoUsuario tipoUsuarioAtualizado);
            void Deletar(int id);
    }
}
