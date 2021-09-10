using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface IJogoRepository
    {
        public List<JogoDomain> ListarTodos();

        public JogoDomain BuscarPorId(int idJogo);


        void Cadastrar(JogoDomain novoJogo);

        void Deletar(int idJogo);

        void AtualizarIdCorpo(JogoDomain jogoAtualizado);
    }
}
