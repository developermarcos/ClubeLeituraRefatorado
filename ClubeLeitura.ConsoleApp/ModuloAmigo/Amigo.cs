using System.Collections.Generic;
using ClubeLeitura.ConsoleApp.ModuloMulta;
using ClubeLeitura.ConsoleApp.ModuloEmprestimo;
using ClubeLeitura.ConsoleApp.ModuloReserva;

namespace ClubeLeitura.ConsoleApp.ModuloPessoa
{
    public class Amigo : Pessoa
    {
        public readonly string responsavel;
        public Multa multa;
        private readonly List<Emprestimo> historicoEmprestimos;
        private readonly List<Reserva> historicoReservas;


        public Amigo(string nome, string responsavel, string telefone, string endereco)
        {
            this.nome = nome;
            this.responsavel = responsavel;
            this.telefone = telefone;
            this.endereco = endereco;
        }
        public Amigo(int numero, string nome, string responsavel, string telefone, string endereco)
        {
            this.numero = numero;
            this.nome = nome;
            this.responsavel = responsavel;
            this.telefone = telefone;
            this.endereco = endereco;
        }
        
        public override string ToString()
        {
            string mensagem = base.ToString();
            mensagem += $" | Responsavel {this.responsavel}";
            return mensagem;
        }

        public void RegistrarEmprestimo(Emprestimo emprestimo)
        {
            historicoEmprestimos.Add(emprestimo);
        }

        public void RegistrarReserva(Reserva reserva)
        {
            historicoReservas.Add(reserva);
        }

        public bool TemReservaEmAberto()
        {
            bool temReservaEmAberto = false;

            foreach (Reserva reserva in historicoReservas)
            {
                if (reserva != null && reserva.ativo == true)
                {
                    temReservaEmAberto = true;
                    break;
                }
            }

            return temReservaEmAberto;
        }

        public bool TemEmprestimoEmAberto()
        {
            bool temEmprestimoEmAberto = false;

            foreach (Emprestimo emprestimo in historicoEmprestimos)
            {
                if (emprestimo != null && emprestimo.ativo == true)
                {
                    temEmprestimoEmAberto = true;
                    break;
                }
            }
            return temEmprestimoEmAberto;
        }

        public void RegistrarMulta(decimal valor)
        {
            Multa novaMulta = new Multa(valor);
        }

        public void PagarMulta()
        {
            if (multa != null)
                multa = null;
        }

        public bool TemMultaEmAberto()
        {
            if (multa == null)
                return false;

            return true;
        }
    }
}
