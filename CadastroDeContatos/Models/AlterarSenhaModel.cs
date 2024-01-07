using System.ComponentModel.DataAnnotations;

namespace CadastroDeContatos.Models
{
    public class AlterarSenhaModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Este campo é obrigatório.")]
        public string SenhaAtual { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string NovaSenha { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [Compare("NovaSenha", ErrorMessage ="Este campo deve ser preenchido com o mesmo valor do campo nova senha.")]
        public string ConfirmarNovaSenha { get; set;}
    }
}
