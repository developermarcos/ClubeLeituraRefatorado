using ClubeLeitura.ConsoleApp.ModuloPessoa;
using ClubeLeitura.ConsoleApp.ModuloRevista;
using System;

namespace ClubeLeitura.ConsoleApp.ModuloEmprestimos
{
    internal class RepositorioEmprestimo
    {
        public Emprestimo[] emprestimos;
        public int numeroEmprestimo;

        public void Inserir(Emprestimo emprestimoCadastro)
        {
            emprestimoCadastro.numero = ++numeroEmprestimo;

            int posicaoVazia = ObterPosicaoVazia();

            emprestimos[posicaoVazia] = emprestimoCadastro;
        }
        
        public void Editar(int numeroSelecioando, Emprestimo emprestimo)
        {
            for (int i = 0; i < emprestimos.Length; i++)
            {
                if (emprestimos[i] != null && emprestimos[i].numero == numeroSelecioando)
                {
                    emprestimo.numero = numeroSelecioando;
                    emprestimos[i] = emprestimo;

                    break;
                }
            }
        }

        public void Excluir(int numeroSelecionado)
        {
            for (int i = 0; i < emprestimos.Length; i++)
            {
                if (emprestimos[i] != null && emprestimos[i].numero == numeroSelecionado)
                {
                    emprestimos[i] = null;
                    break;
                }
            }
        }

        public int ObterPosicaoVazia()
        {
            for (int i = 0; i < emprestimos.Length; i++)
            {
                if (emprestimos[i] == null)
                    return i;
            }

            return -1;
        }

        public Emprestimo[] SelecionarTodos()
        {
            int quantidadeEmprestimos = ObterQtdEmprestimos();

            Emprestimo[] emprestimosInseridos = new Emprestimo[quantidadeEmprestimos];
            int j = 0;
            for (int i = 0; i < emprestimos.Length; i++)
            {
                if (emprestimos[i] != null)
                {
                    emprestimosInseridos[j] = emprestimos[i];
                    j++;
                }
            }

            return emprestimosInseridos;
        }

        public int ObterQtdEmprestimos()
        {
            int numeroEmprestimos = 0;

            for (int i = 0; i < emprestimos.Length; i++)
            {
                if (emprestimos[i] != null)
                    numeroEmprestimos++;
            }

            return numeroEmprestimos;
        }

        public bool VerificarNumeroEmprestimoExiste(int numeroEmprestimo)
        {
            bool numeroEmprestimoEncontrado = false;

            for (int i = 0; i < emprestimos.Length; i++)
            {
                if (emprestimos[i] != null && emprestimos[i].numero == numeroEmprestimo)
                {
                    numeroEmprestimoEncontrado = true;
                    break;
                }
            }

            return numeroEmprestimoEncontrado;
        }

    }
}
