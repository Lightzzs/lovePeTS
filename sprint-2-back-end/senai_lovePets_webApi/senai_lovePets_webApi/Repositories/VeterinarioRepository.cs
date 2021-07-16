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
    public class VeterinarioRepository : IVeterinarioRepository
    {

        lovePetsContext ctx = new lovePetsContext();

        public void Atualizar(int id, Veterinario veterinariosAtualizado)
        {
            Veterinario veterinarioBuscado = ctx.Veterinarios.Find(id);

            if (veterinariosAtualizado.NomeVeterinario != null)
            {
                veterinarioBuscado.NomeVeterinario = veterinariosAtualizado.NomeVeterinario;
            }

            ctx.Veterinarios.Update(veterinarioBuscado);

            ctx.SaveChanges();
        }

        public Veterinario BuscarPorId(int id)
        {
            return ctx.Veterinarios.FirstOrDefault(x => x.IdVeterinario == id);
        }

        public void Cadastrar(Veterinario novoVeterinario)
        {
            ctx.Veterinarios.Add(novoVeterinario);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Veterinarios.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Veterinario> Listar()
        {
            return ctx.Veterinarios.Include(p => p.IdVeterinario).ToList();
        }
    }
}
