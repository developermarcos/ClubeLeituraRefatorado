using ClubeLeitura.ConsoleApp.ModuloPessoa;
using ClubeLeitura.ConsoleApp.ModuloRevista;
using System;

namespace ClubeLeitura.ConsoleApp.ModuloEmprestimos
{
    public class RepositorioEmprestimo
    {
        public Emprestimo[] emprestimos;
        public static int numeroEmprestimo;

        public RepositorioEmprestimo(Emprestimo[] emprestimos)
        {
            this.emprestimos=emprestimos;
        }

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

        public Emprestimo SelecionarEmprestimo(int numero)
        {
            Emprestimo emprestimo = null;

            for (int i = 0; i < emprestimos.Length; i++)
            {
                if (emprestimos[i] != null && emprestimos[i].numero == numero)
                {
                    Emprestimo emprestimosInseridos = emprestimos[i];
                    return emprestimosInseridos;
                }
            }
            
            return emprestimo;
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

        public bool ExisteEmprestimoCadastrado()
        {
            for (int i = 0; i < emprestimos.Length; i++)
            {
                if (emprestimos[i] != null)
                {
                    return true;
                }
            }
            return false;
        }

        public void Devolucao(Emprestimo emprestimoDevolucao)
        {
            emprestimoDevolucao.devolucao = true;
            for (int i = 0; i < emprestimos.Length; i++)
            {
                if(emprestimos[i].numero == emprestimoDevolucao.numero)
                {
                    emprestimos[i].numero = emprestimoDevolucao.numero;
                    break;
                }
            }
        }

        public void Popular() { }
    }
}
