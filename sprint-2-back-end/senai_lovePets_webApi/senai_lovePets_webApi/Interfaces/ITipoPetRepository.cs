using senai_lovePets_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Interfaces
{
    interface ITipoPetRepository
    {
        List<TipoPet> Listar();
        TipoPet BuscarPorId(int id);
        void Cadastrar(TipoPet novoTipoPet);
        void Atualizar(int id, TipoPet tipoPetAtualizado);
        void Deletar(int id);
    }
}
