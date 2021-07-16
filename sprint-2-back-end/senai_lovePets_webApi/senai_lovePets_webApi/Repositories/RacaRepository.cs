using Microsoft.EntityFrameworkCore;
using senai_lovePets_webApi.Context;
using senai_lovePets_webApi.Domains;
using senai_lovePets_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Repositories
{
    public class RacaRepository : IRacaRepository
    {

        lovePetsContext ctx = new lovePetsContext();

        public void Atualizar(int id, Raca racaAtualizado)
        {
            Raca racaBuscado = ctx.Racas.Find(id);

            if (racaAtualizado.NomeRaca != null)
            {
                racaBuscado.NomeRaca = racaAtualizado.NomeRaca;
            }

            ctx.Racas.Update(racaBuscado);

            ctx.SaveChanges();
        }

        public Raca BuscarPorId(int id)
        {
            return ctx.Racas.FirstOrDefault(x => x.IdRaca == id);
        }

        public void Cadastrar(Raca novaRaca)
        {
            ctx.Racas.Add(novaRaca);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Racas.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Raca> Listar()
        {
            return ctx.Racas.Include(p => p.IdRaca).ToList();
        }
    }
}
