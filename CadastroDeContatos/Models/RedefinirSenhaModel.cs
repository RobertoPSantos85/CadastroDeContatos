using System.ComponentModel.DataAnnotations;

namespace CadastroDeContatos.Models
{
    public class RedefinirSenhaModel
    {
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string EMail { get; set; }
    }
}
