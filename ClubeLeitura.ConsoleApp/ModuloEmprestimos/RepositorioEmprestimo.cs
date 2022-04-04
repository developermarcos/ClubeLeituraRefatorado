using ClubeLeitura.ConsoleApp.Compartilhado;

namespace ClubeLeitura.ConsoleApp.ModuloEmprestimos
{
    public class RepositorioEmprestimo : RepositorioBase<Emprestimo>
    {
        
        public RepositorioEmprestimo(int tamanhoArray) : base(tamanhoArray)
        {
            
        }

        
        public bool ExisteEmprestimoCadastrado()
        {
            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null)
                {
                    return true;
                }
            }
            return false;
        }

        public void Devolucao(Emprestimo emprestimoDevolucao)
        {
            emprestimoDevolucao.devolucao = true;
            for (int i = 0; i < registros.Length; i++)
            {
                if(registros[i].numero == emprestimoDevolucao.numero)
                {
                    registros[i].numero = emprestimoDevolucao.numero;
                    break;
                }
            }
        }
    }
}
