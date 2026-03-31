using FitManager.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FitManager.Data
{
    public class SocioRepository
    {
        //public void Adicionar(Socio socio)
        //{
        //    using (var conn = DatabaseConnection.GetConnection())
        //    {
        //        string sql = "INSERT INTO Socio (Nome, Nif, PlanoId, EstadoAtivo) VALUES (@nome, @nif, @plano, @estado)";
        //        // Aqui você usaria SqlCommand com Parameters
        //    }
        //}

        //public Socio BuscarPorNif(string nif)
        //{
        //    // Retorna um objeto Socio preenchido do banco
        //}



        public static int CarregarTotalSociosAtivos()
        {
            try
            {
                using (SqlConnection sqlConnection = DatabaseConnection.GetConnection())
                {
                    if (sqlConnection.State != ConnectionState.Open)
                    {
                        sqlConnection.Open();
                    }
                    string sqlAtivos = "SELECT COUNT(*) FROM Socio WHERE EstadoAtivo = 1";
                    SqlCommand cmdAtivos = new SqlCommand(sqlAtivos, sqlConnection);
                    int totalAtivos = (int)cmdAtivos.ExecuteScalar();
                    return totalAtivos;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar resumo: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }



        public static int CarregarCheckIns()
        {
            try
            {
                using (SqlConnection sqlConnection = DatabaseConnection.GetConnection())
                {
                    if (sqlConnection.State != ConnectionState.Open)
                    {
                        sqlConnection.Open();
                    }
                    string sqlEntradas = "SELECT COUNT(*) FROM RegistoEntrada WHERE CAST(DataHora AS DATE) = CAST(GETDATE() AS DATE)";
                    SqlCommand cmdEntradas = new SqlCommand(sqlEntradas, sqlConnection);
                    int totalEntradas = (int)cmdEntradas.ExecuteScalar();
                    return totalEntradas;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar resumo: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }



        public static Socio BuscarSocioPorNifOuId(string busca)
        {
            try
            {
                using (SqlConnection sqlConnection = DatabaseConnection.GetConnection())
                {
                    sqlConnection.Open();

                    string sql = @"SELECT Id, Nome, Nif, EstadoAtivo 
                           FROM Socio 
                           WHERE Nif = @termo 
                           OR Id = TRY_CAST(@termo AS INT)";

                    using (SqlCommand cmd = new SqlCommand(sql, sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@termo", busca.Trim());

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Socio
                                {
                                    Id = (int)reader["Id"],
                                    Nome = reader["Nome"].ToString(),
                                    Nif = reader["Nif"].ToString(),
                                    EstadoAtivo = Convert.ToBoolean(reader["EstadoAtivo"])
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar sócio: " + ex.Message);
            }
            return null;
        }




        public static bool RegistarEntrada(int socioId)
        {
            try
            {
                using (SqlConnection sqlConnection = DatabaseConnection.GetConnection())
                {
                    sqlConnection.Open();
                    string sql = "INSERT INTO RegistoEntrada (SocioId, DataHora) VALUES (@id, GETDATE())";

                    using (SqlCommand cmd = new SqlCommand(sql, sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@id", socioId);
                        int linhasAfetadas = cmd.ExecuteNonQuery();
                        return linhasAfetadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao registar no banco: " + ex.Message);
            }
        }


        public static List<RegistoEntrada> ObterUltimosAcessos(int limite = 20)
        {
            List<RegistoEntrada> lista = new List<RegistoEntrada>();

            try
            {
                using (SqlConnection sqlConnection = DatabaseConnection.GetConnection())
                {
                    string sql = @"SELECT TOP (@limite) R.Id, R.DataHora, S.Nome, S.Nif 
                           FROM RegistoEntrada R
                           INNER JOIN Socio S ON R.SocioId = S.Id
                           ORDER BY R.DataHora DESC";

                    SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                    cmd.Parameters.AddWithValue("@limite", limite);

                    sqlConnection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            RegistoEntrada registro = new RegistoEntrada
                            {
                                Id = (int)reader["Id"],
                                DataHora = (DateTime)reader["DataHora"],
                                SocioQueEntrou = new Socio
                                {
                                    Nome = reader["Nome"].ToString(),
                                    Nif = reader["Nif"].ToString()
                                }
                            };
                            lista.Add(registro);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar histórico: " + ex.Message);
            }
            return lista;
        }

    }
}
