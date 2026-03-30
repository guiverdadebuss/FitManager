using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitManager.Models
{
    public class RegistoEntrada
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public int SocioId { get; set; }
        public Socio SocioQueEntrou { get; set; }

        public RegistoEntrada()
        {
            DataHora = DateTime.Now;
        }
    }
}
