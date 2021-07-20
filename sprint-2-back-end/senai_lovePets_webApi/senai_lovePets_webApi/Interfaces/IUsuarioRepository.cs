using senai_lovePets_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Interfaces
{    
        interface IUsuarioRepository
        {        
            List<Usuario> Listar();

            Usuario BuscarPorId(int id);

            void Cadastrar(Usuario novoUsuario);

            void Atualizar(int id, Usuario usuarioAtualizado);

            void Deletar(int id);

            Usuario Login(string email, string senha);

            Usuario BuscarPorEmailSenha(string email, string senha);
    }
}
