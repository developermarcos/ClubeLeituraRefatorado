using ClubeLeitura.ConsoleApp.Compartilhado;
using ClubeLeitura.ConsoleApp.ModuloRevista;
using System;

namespace ClubeLeitura.ConsoleApp.ModuloCategoriaRevista
{
    public class TelaCategoriaRevista
    {
        public RepositorioCategoriaRevista repositorioCategoriaRevista;
        public TelaRevista telaRevista;
        public Notificador notificador;
        private CategoriaRevista[] categoriaRevistas;

        public TelaCategoriaRevista(RepositorioCategoriaRevista repositorioCategoriaRevista, Notificador notificador)
        {
            this.repositorioCategoriaRevista=repositorioCategoriaRevista;
            this.notificador=notificador;
        }

        public void InserirNovaCategoria()
        {
            MostrarTitulo("Inserindo nova Revista");

            CategoriaRevista categoria = ObterCategoria();

            repositorioCategoriaRevista.Inserir(categoria);

            notificador.ApresentarMensagem("Categoria inserida com sucesso!", StatusValidacao.Sucesso);
        }

        public void EditarCategoria()
        {
            MostrarTitulo("Editando categoria");

            bool temCategoriasCadastradas = VisualizarCategorias("Pesquisando");

            if (temCategoriasCadastradas == false)
            {
                notificador.ApresentarMensagem("Nenhuma categoria cadastrada para poder editar", StatusValidacao.Atencao);
                return;
            }

            int numeroCategoria = ObterNumeroCategoria();

            CategoriaRevista categoria = ObterCategoria();

            repositorioCategoriaRevista.Editar(numeroCategoria, categoria);

            notificador.ApresentarMensagem("Categoria editada com sucesso!", StatusValidacao.Sucesso);
        }

        public void ExcluirCategoria()
        {
            MostrarTitulo("Excluíndo categoria");

            bool temCategoriasCadastradas = VisualizarCategorias("Pesquisando");

            if (temCategoriasCadastradas == false)
            {
                notificador.ApresentarMensagem("Nenhuma categoria cadastrada para poder editar", StatusValidacao.Atencao);
                return;
            }

            int numeroCategoriaExclusao = ObterNumeroCategoria();

            repositorioCategoriaRevista.Excluir(numeroCategoriaExclusao);

            notificador.ApresentarMensagem("Categoria editada com sucesso!", StatusValidacao.Sucesso);
        }

        public bool VisualizarCategorias(string tipo)
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

        public string MostrarOpcoes()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Categorias");

            Console.WriteLine();

            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Editar");
            Console.WriteLine("Digite 3 para Excluir");
            Console.WriteLine("Digite 4 para Visualizar");

            Console.WriteLine("Digite s para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public int ObterNumeroCategoria()
        {
            int numeroCategoria;
            bool numeroCategoriaEncontrada;

            do
            {
                Console.Write("Digite o número da categoria: ");
                numeroCategoria = Convert.ToInt32(Console.ReadLine());

                numeroCategoriaEncontrada = repositorioCategoriaRevista.ExisteNumeroRegistro(numeroCategoria);

                if (numeroCategoriaEncontrada == false)
                    notificador.ApresentarMensagem("Número da categoria não encontrada, digite novamente", StatusValidacao.Atencao);

            } while (numeroCategoriaEncontrada == false);

            return numeroCategoria;
        }

        #region métodos privados

        private void MostrarTitulo(string titulo)
        {
            Console.Clear();

            Console.WriteLine(titulo);

            Console.WriteLine();
        }

        private Revista[] ObterRevistas()
        {
            string[] identificadores = null;
            bool revistaExiste = false;

            telaRevista.VisualizarRevistas("");

            while (revistaExiste == false)
            {
                Console.Write("Informe as revistas que deseja víncular a categoria separadas por ponto e vírgula ';': ");
                identificadores = Console.ReadLine().Split(";");

                for (int i = 0; i < identificadores.Length; i++)
                {
                    int id = Convert.ToInt32(identificadores[i]);
                    if (telaRevista.repositorioRevista.ExisteNumeroRegistro(id) == true)
                        revistaExiste = true;
                    else
                    {
                        notificador.ApresentarMensagem("Algum numero informado não existe!", StatusValidacao.Atencao);
                        revistaExiste = false;
                        break;
                    }
                }
            }

            Revista[] revistas = new Revista[identificadores.Length];

            for (int i = 0; i < revistas.Length; i++)
            {
                int id = Convert.ToInt32(identificadores[i]);
                revistas[i] = telaRevista.repositorioRevista.ObterRegistro(id);
            }

            return revistas;
        }

        private CategoriaRevista ObterCategoria()
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite a quantidade de dias para empréstimo: ");
            int diasParaDevolver = Convert.ToInt32(Console.ReadLine());

            CategoriaRevista categoria = new CategoriaRevista(nome, diasParaDevolver);
            return categoria;
        }

        
        #endregion
    }
}
