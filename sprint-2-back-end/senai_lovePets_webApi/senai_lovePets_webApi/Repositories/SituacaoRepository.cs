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
    public class SituacaoRepository : ISituacaoRepository
    {
        lovePetsContext ctx = new lovePetsContext();

        public void Atualizar(int id, Situacao SituacaoAtualizada)
        {
            throw new NotImplementedException();
        }

        public Situacao BuscarPorId(int id)
        {
            return ctx.Situacaos.FirstOrDefault(x => x.IdSituacao == id);
        }

        public void Cadastrar(Situacao novaSituacao)
        {
            ctx.Situacaos.Add(novaSituacao);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Situacaos.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Situacao> Listar()
        {
            return ctx.Situacaos.Include(p => p.Atendimentos).ToList();
        }
    }
}