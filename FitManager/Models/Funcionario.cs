using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitManager.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Usuario { get; set; }

        public Funcionario(int id, string usuario)
        {
            this.Id = id;
            this.Usuario = usuario;
        }
    }
}
