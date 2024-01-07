using CadastroDeContatos.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace CadastroDeContatos.Models
{
    public class UsuarioSemSenhaModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido!")]
        public string EMail { get; set; }

        [Required(ErrorMessage = "Escolha um perfil!")]
        public PerfilEnum Perfil { get; set; }

        
    }
}
