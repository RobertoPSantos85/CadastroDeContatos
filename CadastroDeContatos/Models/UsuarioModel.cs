using CadastroDeContatos.Enums;
using CadastroDeContatos.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CadastroDeContatos.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido!")]
        public string EMail { get; set; }

        public byte[] Foto { get; set; }

        [Required(ErrorMessage = "Escolha um perfil!")]
        public PerfilEnum Perfil { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public virtual List<ContatoModel> Contatos { get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha.GerarHash();
        }

        public void SetSenhaHash()
        {
            Senha = Senha.GerarHash();
        }

        public void SetNovaSenha(string novaSenha)
        {
            Senha = novaSenha.GerarHash();
        }

        public string GerarNovaSenha()
        {
            string novasenha = Guid.NewGuid().ToString().Substring(0, 8);
            Senha = novasenha.GerarHash();
            return novasenha;
        }
    }
}
