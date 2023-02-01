using SistemaCadastro.Data;
using SistemaCadastro.Models;
using SistemaCadastro.Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace SistemaCadastro.Repository
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly BancoContext _bancoContext;
        public ContatoRepository(BancoContext bancoContext) {
            _bancoContext= bancoContext;
        
        }
        public List<ContatoModel> BuscarTodos()
        {
           return _bancoContext.Contato.ToList();

        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
             _bancoContext.Contato.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }

        
    }
}
