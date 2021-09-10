using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface IEstudioRepository
    {
        public List<EstudioDomain> ListarTodos();

        public EstudioDomain BuscarPorId(int idEstudio);


        void Cadastrar(EstudioDomain novoEstudio);


        void AtualizarIdCorpo(EstudioDomain estudioAtualizado);


        void Deletar(int idEstudio);
    }
}
