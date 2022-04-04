using System;
using ClubeLeitura.ConsoleApp.Compartilhado;
using ClubeLeitura.ConsoleApp.ModuloCaixa;
using ClubeLeitura.ConsoleApp.ModuloCategoriaRevista;

namespace ClubeLeitura.ConsoleApp.ModuloRevista
{
    public class TelaRevista
    {
        public int numeroCaixa; //controlar o número da caixas cadastradas
        public Notificador notificador; //reponsável pelas mensagens pro usuário
        public RepositorioRevista repositorioRevista;
        private Revista[] revistas;

        public TelaCaixa telaCaixa;
        //public RepositorioCaixa repositorioCaixa;

        private TelaCategoriaRevista telaCategoria;

        public TelaRevista(RepositorioRevista repositorioRevista, TelaCaixa telaCaixa, TelaCategoriaRevista telaCategoriaRevista, Notificador notificador)
        {
            this.repositorioRevista=repositorioRevista;
            this.telaCaixa=telaCaixa;
            this.notificador=notificador;
            this.telaCategoria = telaCategoriaRevista;
        }

        public string MostrarOpcoes()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Revistas");

            Console.WriteLine();

            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Editar");
            Console.WriteLine("Digite 3 para Excluir");
            Console.WriteLine("Digite 4 para Visualizar");

            Console.WriteLine("Digite s para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public void InserirNovaRevista()
        {
            MostrarTitulo("Inserindo nova Revista");

            bool existeCategoriaCadastrada = telaCategoria.VisualizarCategorias("pesquisando");

            if (!existeCategoriaCadastrada)
            {
                notificador.ApresentarMensagem("Não existe categorias cadastradas!", StatusValidacao.Atencao);
                return;
            }

            int numeroCategoria = telaCategoria.ObterNumeroCategoria();
            CategoriaRevista categoria = (CategoriaRevista)telaCategoria.repositorioCategoriaRevista.ObterRegistro(numeroCategoria);

            bool existeCaixasCadastradas = telaCaixa.VisualizarCaixas("Pesquisando");

            if (!existeCaixasCadastradas)
            {
                notificador.ApresentarMensagem("Não existe caixas cadastradas!", StatusValidacao.Atencao);
                return;
            }
            
            
            Caixa caixa = ObterCaixa();

            Revista novaRevista = ObterRevista(caixa, categoria);

            repositorioRevista.Inserir(novaRevista);

            notificador.ApresentarMensagem("Revista inserida com sucesso!", StatusValidacao.Sucesso);
        }

        public void EditarRevista()
        {
            MostrarTitulo("Editando Caixa");

            bool temRevistasCadastradas = VisualizarRevistas("Pesquisando");

            if (temRevistasCadastradas == false)
            {
                notificador.ApresentarMensagem("Nenhuma revista cadastrada para poder editar", StatusValidacao.Atencao);
                return;
            }

            int numeroRevista = ObterNumeroRevista();

            bool existeCategoriaCadastrada = telaCategoria.VisualizarCategorias("pesquisando");

            if (!existeCategoriaCadastrada)
            {
                notificador.ApresentarMensagem("Não existe categorias cadastradas!", StatusValidacao.Atencao);
                return;
            }

            int numeroCategoria = telaCategoria.ObterNumeroCategoria();
            CategoriaRevista categoria = (CategoriaRevista)telaCategoria.repositorioCategoriaRevista.ObterRegistro(numeroCategoria);


            bool existeCaixasCadastradas = telaCaixa.VisualizarCaixas("Pesquisando");

            if (!existeCaixasCadastradas)
            {
                notificador.ApresentarMensagem("Não existe caixas cadastradas!", StatusValidacao.Atencao);
                return;
            }

            Caixa caixaAtualizada = ObterCaixa();

            Revista revistaAtualizada = ObterRevista(caixaAtualizada, categoria);

            repositorioRevista.Editar(numeroRevista, revistaAtualizada);

            notificador.ApresentarMensagem("Caixa editada com sucesso", StatusValidacao.Sucesso);
        }

        public void ExcluirRevista()
        {
            MostrarTitulo("Excluindo revista");

            bool temRevistasCadastradas = VisualizarRevistas("Pesquisando");

            if (temRevistasCadastradas == false)
            {
                notificador.ApresentarMensagem("Nenhuma revista cadastrada para poder excluir", StatusValidacao.Atencao);
                return;
            }

            int numeroRevista = ObterNumeroRevista();

            repositorioRevista.Excluir(numeroRevista);

            notificador.ApresentarMensagem("Revista excluída com sucesso", StatusValidacao.Sucesso);
        }

        public int ObterNumeroRevista()
        {
            int numeroRevista;
            bool numeroRevistaEncontrado;

            do
            {
                Console.Write("Digite o número da revista: ");
                numeroRevista = Convert.ToInt32(Console.ReadLine());

                numeroRevistaEncontrado = repositorioRevista.ExisteNumeroRegistro(numeroRevista);

                if (numeroRevistaEncontrado == false)
                    notificador.ApresentarMensagem("Número da revista não encontrado, digite novamente", StatusValidacao.Atencao);

            } while (numeroRevistaEncontrado == false);

            return numeroRevista;
        }

        public Caixa ObterCaixa()
        {
            Caixa caixa = null;
            bool caixaExiste;
                        
            do
            {
                Console.Write("Informe a caixa para armazenar a revista: ");
                int numeroCaixa = Convert.ToInt32(Console.ReadLine());
                caixaExiste = telaCaixa.repositorioCaixa.ExisteNumeroRegistro(numeroCaixa);
                caixa = null;
                if (caixaExiste)
                    caixa = (Caixa)telaCaixa.repositorioCaixa.ObterRegistro(numeroCaixa);
                else
                    notificador.ApresentarMensagem("Caixa não encontrada, informe novamente", StatusValidacao.Atencao);

            } while (!caixaExiste);

            return caixa;
        }

        public Revista ObterRevista(Caixa caixa , CategoriaRevista categoria)
        {
            Console.Write("Digite o tipo da coleção: ");
            string tipoColecao = Console.ReadLine();

            Console.Write("Digite o numero da edição: ");
            string numeroEdicao = Console.ReadLine();

            Console.Write("Digite o ano: ");
            string ano = Console.ReadLine();

            Revista revista = new Revista(tipoColecao, numeroEdicao, ano, caixa, categoria);

            return revista;
        }

        public bool VisualizarRevistas(string tipo)
        {
            if (tipo == "Tela")
                MostrarTitulo("Visualização de Revistas");

            Revista[] revistas = (Revista[])repositorioRevista.ObterTodosRegistros();

            if (revistas.Length == 0)
                return false;

            for (int i = 0; i < revistas.Length; i++)
            {
                Revista r = revistas[i];

                Console.WriteLine();

                Console.WriteLine(r.ToString());
                Console.WriteLine("Categoria: {0}", r.categoria.nome);
                
                Console.WriteLine();
            }

            return true;
        }

        public void MostrarTitulo(string titulo)
        {
            Console.Clear();

            Console.WriteLine(titulo);

            Console.WriteLine();
        }
        
    }
}
