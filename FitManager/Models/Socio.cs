using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitManager.Models
{
    public class Socio
    {
        public bool Ativo { get; set; } = true;
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NIF { get; set; }
        public string Contacto { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataInscricao { get; set; }
        public bool EstadoAtivo { get; set; }
        public int PlanoId { get; set; }
        public Plano PlanoEscolhido { get; set; }
        public Socio()
        {
            DataInscricao = DateTime.Now;
            EstadoAtivo = true;
        }
    }
}
