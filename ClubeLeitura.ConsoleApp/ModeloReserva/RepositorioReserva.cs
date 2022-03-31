using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp.ModeloReserva
{
    public class RepositorioReserva
    {
        public Reserva[] reservas;
        private static int numeroReserva;

        public RepositorioReserva(Reserva[] reservas)
        {
            this.reservas=reservas;
        }

        public void Inserir(Reserva reservaCadastro)
        {
            reservaCadastro.Numero = ++numeroReserva;

            int posicaoVazia = ObterPosicaoVazia();

            reservas[posicaoVazia] = reservaCadastro;
        }

        public void Editar(int numeroSelecioando, Reserva reserva)
        {
            for (int i = 0; i < reservas.Length; i++)
            {
                if (reservas[i] != null && reservas[i].Numero == numeroSelecioando)
                {
                    reserva.Numero = numeroSelecioando;
                    reservas[i] = reserva;
                    break;
                }
            }
        }

        public void Excluir(int numeroSelecionado)
        {
            for (int i = 0; i < reservas.Length; i++)
            {
                if (reservas[i] != null && reservas[i].Numero == numeroSelecionado)
                {
                    reservas[i] = null;
                    break;
                }
            }
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

        public Reserva[] SelecionarTodos()
        {
            int quantidadeReservas = ObterQtdReservas();

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

        public Reserva SelecionaReserva(int numero)
        {
            
            Reserva reservasInseridos = null;

            for (int i = 0; i < reservas.Length; i++)
            {
                if (reservas[i].Numero == numero)
                    return reservas[i];
            }

            return reservasInseridos = null;
        }

        public int ObterQtdReservas()
        {
            int numeroReservas = 0;

            for (int i = 0; i < reservas.Length; i++)
            {
                if (reservas[i] != null)
                    numeroReservas++;
            }

            return numeroReservas;
        }

        public bool VerificarNumeroReservaExiste(int numeroReserva)
        {
            bool numeroReservaEncontrada = false;

            for (int i = 0; i < reservas.Length; i++)
            {
                if (reservas[i] != null && reservas[i].Numero == numeroReserva)
                {
                    numeroReservaEncontrada = true;
                    break;
                }
            }

            return numeroReservaEncontrada;
        }

        public bool ExisteReservaCadastrada()
        {
            for (int i = 0; i < reservas.Length; i++)
            {
                if (reservas[i] != null)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
