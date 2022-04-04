using ClubeLeitura.ConsoleApp.Compartilhado;

namespace ClubeLeitura.ConsoleApp.ModeloReserva
{
    public class RepositorioReserva : RepositorioBase<Reserva>
    {
        public RepositorioReserva(int tamanhoArray) : base(tamanhoArray)
        {
        }

        public void Popular(Reserva reserva) { }
    }
}
