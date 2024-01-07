using CadastroDeContatos.Helper;
using CadastroDeContatos.Models;
using CadastroDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CadastroDeContatos.Controllers
{
    public class AlterarSenhaController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;

        public AlterarSenhaController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Alterar(AlterarSenhaModel alterar)
        {
            try
            {
                UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                alterar.Id = usuarioLogado.Id;
               
                if(ModelState.IsValid)
                {
                    _usuarioRepositorio.AlterarSenha(alterar);
                    TempData["MensagemSucesso"] = "Senha alterada com sucesso.";
                    return View("Index", alterar);
                }
                return View("Index", alterar);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops! Não conseguimos alterar a sua senha. Tente novamente, detalhe: {erro.Message}";
                return View("Index", alterar);
            }
        }
    }
}
