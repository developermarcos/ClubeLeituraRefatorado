using ClubeLeitura.ConsoleApp.Compartilhado;
using ClubeLeitura.ConsoleApp.ModeloReserva;
using ClubeLeitura.ConsoleApp.ModuloMulta;
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
        
        private Notificador notificador;
        private TelaAmigo telaAmigo;
        private TelaRevista telaRevista;
        private RepositorioEmprestimo repositorioEmprestimo;
        public RepositorioMulta repositorioMulta;

        public TelaEmprestimo(RepositorioEmprestimo repositorioEmprestimo, TelaAmigo telaAmigo, TelaRevista telaRevista, Notificador notificador)
        {
            this.repositorioEmprestimo=repositorioEmprestimo;
            this.telaAmigo=telaAmigo;
            this.telaRevista=telaRevista;
            this.notificador=notificador;
            this.repositorioMulta = null;
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
            Console.WriteLine("Digite 5 para Devolução");

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

            if (repositorioMulta.ExisteNumeroRegistro(idAmigo))
            {
                notificador.ApresentarMensagem("Não é possível realizar um novo empréstimo, pois o amigo possui multa em aberto.", StatusValidacao.Atencao);
                return;
            }

            Amigo amigoEmprestimo = telaAmigo.repositorioAmigo.ObterRegistro(idAmigo);

            bool existeRevistasCadastradas = telaRevista.VisualizarRevistas("Pesquisando");

            if (!existeRevistasCadastradas)
            {
                notificador.ApresentarMensagem("Não existe revistas cadastradas!", StatusValidacao.Atencao);
                return;
            }

            int idRevista = telaRevista.ObterNumeroRevista();

            Revista revistaEmprestimo = telaRevista.repositorioRevista.ObterRevistaPorNumero(idRevista);

            Emprestimo emprestimoCadastro = ObterEmprestimo(amigoEmprestimo, revistaEmprestimo);


            repositorioEmprestimo.Inserir(emprestimoCadastro);

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

            Amigo amigoEmprestimo = telaAmigo.repositorioAmigo.ObterRegistro(idAmigo);

            bool existeRevistasCadastradas = telaRevista.VisualizarRevistas("Pesquisando");

            if (!existeRevistasCadastradas)
            {
                notificador.ApresentarMensagem("Não existe emprétimos cadastrados!", StatusValidacao.Atencao);
                return;
            }

            int idRevista = telaRevista.ObterNumeroRevista();

            Revista revistaEmprestimo = telaRevista.repositorioRevista.ObterRevistaPorNumero(idRevista);

            Emprestimo emprestimoCadastro = ObterEmprestimo(amigoEmprestimo, revistaEmprestimo);

            repositorioEmprestimo.Editar(numeroEmprestimo, emprestimoCadastro);

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

            repositorioEmprestimo.Excluir(numeroEmprestimo);

            notificador.ApresentarMensagem("Empréstimo excluído com sucesso", StatusValidacao.Sucesso);
        }

        public bool VisualizarEmprestimos(string tipo)
        {
            if (tipo == "Tela")
                MostrarTitulo("Visualização de empréstimos");

            if (!repositorioEmprestimo.ExisteEmprestimoCadastrado())
                return false;

            Emprestimo[] emprestimos = repositorioEmprestimo.SelecionarTodos();

            if (emprestimos.Length == 0)
                return false;

            for (int i = 0; i < emprestimos.Length; i++)
            {
                Emprestimo e = emprestimos[i];

                Console.WriteLine(e.ToString());
                Console.WriteLine("Amigo - Nome: {0} | Responsável: {1} | Telefone: {2}", e.amigo.nome, e.amigo.responsavel, e.amigo.telefone);
                Console.WriteLine("Revista - Numero edição: {0} | Tipo coleção: {1}",e.revista.numeroEdicao, e.revista.tipoColecao);

                Console.WriteLine();
            }

            return true;
        }

        public void DevolucaoEmprestimo()
        {
            MostrarTitulo("Editando Empréstimo");

            bool temEmprestimosCadastrados = VisualizarEmprestimos("Pesquisando");

            if (temEmprestimosCadastrados == false)
            {
                notificador.ApresentarMensagem("Nenhum emprétimo cadastrado.", StatusValidacao.Atencao);
                return;
            }

            int numeroEmprestimo = ObterNumeroEmprestimo();

            Emprestimo emprestimoDevolucao = repositorioEmprestimo.SelecionarEmprestimo(numeroEmprestimo);

            if(emprestimoDevolucao.DataDevolucao < DateTime.Now)
            {
                Multa multa = new Multa(emprestimoDevolucao);
                repositorioMulta.Inserir(multa);
                notificador.ApresentarMensagem("Uma multa foi gerada pelo atraso!", StatusValidacao.Atencao);
            }

            repositorioEmprestimo.Devolucao(emprestimoDevolucao);

            notificador.ApresentarMensagem("Devolução realizada com sucesso!", StatusValidacao.Sucesso);
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

        public void EmprestimoApartirReserva(Reserva reserva)
        {
            Emprestimo novoEmprestimo = new Emprestimo(reserva.amigo, reserva.revista, DateTime.Now);
            repositorioEmprestimo.Inserir(novoEmprestimo);
        }

        private int ObterNumeroEmprestimo()
        {
            int numeroEmprestimo;
            bool numeroEmprestimoEncontrado;

            do
            {
                Console.Write("Digite o número do empréstimo que deseja editar: ");
                numeroEmprestimo = Convert.ToInt32(Console.ReadLine());

                numeroEmprestimoEncontrado = repositorioEmprestimo.VerificarNumeroEmprestimoExiste(numeroEmprestimo);

                if (numeroEmprestimoEncontrado == false)
                    notificador.ApresentarMensagem("Número do empréstimo não encontrado, digite novamente", StatusValidacao.Atencao);

            } while (numeroEmprestimoEncontrado == false);

            return numeroEmprestimo;
        }

        #endregion
    }
}
