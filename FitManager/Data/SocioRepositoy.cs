using FitManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitManager.Data
{
    public class SocioRepository
    {
        public void Adicionar(Socio socio)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                string sql = "INSERT INTO Socio (Nome, Nif, PlanoId, EstadoAtivo) VALUES (@nome, @nif, @plano, @estado)";
                // Aqui você usaria SqlCommand com Parameters
            }
        }

        public Socio BuscarPorNif(string nif)
        {
            // Retorna um objeto Socio preenchido do banco
        }
    }
}
