using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Repository;
using System;

namespace Models
{
    public class Atendimento
    {
        public int Id { set; get; }
        [Required]
        public int ProcedimentoId { set; get; }
        public Procedimento Procedimento { set; get; }
        [Required]
        public int AgendamentoId { set; get; }
        public Agendamento Agendamento { set; get; }

        public Atendimento() { }
        
        public Atendimento(
            int IdProcedimento,
            int IdAgendamento
        )
        {
            this.ProcedimentoId = IdProcedimento;
            this.AgendamentoId = IdAgendamento;
            Context db = new Context();
            db.Atendimentos.Add(this);
            db.SaveChanges();
        }

        public override string ToString()
        {
            return $"ID: {this.Id}"
                 + $"\nProcedimentoId: {this.ProcedimentoId}"
                 + $"\nAgendamentoId: {this.AgendamentoId}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!Atendimento.ReferenceEquals(obj, this))
            {
                return false;
            }
            Atendimento it = (Atendimento)obj;
            return it.Id == this.Id;
        }
        public static List<Atendimento> GetAtendimentos()
        {
            Context db = new Context();
            return (from Atendimento in db.Atendimentos select Atendimento).ToList();
        }

        public static void RemoverAtendimento(Atendimento atendimento)
        {
            Context db = new Context();
            db.Atendimentos.Remove(atendimento);
        }

    }
}