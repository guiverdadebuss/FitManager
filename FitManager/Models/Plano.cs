using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitManager.Models
{
    public class Plano
    {
        public string Nome { get; set; }
        public decimal PrecoMensal { get; set; }
        public string Descricao { get; set; }

        // Facilita a exibição em ComboBoxes no Windows Forms
        public override string ToString()
        {
            return Nome;
        }
    }
}
