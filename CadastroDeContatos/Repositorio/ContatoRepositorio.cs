using CadastroDeContatos.Data;
using CadastroDeContatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CadastroDeContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
       private readonly ContatoContext _context;
        public ContatoRepositorio(ContatoContext context)
        {
            _context = context;
                
        }

        public ContatoModel ListarPorId(int id)
        {
            return _context.Contatos.FirstOrDefault(c => c.Id == id);
        }

        public List<ContatoModel> BuscarTodos(int usuarioId)
        {
            
            return _context.Contatos.Where(x => x.UsuarioId ==usuarioId).ToList();
                       
        }
        public ContatoModel Adicionar(ContatoModel contato)
        {
            _context.Contatos.Add(contato);
            _context.SaveChanges();
            
            return contato;
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel c = ListarPorId(contato.Id);

            if(c != null)
            {
                c.Nome = contato.Nome;
                c.Email = contato.Email;
                c.Telefone = contato.Telefone;

                _context.Contatos.Update(c);
                _context.SaveChanges();

                return c;
            }
            else
            {
                throw new System.Exception("Houve um erro ao atualizar o contato!");
            }
        }

        public bool Apagar(int id)
        {
            ContatoModel c = ListarPorId(id);

            if(c != null)
            {
                _context.Contatos.Remove(c);
                _context.SaveChanges();
                return true;
            }
            else
            {
                throw new Exception("Houve um erro ao apagar o contato!");
            }
        }
    }
}
