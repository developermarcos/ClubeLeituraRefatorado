using ClubeLeitura.ConsoleApp.Compartilhado;
using ClubeLeitura.ConsoleApp.ModuloEmprestimos;
using ClubeLeitura.ConsoleApp.ModuloPessoa;
using ClubeLeitura.ConsoleApp.ModuloRevista;
using System;

namespace ClubeLeitura.ConsoleApp.ModeloReserva
{
    public class TelaReserva
    {
        public Notificador notificador; //reponsável pelas mensagens pro usuário
        
        private RepositorioReserva repositorioReserva;
        private TelaAmigo telaAmigo;
        private TelaRevista telaRevista;
        private TelaEmprestimo telaEmprestimo;

        public TelaReserva(RepositorioReserva repositorioReserva, TelaAmigo telaAmigo, TelaRevista telaRevista, TelaEmprestimo telaEmprestimo, Notificador notificador)
        {
            this.repositorioReserva=repositorioReserva;
            this.telaAmigo=telaAmigo;
            this.telaRevista=telaRevista;
            this.telaEmprestimo=telaEmprestimo;
            this.notificador=notificador;
        }

        public string MostrarOpcoes()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Reservas");

            Console.WriteLine();

            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Editar");
            Console.WriteLine("Digite 3 para Excluir");
            Console.WriteLine("Digite 4 para Visualizar");
            Console.WriteLine("Digite 5 para Emprestimo");

            Console.WriteLine("Digite s para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public void InserirNovaReserva()
        {
            MostrarTitulo("Inserindo nova reserva");

            bool existeAmigosCadastrados = telaAmigo.VisualizarAmigos("Pesquisando");

            if (!existeAmigosCadastrados)
            {
                notificador.ApresentarMensagem("Não existe amigos cadastrados!", StatusValidacao.Atencao);
                return;
            }

            int idAmigo = telaAmigo.ObterNumeroAmigo();

            Amigo amigoReserva = telaAmigo.repositorioAmigo.ObterRegistro(idAmigo);

            
            bool existeRevistasCadastradas = telaRevista.VisualizarRevistas("Pesquisando");

            if (!existeRevistasCadastradas)
            {
                notificador.ApresentarMensagem("Não existe revistas cadastradas!", StatusValidacao.Atencao);
                return;
            }

            int idRevista = telaRevista.ObterNumeroRevista();

            Revista revistaReserva = telaRevista.repositorioRevista.ObterRegistro(idRevista);


            Reserva reservaCadastro = ObterReserva(amigoReserva, revistaReserva);

            repositorioReserva.Inserir(reservaCadastro);

            notificador.ApresentarMensagem("Empréstimo inserido com sucesso!", StatusValidacao.Sucesso);
        }

        public void EditarReserva()
        {
            MostrarTitulo("Editando reserva");

            bool temeEmprestimosCadastrados = VisualizarReservas("Pesquisando");

            if (temeEmprestimosCadastrados == false)
            {
                notificador.ApresentarMensagem("Nenhuma reserva cadastrado para poder editar", StatusValidacao.Atencao);
                return;
            }
            
            int numeroReserva = ObterNumeroReserva();


            telaAmigo.VisualizarAmigos("Pesquisando");
            int idAmigo = telaAmigo.ObterNumeroAmigo();

            telaRevista.VisualizarRevistas("Pesquisando");
            int idRevista = telaRevista.ObterNumeroRevista();
            
            
            Amigo amigoEmprestimo = telaAmigo.repositorioAmigo.ObterRegistro(idAmigo);
            Revista revistaEmprestimo = telaRevista.repositorioRevista.ObterRegistro(idRevista);
            Reserva emprestimoCadastro = ObterReserva(amigoEmprestimo, revistaEmprestimo);

            repositorioReserva.Editar(numeroReserva, emprestimoCadastro);

            notificador.ApresentarMensagem("Reserva editada com sucesso!", StatusValidacao.Sucesso);
        }

        public void ExcluirReserva()
        {
            MostrarTitulo("Excluindo reserva");

            bool temReservaCadastrada = VisualizarReservas("Pesquisando");

            if (temReservaCadastrada == false)
            {
                notificador.ApresentarMensagem("Nenhuma reserva cadastrada para poder excluir", StatusValidacao.Atencao);
                return;
            }

            int numeroEmprestimo = ObterNumeroReserva();

            repositorioReserva.Excluir(numeroEmprestimo);

            notificador.ApresentarMensagem("Reserva excluída com sucesso", StatusValidacao.Sucesso);
        }

        public bool VisualizarReservas(string tipo)
        {
            if (tipo == "Tela")
                MostrarTitulo("Visualização de reservas");

            if (repositorioReserva.ObterQuantidadeRegistros() == 0)
                return false;

            Reserva[] reservas = repositorioReserva.ObterTodosRegistros();

            if (reservas.Length == 0)
                return false;

            for (int i = 0; i < reservas.Length; i++)
            {
                Reserva r = reservas[i];
                
                Console.WriteLine();

                Console.WriteLine(r.ToString());
                Console.WriteLine("Amigo - Nome: {0} | Responsável: {1} | Telefone: {2}", r.amigo.nome, r.amigo.responsavel, r.amigo.telefone);
                Console.WriteLine("Revista - Numero edição: {0} | Tipo coleção: {1}", r.revista.numeroEdicao, r.revista.tipoColecao);


                Console.WriteLine();
            }

            return true;
        }

        public void EmprestimoApartirReserva()
        {
            MostrarTitulo("Inserindo novo empréstimo");
            
            bool temeEmprestimosCadastrados = VisualizarReservas("Pesquisando");
            if (temeEmprestimosCadastrados == false)
            {
                notificador.ApresentarMensagem("Nenhuma reserva cadastrado para poder editar", StatusValidacao.Atencao);
                return;
            }

            Console.WriteLine("Informe a reserva que deseja criar um empréstimo");
            int numeroReserva = ObterNumeroReserva();

            Reserva reserva = repositorioReserva.ObterRegistro(numeroReserva);

            telaEmprestimo.EmprestimoApartirReserva(reserva);

            repositorioReserva.Excluir(numeroReserva);

            notificador.ApresentarMensagem("Empréstimo realizado com sucesso", StatusValidacao.Sucesso);
        }

        #region métodos privados
        private void MostrarTitulo(string titulo)
        {
            Console.Clear();

            Console.WriteLine(titulo);

            Console.WriteLine();
        }

        private Reserva ObterReserva(Amigo amigoEmprestimo, Revista revistaEmprestimo)
        {
            Amigo amigo;
            Revista revista;
            DateTime reservaData;

            while (true)
            {
                Console.Write("Informe a data da reserva (ex: 00/00/0000): ");
                string dataEmprestimo = Console.ReadLine();
                bool conversaoRealizada = DateTime.TryParse(dataEmprestimo, out DateTime dataCadastro);
                if (dataEmprestimo.Length == 10 && conversaoRealizada == true)
                {
                    amigo = amigoEmprestimo;
                    revista = revistaEmprestimo;
                    reservaData = dataCadastro;
                    break;
                }
                else
                    notificador.ApresentarMensagem("Data não foi informada no padrão solicitado, tente novamente.", StatusValidacao.Atencao);
            }
            Reserva emprestimo = new Reserva(amigoEmprestimo, revistaEmprestimo, reservaData);
            return emprestimo;
        }

        private int ObterNumeroReserva()
        {
            int numeroReserva;
            bool numeroReservaEncontrada;

            do
            {
                Console.Write("Digite o número da reserva: ");
                numeroReserva = Convert.ToInt32(Console.ReadLine());

                numeroReservaEncontrada = repositorioReserva.ExisteNumeroRegistro(numeroReserva);

                if (numeroReservaEncontrada == false)
                    notificador.ApresentarMensagem("Número da reserva não encontrada, digite novamente", StatusValidacao.Atencao);

            } while (numeroReservaEncontrada == false);

            return numeroReserva;
        }
        #endregion
    }
}
