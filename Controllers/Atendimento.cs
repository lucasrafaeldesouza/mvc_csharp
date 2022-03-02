using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Controllers
{
    public class AtendimentoController
    {
        public static Atendimento InserirAtendimento(
            int IdProcedimento,
            int IdAgendamento
        )
        {
            ProcedimentoController.GetProcedimento(IdProcedimento);
            AgendamentoController.GetAgendamento(IdAgendamento);
            //Procedimento procedimento = Procedimento.GetProcedimento(IdProcedimento);
            return new Atendimento(IdProcedimento, IdAgendamento);
        }

        public static Atendimento ExcluirAtendimento(
           int Id
       )

        {
            Atendimento atendimento = GetAtendimento(Id);
            Atendimento.RemoverAtendimento(atendimento);
            return atendimento;
        }

        public static List<Atendimento> VisualizarAtendimentos()
        {
            return Atendimento.GetAtendimentos();
        }
        public static Atendimento GetAtendimento(
            int Id
        )
        {
            Atendimento atendimento = (
                    from Atendimento in Atendimento.GetAtendimentos()
                    where Atendimento.Id == Id
                    select Atendimento
            ).First();

            if (atendimento == null)
            {
                throw new Exception("Atendimento não encontrado.");
            }

            return atendimento;

        }
    }
}
