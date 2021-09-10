using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao = "Data Source=DESKTOP-30RGV41\\SQLEXPRESS; initial catalog=InLock_Games_Tarde; user Id=sa; pwd=senai@132";



        public UsuarioDomain BuscarPorEmailSenha(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string querySelect = @"    SELECT    idUsuario
			                                        ,email
			                                        ,senha
			                                        ,permissao
                                          FROM USUARIOS 
                                          WHERE email = @email
                                          and senha = @senha ";

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuarioBuscado = new UsuarioDomain
                        {
                            idUsuario = Convert.ToInt32(rdr["idUsuario"]),
                            TipoUsuario = new TipoUsuarioDomain()
                            {
                               idTipouser = Convert.ToInt32(rdr["idTipouser"])
                            },
                            Email = rdr["Email"].ToString(),
                            Senha = rdr["Senha"].ToString()
                        };

                        return usuarioBuscado;

                    }

                    return null;

                }
            }
        }

    }
}
