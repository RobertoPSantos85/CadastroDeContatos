using System.ComponentModel.DataAnnotations;

namespace CadastroDeContatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }

        public int? UsuarioId { get; set; }
        
        [Required(ErrorMessage="Este campo é obrigatório!")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [EmailAddress(ErrorMessage ="O e-mail informado não é válido!")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [Phone(ErrorMessage = "O número informado não é válido!")]
        public string Telefone { get; set; }

        public UsuarioModel Usuario { get; set; }
    }
}
