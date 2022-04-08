using ClubeLeitura.ConsoleApp.Compartilhado;
using ClubeLeitura.ConsoleApp.Compartilhado.Interfaces;
using ClubeLeitura.ConsoleApp.ModuloMulta;
using System;

namespace ClubeLeitura.ConsoleApp.ModuloPessoa
{
    public class TelaAmigo : TelaBase, ICadastroBasico
    {
        public Notificador notificador; //reponsável pelas mensagens pro usuário
        public RepositorioAmigo repositorioAmigo;
       
        public TelaAmigo(RepositorioAmigo repositorioAmigo, Notificador notificador) : base("Tela Amigos")
        {
            this.repositorioAmigo=repositorioAmigo;
            this.notificador=notificador;
        }

        public override string MostrarOpcoes()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Amigos");

            Console.WriteLine();

            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Editar");
            Console.WriteLine("Digite 3 para Excluir");
            Console.WriteLine("Digite 4 para Visualizar");
            Console.WriteLine("Digite 5 para Visualizar Amigos com Multa");
            Console.WriteLine("Digite 6 para Pagar Multas");

            Console.WriteLine("Digite s para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public void InserirRegistro()
        {
            MostrarTitulo("Inserindo novo Amigo");

            Amigo novoAmigo = ObterAmigo();

            repositorioAmigo.Inserir(novoAmigo);

            notificador.ApresentarMensagem("Amigo inserido com sucesso!", TipoMensagem.Sucesso);
        }

        public void EditarRegistro()
        {
            MostrarTitulo("Editando Amigo");

            bool temCaixasCadastradas = VisualizarRegistros("Pesquisando");

            if (temCaixasCadastradas == false)
            {
                notificador.ApresentarMensagem("Nenhum amigo cadastrado para poder editar", TipoMensagem.Atencao);
                return;
            }

            int numeroCaixa = ObterNumeroAmigo();

            Amigo amigoAtualizado = ObterAmigo();

            repositorioAmigo.Editar(numeroCaixa, amigoAtualizado);

            notificador.ApresentarMensagem("Amigo editado com sucesso", TipoMensagem.Sucesso);
        }

        public void ExcluirRegistro()
        {
            MostrarTitulo("Excluindo Amigo");

            bool temCaixasCadastradas = VisualizarRegistros("Pesquisando");

            if (temCaixasCadastradas == false)
            {
                notificador.ApresentarMensagem(
                    "Nenhum amigo cadastrado para poder excluir", TipoMensagem.Atencao);
                return;
            }

            int numeroAmigo = ObterNumeroAmigo();

            repositorioAmigo.Excluir(numeroAmigo);

            notificador.ApresentarMensagem("Amigo excluído com sucesso", TipoMensagem.Sucesso);
        }

        public bool VisualizarRegistros(string tipoVisualizado)
        {
            if (tipoVisualizado == "Tela")
                MostrarTitulo("Visualização de Amigos");

            Amigo[] amigos = (Amigo[])repositorioAmigo.ObterTodosRegistros();

            if (amigos.Length == 0)
                return false;

            for (int i = 0; i < amigos.Length; i++)
            {
                Amigo a = amigos[i];

                Console.WriteLine();

                Console.WriteLine(a.ToString());

                Console.WriteLine();
            }

            return true;
        }

        public bool VisualizarAmigosComMulta(string tipo)
        {
            if (tipo == "Tela")
                MostrarTitulo("Visualização de Amigos com Multa");

            Amigo[] amigos = repositorioAmigo.SelecionarAmigosComMulta();

            if (amigos.Length == 0)
                return false;

            for (int i = 0; i < amigos.Length; i++)
            {
                Amigo a = amigos[i];

                Console.WriteLine("Número: " + a.ToString());
                
                Console.WriteLine();
            }

            return true;
        }

        public void PagarMulta()
        {
            MostrarTitulo("Pagamento de Multas");

            bool temAmigosComMulta = VisualizarAmigosComMulta("Pesquisando");

            if (!temAmigosComMulta)
            {
                notificador.ApresentarMensagem("Não há nenhum amigo com multas em aberto", TipoMensagem.Atencao);
                return;
            }

            int numeroAmigoComMulta = ObterNumeroAmigo();

            Amigo amigoComMulta = repositorioAmigo.ObterRegistro(numeroAmigoComMulta);

            amigoComMulta.PagarMulta();

            repositorioAmigo.Editar(numeroAmigoComMulta, amigoComMulta);

            notificador.ApresentarMensagem("Multa paga com sucesso!", TipoMensagem.Sucesso);
        }

        #region métodos internos
        
        private Amigo ObterAmigo()
        {
            string nome;
            bool nomeJaUtilizado;
            do
            {
                nomeJaUtilizado = false;

                Console.Write("Digite o nome: ");
                nome = Console.ReadLine();

                nomeJaUtilizado = repositorioAmigo.nomeJaCadastrado(nome);

                if (nomeJaUtilizado)
                    notificador.ApresentarMensagem("Nome já cadastrado, por gentileza informe outro", TipoMensagem.Erro);

            } while (nomeJaUtilizado);

            Console.Write("Digite o responsável: ");
            string responsavel = Console.ReadLine();

            Console.Write("Digite o telefone: ");
            string telefone = Console.ReadLine();

            Console.Write("Digite o endereço: ");
            string endereco = Console.ReadLine();

            Amigo amigo = new Amigo(nome, responsavel, telefone, endereco);

            return amigo;
        }
                
        private int ObterNumeroAmigo()
        {
            int numeroAmigo;
            bool numeroAmigoEncontrado;

            do
            {
                Console.Write("Digite o número do amigo: ");
                numeroAmigo = Convert.ToInt32(Console.ReadLine());

                numeroAmigoEncontrado = repositorioAmigo.RegistroExiste(numeroAmigo);

                if (numeroAmigoEncontrado == false)
                    notificador.ApresentarMensagem("Número do amigo não encontrado, digite novamente", TipoMensagem.Atencao);

            } while (numeroAmigoEncontrado == false);

            return numeroAmigo;
        }

        #endregion
    }
}
