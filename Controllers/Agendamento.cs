using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Controllers
{
    public class AgendamentoController
    {
        public static Agendamento InserirAgendamento(
            int PacienteId,
            int DentistaId,
            int SalaId,
            DateTime Data
            //int IdProcedimento
        )
        {
            PacienteController.GetPaciente(PacienteId);
            DentistaController.GetDentista(DentistaId);
            SalaController.GetSala(SalaId);
            //Procedimento procedimento = Procedimento.GetProcedimento(IdProcedimento);

            if (Data == null || Data <= DateTime.Now)
            {
                throw new Exception("Data não pode ser inferior a data atual.");
            }

            if (GetConflito(
                0,
                DentistaId,
                Data
            ))
            {
                throw new Exception("Já existe um agendamento para este horário");
            }

            return new Agendamento(PacienteId, DentistaId, SalaId, Data);
        }

        private static bool GetConflito(
            int IdAtual,
            int DentistaId,
            DateTime Data
        )
        {
            IEnumerable<Agendamento> agendamentos =
                from Agendamento in Agendamento.GetAgendamentos()
                    where Agendamento.Data == Data 
                        && Agendamento.DentistaId == DentistaId
                        && Agendamento.Id != IdAtual
                    select Agendamento;

            return agendamentos.Count() > 0;
        }

        public static Agendamento AlterarAgendamento(
            int Id,
            int IdSala,
            DateTime Data,
            int ProcedimentoId
        )
        {
            Agendamento agendamento = GetAgendamento(Id);

            SalaController.GetSala(IdSala);

            if (Data == null || Data < DateTime.Now)
            {
                throw new Exception("Data inválida");
            }

            if (GetConflito(
                agendamento.Id,
                agendamento.DentistaId,
                Data
            ))
            {
                throw new Exception("Já existe um agendamento para este horário");
            }

            agendamento.SalaId = IdSala;
            agendamento.Data = Data;
            //agendamento.IdProcedimento = IdProcedimento;

            return agendamento;
        }
        public static Agendamento ExcluirAgendamento(
            int Id
        )
        {
            Agendamento agendamento = GetAgendamento(Id);
            Agendamento.RemoverAgendamento(agendamento);
            return agendamento;
        }
        public static List<Agendamento> VisualizarAgendamentos()
        {
            return Agendamento.GetAgendamentos();
        }
        public static Agendamento GetAgendamento(
            int Id
        )
        {
            Agendamento agendamento = (
                from Agendamento in Agendamento.GetAgendamentos()
                    where Agendamento.Id == Id
                    select Agendamento
            ).First();

            if (agendamento == null)
            {
                throw new Exception("Agendamento não encontrado.");
            }

            return agendamento;
        }

        public static IEnumerable<Agendamento> GetAgendamentosPorPaciente(int PacienteId)
        {
            return Agendamento.GetAgendamentos()
                .Where(Agendamento => Agendamento.PacienteId == PacienteId);
        }

        public static Agendamento ConfirmarAgendamento(int Id)
        {
            Agendamento agendamento = GetAgendamento(Id);

            if (agendamento.PacienteId != Auth.Paciente.Id)
            {
                throw new Exception("Não é possível confirmar esse agendamento");
            }
            agendamento.Confirmado = true;
            return agendamento;
        }
    }
}