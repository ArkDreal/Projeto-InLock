using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private string stringConexao = "Data Source=DESKTOP-30RGV41\\SQLEXPRESS; initial catalog=InLock_Games_Tarde; user Id=sa; pwd=senai@132";

        public void AtualizarIdCorpo(JogoDomain JogoAtualizado)
        {
            if (JogoAtualizado.nomeJogo != null)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryUpdateBody = "UPDATE Jogo SET nomeJogo = @nomeJogo WHERE idJogo = @idJogo";

                    using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                    {
                        cmd.Parameters.AddWithValue("@idJogo", JogoAtualizado.idJogo);
                        cmd.Parameters.AddWithValue("@nomeJogo", JogoAtualizado.nomeJogo);
                        cmd.Parameters.AddWithValue("@idEstudio", JogoAtualizado.Estudio.idEstudio);
                        cmd.Parameters.AddWithValue("@DataLan", JogoAtualizado.DataLan);
                        cmd.Parameters.AddWithValue("@Valor", JogoAtualizado.Valor);
                        cmd.Parameters.AddWithValue("@Descricao", JogoAtualizado.Descricao);

                        con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }


        public JogoDomain BuscarPorId(int idJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT nomeJogo, idJogo, idEstudio, DataLan, Valor, Descricao FROM Jogo WHERE idJogo = @idJogo";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idJogo", idJogo);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        JogoDomain jogoBuscado = new JogoDomain
                        {
                            idJogo = Convert.ToInt32(reader["idJogo"]),

                            Estudio = new EstudioDomain()
                            {
                                idEstudio = Convert.ToInt32(reader["idEstudio"])
                            },

                            nomeJogo = reader["nomeJogo"].ToString(),

                            DataLan = Convert.ToDateTime(reader["Datalan"]),

                            Valor = Convert.ToDecimal(reader["Valor"]),

                            Descricao = reader["Descricao"].ToString()
                        };

                        return jogoBuscado;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(JogoDomain novoJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryInsert = @"INSERT INTO Jogo (idEstudio, nomeJogo, DataLan, Valor, Descricao) 
                                                 VALUES (@idEstudio,@nomeJogo,@DataLan,@Valor,@Descricao)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@nomeJogo", novoJogo.nomeJogo);
                    cmd.Parameters.AddWithValue("@idEstudio", novoJogo.Estudio.idEstudio);
                    cmd.Parameters.AddWithValue("@DataLan", novoJogo.DataLan);
                    cmd.Parameters.AddWithValue("@Valor", novoJogo.Valor);
                    cmd.Parameters.AddWithValue("@Descricao", novoJogo.Descricao);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Jogo WHERE idJogo = @idJogo";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idJogo", idJogo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<JogoDomain> ListarTodos()
        {
            List<JogoDomain> listaJogos = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idJogo, nomeJogo FROM Jogo";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogoDomain Jogo = new JogoDomain()
                        {

                            idJogo = Convert.ToInt32(rdr[0]),

                            nomeJogo = rdr[1].ToString()
                        };

                        listaJogos.Add(Jogo);
                    }
                }
            }

            return listaJogos;
        }
    }
}
