using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitManager.Models
{
    public static class Sessao
    {
        public static Funcionario UsuarioLogado { get; set; }
        public static bool EstaLogado => UsuarioLogado != null;
        public static void AbandonarSessao()
        {
            UsuarioLogado = null;
        }
    }
}
