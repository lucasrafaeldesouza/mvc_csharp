using System;
using Views;
using Controllers;
using Models;

namespace ConsultorioOdontologico
{
    public class Program
    {
        public static string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter)
            {
                if (info.Key != ConsoleKey.Backspace)
                {
                    Console.Write("*");
                    password += info.KeyChar;
                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(password))
                    {
                        // remove one character from the list of password characters
                        password = password.Substring(0, password.Length - 1);
                        // get the location of the cursor
                        int pos = Console.CursorLeft;
                        // move the cursor to the left by one character
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                        // replace it with space
                        Console.Write(" ");
                        // move the cursor to the left by one character again
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                    }
                }
                info = Console.ReadKey(true);
            }

            // add a new line because user pressed enter at the end of their password
            Console.WriteLine();
            return password;
        }

        public static void Main(string[] args)
        {
            //DentistaController.InserirDentista("José do Carmo", "111.111.111-11", "47 99999-9999", "jose.carmo@dentista.com", "123456", "12345/SC", 15000, "Ortodontia");
            //PacienteController.InserirPaciente("Amélia da Silva", "111.111.111-11", "47 88888-8888", "amelia.silva@paciente.com", "123456", Convert.ToDateTime("1990-01-01"));
            //SalaController.IncluirSala("B135", "RaioX");
            //MenuPrincipal();

            do
            {
                Console.WriteLine("Informe o usuário: ");
                string Email = Console.ReadLine();
                Console.WriteLine("Informe a senha: ");
                string Senha = ReadPassword();
                
                try
                {
                    Auth.Login(Email, Senha);
                    if (Auth.Dentista != null) {
                        MenuPrincipal();
                    }
                    if (Auth.Paciente != null) {
                        MenuPaciente();
                    }
                    Auth.Logout();
                }
                catch (Exception err)
                {
                    Console.WriteLine(err);
                }
            } while (!Auth.isLogeed);
        }

        public static void MenuPaciente()
        {
            Console.WriteLine($" ============= BEM VINDO PACIENTE {Auth.Paciente.Nome} ============ ");
            Console.WriteLine("+------------------------------------+");
            Console.WriteLine("| Operação | Descrição               |");
            Console.WriteLine("|----------|-------------------------|");
            Console.WriteLine("|    0     | Sair                    |");
            Console.WriteLine("|    1     | Visualizar Agendamentos |");
            Console.WriteLine("|    2     | Confirmar Agendamentos  |");
            Console.WriteLine("+------------------------------------+");
            int opt = 0;

            do
            {
                Console.WriteLine("Digite a operação: ");
                try
                {
                    opt = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    opt = 99;
                }
                switch (opt)
                {
                    case 0:
                        Console.WriteLine("Obrigado por utilizar o sistema");
                        break;
                    case 1:
                        AgendamentoView.GetAgendamentosPorPaciente(Auth.Paciente.Id);
                        break;
                    case 2:
                        AgendamentoView.ConfirmarAgendamento();
                        break;
                    default:
                        Console.WriteLine("Operação inválida");
                        break;
                }  
            } while(opt != 0);
        }

        public static void MenuPrincipal()
        {
           Console.WriteLine("<============== BEM VINDO ==============>");
            Console.WriteLine("+---------------------------------------+");
            Console.WriteLine("| Operação | Descrição                  |");
            Console.WriteLine("|----------|----------------------------|");
            Console.WriteLine("| 0        | Sair                       |"); // FEITO
            Console.WriteLine("| 1        | Incluir Dentista           |"); // FEITO
            Console.WriteLine("| 2        | Incluir Paciente           |"); // FEITO
            Console.WriteLine("| 3        | Incluir Sala               |"); // FEITO
            Console.WriteLine("| 4        | Incluir Agendamento        |"); // FEITO
            Console.WriteLine("| 5        | Incluir Atendimento        |"); // FEITO
            Console.WriteLine("| 6        | Incluir Especialidade      |"); // FEITO
            Console.WriteLine("| 7        | Incluir Procedimento       |"); // 
            Console.WriteLine("| 8        | Alterar Dentista           |"); // 
            Console.WriteLine("| 9        | Alterar Paciente           |"); //
            Console.WriteLine("| 10       | Alterar Sala               |"); //
            Console.WriteLine("| 11       | Alterar Agendamento        |"); //
            Console.WriteLine("| 12       | Alterar Especialidade      |"); //
            Console.WriteLine("| 13       | Alterar Procedimento       |"); //
            Console.WriteLine("| 14       | Excluir Dentista           |"); //
            Console.WriteLine("| 15       | Excluir Paciente           |"); //
            Console.WriteLine("| 16       | Excluir Sala               |"); //
            Console.WriteLine("| 17       | Excluir Agendamento        |"); //
            Console.WriteLine("| 18       | Excluir Atendimento        |"); //
            Console.WriteLine("| 19       | Excluir Especialidade      |"); //
            Console.WriteLine("| 20       | Excluir Procedimento       |"); //
            Console.WriteLine("| 21       | Visualizar Dentistas       |"); // FEITO
            Console.WriteLine("| 22       | Visualizar Pacientes       |"); // FEITO
            Console.WriteLine("| 23       | Visualizar Salas           |"); // FEITO
            Console.WriteLine("| 24       | Visualizar Agendamentos    |"); // FEITO
            Console.WriteLine("| 25       | Visualizar Atendimentos    |"); // FEITO
            Console.WriteLine("| 26       | Visualizar Especialidades  |"); // FEITO
            Console.WriteLine("| 27       | Visualizar Procedimentos   |"); //
            Console.WriteLine("+---------------------------------------+");

            int opt = 0;

            do
            {
                try
                {
                    Console.WriteLine("Digite a operação: ");
                    opt = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    opt = 99;
                }
                try{
                    switch (opt)
                    {
                        case 0:
                        {
                            Console.WriteLine("Obrigado por utilizar o sistema!");
                            break;
                        }
                        case 1:
                        {
                            DentistaView.InserirDentista();
                            break;
                        }
                        case 2:
                        {
                            PacienteView.InserirPaciente();
                            break;
                        }
                        case 3:
                        {
                            SalaView.InserirSala();
                            break;
                        }
                        case 4:
                        {
                            AgendamentoView.InserirAgendamento();
                            break;
                        }
                        case 5:
                        {
                            AtendimentoView.InserirAtendimento();
                            break;
                        }
                        case 6:
                        {
                            EspecialidadeView.InserirEspecialidade();
                            break;
                        }
                        case 7:
                        {
                            ProcedimentoView.InserirProcedimento();
                            break;
                        }
                        case 8:
                        {
                            DentistaView.AlterarDentista();
                            break;
                        }
                        case 9:
                        {
                            PacienteView.AlterarPaciente();
                            break;
                        }
                        case 10:
                        {
                            SalaView.AlterarSala();
                            break;
                        }
                        case 11:
                        {
                            AgendamentoView.AlterarAgendamento();
                            break;
                        }
                        case 12:
                        {
                            EspecialidadeView.AlterarEspecialidade();
                            break;
                        }
                        case 13:
                        {
                            ProcedimentoView.AlterarProcedimento();
                            break;
                        }
                        case 14:
                        {
                            DentistaView.ExcluirDentista();
                            break;
                        }
                        case 15:
                        {
                            PacienteView.ExcluirPaciente();
                            break;
                        }
                        case 16:
                        {
                            SalaView.ExcluirSala();
                            break;
                        }
                        case 17:
                        {
                            AgendamentoView.ExcluirAgendamento();
                            break;
                        }
                        case 18:
                        {
                            AtendimentoView.ExcluirAgendamento();
                            break;
                        }
                        case 19:
                        {
                            EspecialidadeView.ExcluirEspecialidade();
                            break;
                        }
                        case 20:
                        {
                            ProcedimentoView.ExcluirProcedimento();
                            break;
                        }
                        case 21:
                        {
                            DentistaView.ListarDentistas();
                            break;
                        }
                        case 22:
                        {
                            PacienteView.ListarPacientes();
                            break;
                        }
                        case 23:
                        {
                            SalaView.ListarSalas();
                            break;
                        }
                        case 24:
                        {
                            AgendamentoView.ListarAgendamentos();
                            break;
                        }
                        case 25:
                        {
                            AtendimentoView.ListarAtendimentos();
                            break;
                        }
                        case 26:
                        {
                            EspecialidadeView.ListarEspecialidade();
                            break;
                        }
                        case 27:
                        {
                            ProcedimentoView.ListarProcedimento();
                            break;
                        }
                        default:
                        {
                            Console.WriteLine("Operação inválida");
                            break;
                        }
                    }
                } 
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                    opt = 99;
                }
            } while (opt != 0);
        }
    }
}
