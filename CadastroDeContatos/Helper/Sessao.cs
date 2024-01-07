using CadastroDeContatos.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace CadastroDeContatos.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContent;

        public Sessao(IHttpContextAccessor httpContent)
        {
            _httpContent = httpContent;
        }
        public UsuarioModel BuscarSessaoDoUsuario()
        {
            string sessaoUsuario = _httpContent.HttpContext.Session.GetString("sessaoUsuarioLogado");
            if(string.IsNullOrEmpty(sessaoUsuario)) 
            {
                return null;
            }
            else
            {
                return JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);
            }
        }

        public void CriarSessaoDoUsuario(UsuarioModel usuario)
        {
            string sessao = JsonConvert.SerializeObject(usuario);
            _httpContent.HttpContext.Session.SetString("sessaoUsuarioLogado", sessao);
        }

        public void RemoverSessaoDoUsuario()
        {
            _httpContent.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}
