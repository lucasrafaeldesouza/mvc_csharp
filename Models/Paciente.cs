using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Repository;

namespace Models
{
    public class Paciente : Pessoa
    {
        /*
        public static int ID = 0;
        private static List<Paciente> Pacientes = new List<Paciente>();
        */

        [Required]
        public DateTime DataNascimento { set; get; }

        public override string ToString()
        {
            return base.ToString()
                + $"\nData de Nascimento: {this.DataNascimento}";
        }

        public Paciente(
            string Nome,
            string Cpf,
            string Fone,
            string Email,
            string Senha,
            DateTime DataNascimento
        ) : this(++ID, Nome, Cpf, Fone, Email, Senha, DataNascimento)
        {
            this.DataNascimento = DataNascimento;
            Context db = new Context();
            db.Pacientes.Add(this);
            db.SaveChanges();
        }

        /*
        private Paciente(
            int Id,
            string Nome,
            string Cpf,
            string Fone,
            string Email,
            string Senha,
            DateTime DataNascimento
        ) //: base(Id, Nome, Cpf, Fone, Email, Senha)
        {
            this.DataNascimento = DataNascimento;

            Context db = new Context();
            db.Pacientes.Add(this);
            db.SaveChanges();

            //Pacientes.Add(this);
        }
        */

        public static List<Paciente> GetPacientes()
        {
            Context db = new Context();
            return (from Paciente in db.Pacientes select Paciente).ToList();
        }

        public static void RemoverPaciente(Paciente paciente)
        {
             Context db = new Context();
             db.Pacientes.Remove(paciente);
        }

    }
}