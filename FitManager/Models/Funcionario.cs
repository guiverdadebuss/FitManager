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
        public string Nome { get; set; }
        public string Usuario { get; set; }
        public string Cargo { get; set; }
        public string Senha { get; set; }
        public string ConfirmarSenha { get; set; }

        public Funcionario()
        {
            this.Cargo = "Recepcionista";
        }

        public Funcionario(int id, string nome, string usuario, string cargo)
        {
            this.Id = id;
            this.Nome = nome;
            this.Usuario = usuario;
            this.Cargo = cargo;
        }
    }
}
