using SistemaCadastro.Models;
using System.Collections.Generic;

namespace SistemaCadastro.Repository.Interface
{
    public interface IContatoRepository
    {
        List<ContatoModel> BuscarTodos();

        ContatoModel BuscarPorId(int id);
        ContatoModel Adicionar(ContatoModel contato);

        ContatoModel Atualizar(ContatoModel contato);
    }
}
