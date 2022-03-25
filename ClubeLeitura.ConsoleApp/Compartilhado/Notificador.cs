using System;

namespace ClubeLeitura.ConsoleApp.Compartilhado
{
    public class Notificador
    {
        public void ApresentarMensagem(string mensagem, StatusValicao status)
        {
            switch (status)
            {
                case StatusValicao.Sucesso:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;

                case StatusValicao.Atencao:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;

                case StatusValicao.Erro:
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
