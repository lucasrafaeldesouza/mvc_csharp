using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Repository;
using System;

namespace Models
{
    public class Procedimento
    {
        //public static int ID = 0;
        //private static List<Procedimento> Procedimentos = new List<Procedimento>();
        public int Id { set; get; }
        [Required]
        public string Descricao { set; get; }
        [Required]
        public double Preco { set; get; }

        public Procedimento() { }
        
        public Procedimento(
            string Descricao,
            double Preco
        ) //: this(++ID, Descricao,Preco)
        {
            this.Id = Id;
            this.Descricao = Descricao;
            this.Preco = Preco;
            Context db = new Context();
            db.Procedimentos.Add(this);
            db.SaveChanges();
        }
        /*
        private Procedimento(
            int Id,
            string Descricao,
            double Preco
        ) //: base(Id, Descricao, Preco)
        {
            this.Id = Id;
            this.Descricao = Descricao;
            this.Preco = Preco;

            Procedimentos.Add(this);
        }
        */

        public override string ToString()
        {
           return $"ID: {this.Id}" 
                + $"\nDescrição: {this.Descricao}"
                + $"\nPreço: R$ {this.Preco}";
        }

          public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!Procedimento.ReferenceEquals(obj, this))
            {
                return false;
            }
            Procedimento it = (Procedimento) obj;
            return it.Id == this.Id;
        }
        public static List<Procedimento> GetProcedimentos()
        {
            Context db = new Context();
            return (from Procedimento in db.Procedimentos select Procedimento).ToList();
        }

        public static void RemoverProcedimento(Procedimento procedimento)
        {
            Context db = new Context();
            db.Procedimentos.Remove(procedimento);
        }

    }
}