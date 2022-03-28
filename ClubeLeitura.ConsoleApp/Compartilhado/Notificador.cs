using System;

namespace ClubeLeitura.ConsoleApp.Compartilhado
{
    public class Notificador
    {
        public void ApresentarMensagem(string mensagem, StatusValidacao status)
        {
            switch (status)
            {
                case StatusValidacao.Sucesso:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;

                case StatusValidacao.Atencao:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;

                case StatusValidacao.Erro:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

                default:
                    break;
            }

            Console.WriteLine();
            Console.WriteLine(mensagem);
            Console.ResetColor();
            Console.ReadLine();
        }
    }
}
