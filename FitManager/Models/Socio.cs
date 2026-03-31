using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitManager.Models
{
        public class Socio
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Nif { get; set; }
            public string Telefone { get; set; }
            public DateTime DataInscricao { get; set; }
            public bool EstadoAtivo { get; set; }
            public int PlanoId { get; set; }
            public Plano PlanoEscolhido { get; set; }

            public Socio()
            {
                this.DataInscricao = DateTime.Now;
                this.EstadoAtivo = true;
            }

            public Socio(int id, string nome, string nif, string telefone, bool estado, int planoId)
            {
                this.Id = id;
                this.Nome = nome;
                this.Nif = nif;
                this.Telefone = telefone;
                this.EstadoAtivo = estado;
                this.PlanoId = planoId;
            }
        }
    }

