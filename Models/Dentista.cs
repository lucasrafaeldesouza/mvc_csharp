using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Repository;

namespace Models
{
    public class Dentista : Pessoa
    {
        [Required]
        public string Registro { set; get; }
        [Required]
        public double Salario { set; get; }
        [Required]
        public string Especialidade { set; get; }
        [Required]
        public string EspecialidadeId { set; get; }

        public override string ToString()
        {
            return base.ToString()
                + $"\n Registro: {this.Registro}"
                + $"\n Salario: {this.Salario}"
                + $"\n Especialidade: {this.Especialidade}";
        }

        public Dentista() { }
        
        public Dentista(
            string Nome,
            string Cpf,
            string Fone,
            string Email,
            string Senha,
            string Registro,
            double Salario,
            string Especialidade
        ) : base(Nome, Cpf, Fone, Email, Senha)
        {
            this.Registro = Registro;
            this.Salario = Salario;
            this.Especialidade = Especialidade;

            Context db = new Context();
            db.Dentistas.Add(this);
            db.SaveChanges();

            //Dentista.Add(this);
        }


        public static List<Dentista> GetDentistas()
        {
            Context db = new Context();
            return (from Dentista in db.Dentistas select Dentista).ToList();
        }

        public static void RemoverDentista(Dentista dentista)
        {
            Context db = new Context();
            db.Dentistas.Remove(dentista);
        }

    }
}