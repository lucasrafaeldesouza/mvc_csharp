using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using System.Text.RegularExpressions;

namespace Controllers
{
    public class EspecialidadeController 
    {
        public static Especialidade InserirEspecialidade(
            int Id,
            string Descricao,
            string Tarefa
        )
        {
            if (String.IsNullOrEmpty(Descricao))
            {
                throw new Exception("Descricao inválida");
            }
            Regex rx = new Regex("(^\\d{3}\\.\\d{3}\\.\\d{3}\\-\\d{2}$)|(^\\d{2}\\.\\d{3}\\.\\d{3}\\/\\d{4}\\-\\d{2}$)");

            return new Especialidade(Descricao, Tarefa);
        }

        public static Especialidade AlterarEspecialidade(
            int Id,
            string Descricao,
            string Tarefa
        )
        {
            Especialidade especialidade = GetEspecialidade(Id);

            if (!String.IsNullOrEmpty(Descricao))
            {
                especialidade.Descricao = Descricao;
            }

            return especialidade;
        }

        public static Especialidade ExcluirEspecialidade(
            int Id
        )
        {
            Especialidade especialidade = GetEspecialidade(Id);
            Especialidade.RemoverEspecialidade(especialidade);
            return especialidade;
        }

        public static List<Especialidade> VisualizarEspecialidade()
        {
            return Especialidade.GetEspecialidades();
        }

        public static Especialidade GetEspecialidade(int Id)
        {
            Especialidade especialidade = (
                from Especialidade in Especialidade.GetEspecialidades()
                    where Especialidade.Id == Id
                    select Especialidade
            ).First();

            if (especialidade == null)
            {
                throw new Exception("Dentista não encontrado");
            }

            return especialidade;
        }
    }
}