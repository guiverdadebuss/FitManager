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
    }
}
