using senai_lovePets_webApi.Context;
using senai_lovePets_webApi.Domains;
using senai_lovePets_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        lovePetsContext ctx = new lovePetsContext();

        public void Atualizar(int id, Clinica instituicaoAtualizada)
        {
            Clinica instituicaoBuscada = ctx.Clinicas.Find(id);

            if (instituicaoAtualizada.Cnpj != null)
            {
                instituicaoBuscada.Cnpj = instituicaoAtualizada.Cnpj;
            }

            if (instituicaoAtualizada.Endereco != null)
            {
                instituicaoBuscada.Endereco = instituicaoAtualizada.Endereco;
            }

            if (instituicaoAtualizada.RazaoSocial != null)
            {
                instituicaoBuscada.RazaoSocial = instituicaoAtualizada.RazaoSocial;
            }

            ctx.Clinicas.Update(instituicaoBuscada);

            ctx.SaveChanges();
        }
        public Clinica BuscarPorId(int id)
        {
            return ctx.Clinicas.FirstOrDefault(i => i.IdClinica == id);
        }

        public void Cadastrar(Clinica novaInstituicao)
        {
            ctx.Clinicas.Add(novaInstituicao);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Clinicas.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Clinica> Listar()
        {
            return ctx.Clinicas.ToList();
        }
    }
}
