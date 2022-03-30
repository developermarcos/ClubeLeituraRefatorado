using ClubeLeitura.ConsoleApp.ModuloRevista;
using System;

namespace ClubeLeitura.ConsoleApp.ModuloCategoriaRevista
{
    public class RepositorioCategoriaRevista
    {
        public CategoriaRevista[] categorias;
        public static int numero;
        
        public RepositorioCategoriaRevista(CategoriaRevista[] categoriaRevistas)
        {
            this.categorias=categoriaRevistas;
        }

        public void Inserir(CategoriaRevista categoria)
        {
            categoria.Numero = ++numero;

            int posicaoVazio = ObterPosicaoVazia();

            categorias[posicaoVazio] = categoria;
        }

        private int ObterPosicaoVazia()
        {
            for (int i = 0; i < categorias.Length; i++)
            {
                if (categorias[i] == null)
                    return i;
            }

            return -1;
        }

        public CategoriaRevista[] SelecionarTodos()
        {
            int quantidadeRevistas = ObterQtdCategorias();

            CategoriaRevista[] categoriasInseridas = new CategoriaRevista[quantidadeRevistas];
            int j = 0;
            for (int i = 0; i < categorias.Length; i++)
            {
                if (categorias[i] != null)
                {
                    categoriasInseridas[j] = categorias[i];
                    j++;
                }
            }

            return categoriasInseridas;
        }

        public int ObterQtdCategorias()
        {
            int numeroCategorias = 0;

            for (int i = 0; i < categorias.Length; i++)
            {
                if (categorias[i] != null)
                    numeroCategorias++;
            }

            return numeroCategorias;
        }
        public bool VerificarNumeroCategoriaExiste(int numeroCategoria)
        {
            bool numeroCategoriaEncontrada = false;

            for (int i = 0; i < categorias.Length; i++)
            {
                if (categorias[i] != null && categorias[i].Numero == numeroCategoria)
                {
                    numeroCategoriaEncontrada = true;
                    break;
                }
            }

            return numeroCategoriaEncontrada;
        }

        public void Editar(CategoriaRevista categoria, int numeroSelecionado)
        {
            for (int i = 0; i < categorias.Length; i++)
            {
                if (categorias[i] != null && categorias[i].Numero == numeroSelecionado)
                {
                    categoria.Numero = numeroSelecionado;
                    categorias[i] = categoria;

                    break;
                }
            }
        }

        public void Excluir(int categoriaExcluir)
        {
            for (int i = 0; i < categorias.Length; i++)
            {
                if (categorias[i] != null && categorias[i].Numero == categoriaExcluir)
                {
                    categorias[i] = null;
                    break;
                }
            }
        }

        public CategoriaRevista ObterCategoria(int idCategoria)
        {
            CategoriaRevista categoria = null;

            for (int i = 0; i < categorias.Length; i++)
            {
                if (categorias[i] != null && categorias[i].Numero == idCategoria)
                {
                    categoria = categorias[i];
                    break;
                }
            }

            return categoria;
        }
    }
}
