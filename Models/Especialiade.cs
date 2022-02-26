using System;
using System.Collections.Generic;

namespace Models
{
    public class Especialidade
    {
        public static int ID = 0;
        private static List<Especialidade> Especialidades = new List<Especialidade>();

        public int Id { set; get; }
        public string Descricao { set; get; }
        public string Tarefa { set; get; }

        public override string ToString()
        {
            return base.ToString()
                + $"\nDescricao: {this.Descricao}" 
                + $"\nTarefa: R$ {this.Tarefa}";
        }
        public Especialidade(
            string Descricao,
            string Tarefa
        ) : this(++ID, Descricao, Tarefa)
        {
        }

        private Especialidade(
            int Id,
            string Descricao,
            string Tarefa
        ) //: base(Id, Descricao, Preco)
        {
            this.Id = Id;
            this.Descricao = Descricao;
            this.Tarefa = Tarefa;

            Especialidades.Add(this);
        }


        public static List<Especialidade> GetEspecialidades()
        {
            return Especialidades;
        }

        public static void RemoverEspecialidade(Especialidade especialidade)
        {
            Especialidades.Remove(especialidade);
        }

        internal static List<Especialidade> GetEspecialidade(int idEspecialidade)
        {
            throw new NotImplementedException();
        }
    }
}