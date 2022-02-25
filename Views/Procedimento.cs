using System;
using Controllers;
using Models;

namespace Views
{
    public class ProcedimentoView
    {
        public static void InserirProcedimento()
        {
            Console.WriteLine("Digite o Id do Procedimento: ");
            int Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a Descricao do procedimento: ");
            string Descricao = Console.ReadLine();
            Console.WriteLine("Digite o preço do procedimento: ");
            double Preco = double.Parse(Console.ReadLine());
            try
            {
                Preco = Convert.ToDouble(Console.ReadLine());
            }
            catch
            {
                throw new Exception("Preço inválido.");
            }


            ProcedimentoController.InserirProcedimento(
                Id,
                Descricao,
                Preco
            );
        }

        public static void AlterarProcedimento()
        {
            Console.WriteLine("Digite o Id do Procedimento: ");
            int Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a Descricao do procedimento ");
            string Descricao = Console.ReadLine();
            Console.WriteLine("Digite o preço do procedimento: ");
            double Preco = double.Parse(Console.ReadLine());
            try
            {
                Preco = Convert.ToDouble(Console.ReadLine());
            }
            catch
            {
                throw new Exception("Salário inválido.");
            }

            ProcedimentoController.AlterarProcedimento(
                Id,
                Descricao,
                Preco
            );

        }

        public static void ExcluirProcedimento()
        {
            int Id = 0;
            Console.WriteLine("Digite o ID do procedimento: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }

            ProcedimentoController.ExcluirProcedimento(
                Id
            );

        }

        public static void ListarProcedimento()
        {
            foreach (Procedimento item in ProcedimentoController.VisualizarProcedimento())
            {
                Console.WriteLine(item);
            }
        }
    }
}