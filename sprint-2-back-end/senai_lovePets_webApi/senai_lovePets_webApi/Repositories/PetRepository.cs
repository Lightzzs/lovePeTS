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
    public class PetRepository : IPetRepository
    {
        lovePetsContext ctx = new lovePetsContext();

        public void Atualizar(int id, Pet PetAtualizado)
        {
            Pet PetBuscado = ctx.Pets.Find(id);

            if (PetAtualizado.NomePet != null)
            {
                PetBuscado.NomePet = PetAtualizado.NomePet;
            }

            ctx.Pets.Update(PetBuscado);

            ctx.SaveChanges();
        }

        public Pet BuscarPorId(int id)
        {
            return ctx.Pets.FirstOrDefault(x => x.IdPet == id);
        }

        public void Cadastrar(Pet novoPet)
        {
            ctx.Pets.Add(novoPet);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Pets.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Pet> Listar()
        {
            return ctx.Pets.ToList();
        }
    }
}
