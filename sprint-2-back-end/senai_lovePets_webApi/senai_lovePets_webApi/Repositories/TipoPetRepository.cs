using senai_lovePets_webApi.Context;
using senai_lovePets_webApi.Domains;
using senai_lovePets_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Repositories
{
    public class TipoPetRepository : ITipoPetRepository
    {

        lovePetsContext ctx = new lovePetsContext();


        public void Atualizar(int id, TipoPet tipoPetAtualizado)
        {
            TipoPet tipoPetBuscado = ctx.TipoPets.Find(id);

            if (tipoPetAtualizado.NomeTipoPet != null)
            {
                tipoPetBuscado.NomeTipoPet = tipoPetAtualizado.NomeTipoPet;
            }

            ctx.TipoPets.Update(tipoPetBuscado);

            ctx.SaveChanges();
        }

        public TipoPet BuscarPorId(int id)
        {
            return ctx.TipoPets.FirstOrDefault(tu => tu.IdTipoPet == id);
        }

        public void Cadastrar(TipoPet novoTipoPet)
        {
            ctx.TipoPets.Add(novoTipoPet);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            TipoPet tipoPetBuscado = ctx.TipoPets.Find(id);

            ctx.TipoPets.Remove(tipoPetBuscado);

            ctx.SaveChanges();
        }

        public List<TipoPet> Listar()
        {
            return ctx.TipoPets.ToList();
        }
    }
}
