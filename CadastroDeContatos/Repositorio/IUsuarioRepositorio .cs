using CadastroDeContatos.Models;
using System.Collections.Generic;

namespace CadastroDeContatos.Repositorio
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel BuscaPorLogin(string login);
        UsuarioModel BuscaPorEmaileLogin(string email,string login);
        UsuarioModel ListarPorId(int id);
        List<UsuarioModel> BuscarTodos();
        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel Atualizar(UsuarioModel usuario);

        UsuarioModel AlterarSenha(AlterarSenhaModel alterar);    

        bool Apagar(int id);
    }
}
