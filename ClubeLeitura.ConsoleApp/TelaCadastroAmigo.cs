using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp
{
    public class TelaCadastroAmigo
    {
        public Amigo[] amigos;
        public int numeroAmigo;
        public Notificador notificador;

        public string MostrarOpcoes()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Amigos");

            Console.WriteLine();

            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Editar");
            Console.WriteLine("Digite 3 para Excluir");
            Console.WriteLine("Digite 4 para Visualizar");

            Console.WriteLine("Digite s para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public void InserirNovaCaixa()
        {
            MostrarTitulo("Inserindo novo Amigo");

            Amigo amigo = ObterAmigo();

            amigo.numero = ++numeroAmigo;
            
            int posicaoVazia = ObterPosicaoVazia();

            amigos[posicaoVazia] = amigo;

            notificador.ApresentarMensagem("Amigo inserido com sucesso!", "Sucesso");
        }

        private Amigo ObterAmigo()
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o responsavel: ");
            string responsavel = Console.ReadLine();

            Console.Write("Digite o telefone: ");
            string telefone = Console.ReadLine();

            Console.Write("Digite o endereço: ");
            string endereco = Console.ReadLine();

            Amigo amigo = new Amigo();

            amigo.nome = nome;
            amigo.responsavel = responsavel;
            amigo.telefone = telefone;
            amigo.endereco = endereco;
            

            return amigo;
        }

        public void EditarCaixa()
        {
            MostrarTitulo("Editando Amigo");

            VisualizarCaixas("Pesquisando");

            Console.Write("Digite o número do amigo que deseja editar: ");
            int numeroAmigo = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i].numero == numeroAmigo)
                {
                    Amigo amigo = ObterAmigo();

                    amigos[i].numero = numeroAmigo;
                    amigos[i] = amigo;

                    break;
                }
            }

            notificador.ApresentarMensagem("Amigo editado com sucesso", "Sucesso");
        }

        public void MostrarTitulo(string titulo)
        {
            Console.Clear();

            Console.WriteLine(titulo);

            Console.WriteLine();
        }

        public void ExcluirCaixa()
        {
            MostrarTitulo("Excluindo Caixa");

            VisualizarCaixas("Pesquisando");

            Console.Write("Digite o número do amigo que deseja excluir: ");
            int numeroCaixa = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i].numero == numeroCaixa)
                {
                    amigos[i] = null;
                    break;
                }
            }

            notificador.ApresentarMensagem("Amigo excluído com sucesso", "Sucesso");
        }

        public void VisualizarCaixas(string tipo)
        {
            if (tipo == "Tela")
                MostrarTitulo("Visualização de Amigos");

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] == null)
                    continue;

                Amigo a = amigos[i];

                Console.WriteLine("Nome: " + a.numero);
                Console.WriteLine("Nome: " + a.nome);
                Console.WriteLine("Responsável: " + a.responsavel);
                Console.WriteLine("Telefone: " + a.telefone);
                Console.WriteLine("Endereço: " + a.endereco);

                Console.WriteLine();
            }
        }

        public int ObterPosicaoVazia()
        {
            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] == null)
                    return i;
            }

            return -1;
        }
    }
}
