using ClubeLeitura.ConsoleApp.Compartilhado;

namespace ClubeLeitura.ConsoleApp.ModeloReserva
{
    public class RepositorioReserva : IRepositoryBase<Reserva>
    {
        public Reserva[] reservas;
        private static int numeroReserva;

        public RepositorioReserva(Reserva[] reservas)
        {
            this.reservas=reservas;
        }

        public void Inserir(Reserva reservaCadastro)
        {
            reservaCadastro.numero = ObterNumeroRegistro();

            int posicaoVazia = ObterPosicaoVazia();

            reservas[posicaoVazia] = reservaCadastro;
        }

        public void Editar(int numeroSelecioando, Reserva reserva)
        {
            for (int i = 0; i < reservas.Length; i++)
            {
                if (reservas[i] != null && reservas[i].numero == numeroSelecioando)
                {
                    reserva.numero = numeroSelecioando;
                    reservas[i] = reserva;
                    break;
                }
            }
        }

        public Reserva[] ObterTodosRegistros()
        {
            int quantidadeReservas = ObterQuantidadeRegistros();

            Reserva[] reservasInseridos = new Reserva[quantidadeReservas];
            int j = 0;
            for (int i = 0; i < reservas.Length; i++)
            {
                if (reservas[i] != null)
                {
                    reservasInseridos[j] = reservas[i];
                    j++;
                }
            }

            return reservasInseridos;
        }

        public void Excluir(int numeroSelecionado)
        {
            for (int i = 0; i < reservas.Length; i++)
            {
                if (reservas[i] != null && reservas[i].numero == numeroSelecionado)
                {
                    reservas[i] = null;
                    break;
                }
            }
        }

        public Reserva ObterRegistro(int numero)
        {

            Reserva reservasInseridos = null;

            for (int i = 0; i < reservas.Length; i++)
            {
                if (reservas[i].numero == numero)
                    return reservas[i];
            }

            return reservasInseridos = null;
        }

        public bool ExisteNumeroRegistro(int numeroReserva)
        {
            bool numeroReservaEncontrada = false;

            for (int i = 0; i < reservas.Length; i++)
            {
                if (reservas[i] != null && reservas[i].numero == numeroReserva)
                {
                    numeroReservaEncontrada = true;
                    break;
                }
            }

            return numeroReservaEncontrada;
        }

        public int ObterPosicaoVazia()
        {
            for (int i = 0; i < reservas.Length; i++)
            {
                if (reservas[i] == null)
                    return i;
            }

            return -1;
        }

        public int ObterQuantidadeRegistros()
        {
            int numeroReservas = 0;

            for (int i = 0; i < reservas.Length; i++)
            {
                if (reservas[i] != null)
                    numeroReservas++;
            }

            return numeroReservas;
        }

        public void Popular(Reserva reserva) { }

        #region método internos
        public int ObterNumeroRegistro()
        {
            return ++numeroReserva;
        }

        #endregion
    }
}
