using ClubeLeitura.ConsoleApp.Compartilhado;
using ClubeLeitura.ConsoleApp.ModuloPessoa;
using ClubeLeitura.ConsoleApp.ModuloRevista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp.ModuloEmprestimos
{
    public class TelaEmprestimo
    {
        
        public Notificador notificador; //reponsável pelas mensagens pro usuário
        public RepositorioEmprestimo repositorioEmprestimos;

        public TelaAmigo telaAmigo;
        public RepositorioAmigo repositorioAmigo;

        public TelaRevista telaRevista;
        public RepositorioRevista repositorioRevista;
        private Emprestimo[] emprestimos;
        private RepositorioEmprestimo repositorioEmprestimo;

        public TelaEmprestimo(RepositorioEmprestimo repositorioEmprestimo, TelaAmigo telaAmigo, TelaRevista telaRevista, Notificador notificador)
        {
            this.repositorioEmprestimo=repositorioEmprestimo;
            this.telaAmigo=telaAmigo;
            this.telaRevista=telaRevista;
            this.notificador=notificador;
        }

        public string MostrarOpcoes()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Empréstimos");

            Console.WriteLine();

            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Editar");
            Console.WriteLine("Digite 3 para Excluir");
            Console.WriteLine("Digite 4 para Visualizar");

            Console.WriteLine("Digite s para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public void InserirNovoEmprestimo()
        {
            MostrarTitulo("Inserindo novo empréstimo");

            bool existeAmigosCadastrados = telaAmigo.VisualizarAmigos("Pesquisando");

            if (!existeAmigosCadastrados)
            {
                notificador.ApresentarMensagem("Não existe amigos cadastrados!", StatusValidacao.Atencao);
                return;
            }

            int idAmigo = telaAmigo.ObterNumeroAmigo();

            Amigo amigoEmprestimo = repositorioAmigo.ObterAmigo(idAmigo);

            bool existeRevistasCadastradas = telaRevista.VisualizarRevistas("Pesquisando");

            if (!existeRevistasCadastradas)
            {
                notificador.ApresentarMensagem("Não existe revistas cadastradas!", StatusValidacao.Atencao);
                return;
            }

            int idRevista = telaRevista.ObterNumeroRevista();

            Revista revistaEmprestimo = repositorioRevista.ObterRevistaPorNumero(idRevista);

            Emprestimo emprestimoCadastro = ObterEmprestimo(amigoEmprestimo, revistaEmprestimo);


            repositorioEmprestimos.Inserir(emprestimoCadastro);

            notificador.ApresentarMensagem("Empréstimo inserido com sucesso!", StatusValidacao.Sucesso);
        }

        public void EditarEmprestimo()
        {
            MostrarTitulo("Editando Empréstimo");

            bool temeEmprestimosCadastrados = VisualizarEmprestimos("Pesquisando");

            if (temeEmprestimosCadastrados == false)
            {
                notificador.ApresentarMensagem("Nenhum emprétimo cadastrado para poder editar", StatusValidacao.Atencao);
                return;
            }

            int numeroEmprestimo = ObterNumeroEmprestimo();

            int idAmigo = telaAmigo.ObterNumeroAmigo();

            Amigo amigoEmprestimo = repositorioAmigo.ObterAmigo(idAmigo);

            bool existeRevistasCadastradas = telaRevista.VisualizarRevistas("Pesquisando");

            if (!existeRevistasCadastradas)
            {
                notificador.ApresentarMensagem("Não existe emprétimos cadastrados!", StatusValidacao.Atencao);
                return;
            }

            int idRevista = telaRevista.ObterNumeroRevista();

            Revista revistaEmprestimo = repositorioRevista.ObterRevistaPorNumero(idRevista);

            Emprestimo emprestimoCadastro = ObterEmprestimo(amigoEmprestimo, revistaEmprestimo);

            repositorioEmprestimos.Editar(numeroEmprestimo, emprestimoCadastro);

            notificador.ApresentarMensagem("Empréstimo editado com sucesso!", StatusValidacao.Sucesso);
        }

        public void ExcluirEmprestimo()
        {
            MostrarTitulo("Excluindo emprétimo");

            bool temEmprestimosCadastrados = VisualizarEmprestimos("Pesquisando");

            if (temEmprestimosCadastrados == false)
            {
                notificador.ApresentarMensagem("Nenhum emprétimos cadastrado para poder excluir", StatusValidacao.Atencao);
                return;
            }

            int numeroEmprestimo = ObterNumeroEmprestimo();

            repositorioEmprestimos.Excluir(numeroEmprestimo);

            notificador.ApresentarMensagem("Empréstimo excluído com sucesso", StatusValidacao.Sucesso);
        }

        public bool VisualizarEmprestimos(string tipo)
        {
            if (tipo == "Tela")
                MostrarTitulo("Visualização de empréstimos");

            if (!repositorioEmprestimo.ExisteEmprestimoCadastrado())
                return false;

            Emprestimo[] emprestimos = repositorioEmprestimos.SelecionarTodos();

            if (emprestimos.Length == 0)
                return false;

            for (int i = 0; i < emprestimos.Length; i++)
            {
                Emprestimo e = emprestimos[i];

                Console.WriteLine("Número: " + e.Numero);
                Console.WriteLine("Data empréstimo: " + e.EmprestimoData);
                Console.WriteLine("Amigo: {0} | telefone: {1}", e.Amigo.Nome, e.Amigo.Telefone);
                Console.WriteLine("Revista edição: {0} | tipo coleção: {1}", e.Revista.NumeroEdicao, e.Revista.TipoColecao);
                
                Console.WriteLine();
            }

            return true;
        }

        #region métodos privados
        private void MostrarTitulo(string titulo)
        {
            Console.Clear();

            Console.WriteLine(titulo);

            Console.WriteLine();
        }

        private Emprestimo ObterEmprestimo(Amigo amigoEmprestimo, Revista revistaEmprestimo)
        {
            Amigo amigo;
            Revista revista;
            DateTime emprestimoData;

            while (true)
            {
                Console.WriteLine("Informe a data do empréstimo (ex: 00/00/0000): ");
                string dataEmprestimo = Console.ReadLine();
                bool conversaoRealizada = DateTime.TryParse(dataEmprestimo, out DateTime dataCadastro);
                if (dataEmprestimo.Length == 10 && conversaoRealizada == true)
                {
                    amigo = amigoEmprestimo;
                    revista = revistaEmprestimo;
                    emprestimoData = dataCadastro;
                    break;
                }
                else
                    notificador.ApresentarMensagem("Data não foi informada no padrão solicitado", StatusValidacao.Atencao);
            }
            Emprestimo emprestimo = new Emprestimo(amigoEmprestimo, revistaEmprestimo, emprestimoData);
            return emprestimo;
        }

        private int ObterNumeroEmprestimo()
        {
            int numeroEmprestimo;
            bool numeroEmprestimoEncontrado;

            do
            {
                Console.Write("Digite o número do empréstimo que deseja editar: ");
                numeroEmprestimo = Convert.ToInt32(Console.ReadLine());

                numeroEmprestimoEncontrado = repositorioEmprestimos.VerificarNumeroEmprestimoExiste(numeroEmprestimo);

                if (numeroEmprestimoEncontrado == false)
                    notificador.ApresentarMensagem("Número do empréstimo não encontrado, digite novamente", StatusValidacao.Atencao);

            } while (numeroEmprestimoEncontrado == false);

            return numeroEmprestimo;
        }
        #endregion
    }
}
