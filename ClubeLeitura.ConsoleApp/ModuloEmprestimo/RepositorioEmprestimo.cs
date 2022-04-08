using ClubeLeitura.ConsoleApp.Compartilhado;

namespace ClubeLeitura.ConsoleApp.ModuloEmprestimo
{
    public class RepositorioEmprestimo : RepositorioBase<Emprestimo>
    {
        public void Devolucao(Emprestimo emprestimoDevolucao)
        {
            emprestimoDevolucao.devolucao = true;
            
            for (int i = 0; i < registros.Count; i++)
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
