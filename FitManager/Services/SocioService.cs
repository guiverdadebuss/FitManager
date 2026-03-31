using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using FitManager.Models;

namespace FitManager.Services
{
    public class SocioService
    {
        public void CriarSocio()
        {
            if (string.IsNullOrWhiteSpace())
                throw new Exception("O nome do sócio é obrigatório");
        }
    }
}
