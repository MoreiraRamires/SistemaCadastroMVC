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

        public ContatoModel BuscarPorId(int id)
        {
           ContatoModel contato = _bancoContext.Contato.FirstOrDefault(x => x.Id == id);
            return contato;
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDb = BuscarPorId(contato.Id);

            if (contato.Id == null) throw new System.Exception("Esse contato não existe");

            contatoDb.Nome = contato.Nome;
            contatoDb.Email = contato.Email;
            contatoDb.Celular = contato.Celular;

            _bancoContext.Update(contatoDb);
            _bancoContext.SaveChanges();
            return contatoDb;
        }

        public bool Deletar(int id)
        {

            ContatoModel contatoDb = BuscarPorId(id);

            if (contatoDb == null) throw new System.Exception("Mão foi possível deletar esse contato");
            _bancoContext.Remove(contatoDb);
            _bancoContext.SaveChanges();

            return true;

        }
    }
}
