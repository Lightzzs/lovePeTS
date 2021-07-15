using senai_lovePets_webApi.Context;
using senai_lovePets_webApi.Domains;
using senai_lovePets_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {

        lovePetsContext ctx = new lovePetsContext();

        public void Atualizar(int id, TipoUsuario tipoUsuarioAtualizado)
        {
            TipoUsuario tipoUsuarioBuscado = ctx.TipoUsuarios.Find(id);

            if (tipoUsuarioAtualizado.NomeTipoUsuario != null)
            {
                tipoUsuarioBuscado.NomeTipoUsuario = tipoUsuarioAtualizado.NomeTipoUsuario;
            }

            ctx.TipoUsuarios.Update(tipoUsuarioBuscado);

            ctx.SaveChanges();
        }

        public TipoUsuario BuscarPorId(int id)
        {
            return ctx.TipoUsuarios.FirstOrDefault(tu => tu.IdTipoUsuario == id);
        }

        public void Cadastrar(TipoUsuario novoTipoUsuario)
        {
            ctx.TipoUsuarios.Add(novoTipoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            TipoUsuario tipoUsuarioBuscado = ctx.TipoUsuarios.Find(id);

            ctx.TipoUsuarios.Remove(tipoUsuarioBuscado);

            ctx.SaveChanges();
        }

        public List<TipoUsuario> Listar()
        {
            return ctx.TipoUsuarios.ToList();
        }
    }
}
