using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using FitManager.Models;
using FitManager.Data;

namespace FitManager.Services
{
    public class SocioService
    {
        public bool CriarSocio(Socio novoSocio)
        {
            if (novoSocio.Nif.Length != 9)
            {
                throw new Exception("NIF Inválido");
            }

            bool sucesso = SocioRepository.AdicionarSocio(novoSocio);

            return sucesso;
        }

        public bool EditarSocio(Socio socioParaAtualizar)
        {
            if (socioParaAtualizar.Id <= 0)
            {
                throw new Exception("ID inválido para atualização");
            }

            if (string.IsNullOrWhiteSpace(socioParaAtualizar.Nome))
            {
                throw new Exception("O nome não pode ficar vazio");
            }

            return SocioRepository.AtualizarSocio(socioParaAtualizar);
        }
    }
}
