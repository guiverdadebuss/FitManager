using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitManager.Services
{
    public static class ValidacaoService
    {
        public static bool ValidarNIF(string nif)
        {
            if (nif.Length != 9) return false;
            return true;
        }
    }
}
