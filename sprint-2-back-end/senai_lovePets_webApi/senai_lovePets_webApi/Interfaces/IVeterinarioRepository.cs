using senai_lovePets_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Interfaces
{
    interface IVeterinarioRepository
    {
        List<Veterinario> Listar();
        Veterinario BuscarPorId(int id);
        void Cadastrar(Veterinario novoVeterinario);
        void Atualizar(int id, Veterinario veterinariosAtualizado);
        void Deletar(int id);
    }
}
