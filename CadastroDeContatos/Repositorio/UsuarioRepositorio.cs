using CadastroDeContatos.Data;
using CadastroDeContatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CadastroDeContatos.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
       private readonly ContatoContext _usuario;
        public UsuarioRepositorio(ContatoContext usuario)
        {
            _usuario = usuario;
                
        }

        public UsuarioModel ListarPorId(int id)
        {
            return _usuario.Usuarios.FirstOrDefault(c => c.Id == id);
        }

        public List<UsuarioModel> BuscarTodos()
        {
            
            return _usuario.Usuarios.ToList();
                       
        }
        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            usuario.SetSenhaHash();
            _usuario.Usuarios.Add(usuario);
            _usuario.SaveChanges();
            
            return usuario;
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel u = ListarPorId(usuario.Id);

            if(u != null)
            {
                u.Nome = usuario.Nome;
                u.Login = usuario.Login;
                u.EMail = usuario.EMail;
                u.Perfil = usuario.Perfil;
                u.DataAtualizacao = DateTime.Now;

                _usuario.Usuarios.Update(u);
                _usuario.SaveChanges();

                return u;
            }
            else
            {
                throw new System.Exception("Houve um erro ao atualizar o usuario!");
            }
        }

        public bool Apagar(int id)
        {
            UsuarioModel u = ListarPorId(id);

            if(u != null)
            {
                _usuario.Usuarios.Remove(u);
                _usuario.SaveChanges();
                return true;
            }
            else
            {
                throw new Exception("Houve um erro ao apagar o usuario!");
            }
        }

        public UsuarioModel BuscaPorLogin(string login)
        {
           return _usuario.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }

        public UsuarioModel BuscaPorEmaileLogin(string email, string login)
        {
            return _usuario.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper() && x.EMail.ToUpper() == email.ToUpper());
        }

        public UsuarioModel AlterarSenha(AlterarSenhaModel alterar)
        {
            UsuarioModel usuarioDb = ListarPorId(alterar.Id);

            if (usuarioDb == null) throw new Exception("Houve um erro na atualização da senha, usuário não encontrado!");
            
            if (!usuarioDb.SenhaValida(alterar.SenhaAtual)) throw new Exception("Senha atual não confere!");

            if (usuarioDb.SenhaValida(alterar.NovaSenha)) throw new Exception("Nova senha deve ser diferente da senha atual!");

            usuarioDb.SetNovaSenha(alterar.NovaSenha);
            usuarioDb.DataAtualizacao = DateTime.Now;

            _usuario.Usuarios.Update(usuarioDb);
            _usuario.SaveChanges();

            return usuarioDb;
            
        }
    }
}
