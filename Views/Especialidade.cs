using System;
using Controllers;
using Models;

namespace Views
{
    public class EspecialidadeView
    {
        public static void InserirEspecialidade()
        {
            Console.WriteLine("Digite o Id da Especialidade: ");
            int Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a Descricao do procedimento: ");
            string Descricao = Console.ReadLine();
            Console.WriteLine("Digite a tarefa do procedimento: ");
            string Tarefa = Console.ReadLine();

            EspecialidadeController.InserirEspecialidade(
                Id,
                Descricao,
                Tarefa
            );
        }

        public static void AlterarEspecialidade()
        {
            Console.WriteLine("Digite o Id da Especialidade: ");
            int Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a Descricao do procedimento: ");
            string Descricao = Console.ReadLine();
            Console.WriteLine("Digite a tarefa do procedimento: ");
            string Tarefa = Console.ReadLine();

            EspecialidadeController.AlterarEspecialidade(
                Id,
                Descricao,
                Tarefa
            );

        }

        public static void ExcluirEspecialidade()
        {
            int Id = 0;
            Console.WriteLine("Digite o ID da Especialidade: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }

            EspecialidadeController.ExcluirEspecialidade(
                Id
            );

        }

        public static void ListarEspecialidade()
        {
            foreach (Especialidade item in EspecialidadeController.VisualizarEspecialidade())
            {
                Console.WriteLine(item);
            }
        }
    }
}