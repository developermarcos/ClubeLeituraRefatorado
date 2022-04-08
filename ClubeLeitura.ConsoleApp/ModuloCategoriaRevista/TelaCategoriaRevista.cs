using ClubeLeitura.ConsoleApp.Compartilhado;
using ClubeLeitura.ConsoleApp.Compartilhado.Interfaces;
using ClubeLeitura.ConsoleApp.ModuloRevista;
using System;

namespace ClubeLeitura.ConsoleApp.ModuloCategoriaRevista
{
    public class TelaCategoriaRevista : TelaBase, ICadastroBasico
    {
        public RepositorioCategoriaRevista repositorioCategoriaRevista;
        public TelaRevista telaRevista;
        public Notificador notificador;
        
        public TelaCategoriaRevista(RepositorioCategoriaRevista repositorioCategoriaRevista, Notificador notificador) : base("Tela Categoria Revista")
        {
            this.repositorioCategoriaRevista=repositorioCategoriaRevista;
            this.notificador=notificador;
        }

        
        public void InserirRegistro()
        {
            MostrarTitulo("Inserindo nova Revista");

            CategoriaRevista categoria = ObterCategoria();

            repositorioCategoriaRevista.Inserir(categoria);

            notificador.ApresentarMensagem("Categoria inserida com sucesso!", TipoMensagem.Sucesso);
        }

        public void EditarRegistro()
        {
            MostrarTitulo("Editando categoria");

            bool temCategoriasCadastradas = VisualizarRegistros("Pesquisando");

            if (temCategoriasCadastradas == false)
            {
                notificador.ApresentarMensagem("Nenhuma categoria cadastrada para poder editar", TipoMensagem.Atencao);
                return;
            }

            int numeroCategoria = ObterNumeroCategoria();

            CategoriaRevista categoria = ObterCategoria();

            repositorioCategoriaRevista.Editar(numeroCategoria, categoria);

            notificador.ApresentarMensagem("Categoria editada com sucesso!", TipoMensagem.Sucesso);
        }

        public void ExcluirRegistro()
        {
            MostrarTitulo("Excluíndo categoria");

            bool temCategoriasCadastradas = VisualizarRegistros("Pesquisando");

            if (temCategoriasCadastradas == false)
            {
                notificador.ApresentarMensagem("Nenhuma categoria cadastrada para poder editar", TipoMensagem.Atencao);
                return;
            }

            int numeroCategoriaExclusao = ObterNumeroCategoria();

            repositorioCategoriaRevista.Excluir(numeroCategoriaExclusao);

            notificador.ApresentarMensagem("Categoria editada com sucesso!", TipoMensagem.Sucesso);
        }

        public bool VisualizarRegistros(string tipo)
        {
            if (tipo == "Tela")
                MostrarTitulo("Visualização de Categorias");

            CategoriaRevista[] categorias = repositorioCategoriaRevista.ObterTodosRegistros();

            if (categorias.Length == 0)
                return false;

            for (int i = 0; i < categorias.Length; i++)
            {
                CategoriaRevista cat = categorias[i];

                Console.WriteLine(cat.ToString());

                Console.WriteLine();
            }

            return true;
        }

        #region métodos privados

        private CategoriaRevista ObterCategoria()
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite a quantidade de dias para empréstimo: ");
            int diasParaDevolver = Convert.ToInt32(Console.ReadLine());

            CategoriaRevista categoria = new CategoriaRevista(nome, diasParaDevolver);
            return categoria;
        }

        private int ObterNumeroCategoria()
        {
            int numeroCategoria;
            bool numeroCategoriaEncontrada;

            do
            {
                Console.Write("Digite o número da categoria: ");
                numeroCategoria = Convert.ToInt32(Console.ReadLine());

                numeroCategoriaEncontrada = repositorioCategoriaRevista.RegistroExiste(numeroCategoria);

                if (numeroCategoriaEncontrada == false)
                    notificador.ApresentarMensagem("Número da categoria não encontrada, digite novamente", TipoMensagem.Atencao);

            } while (numeroCategoriaEncontrada == false);

            return numeroCategoria;
        }

        #endregion
    }
}
