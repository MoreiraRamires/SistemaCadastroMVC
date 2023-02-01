using SistemaCadastro.Models;
using System.Collections.Generic;

namespace SistemaCadastro.Repository.Interface
{
    public interface IContatoRepository
    {
        List<ContatoModel> BuscarTodos();
        ContatoModel Adicionar(ContatoModel contato);
    }
}
