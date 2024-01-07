using System.ComponentModel.DataAnnotations;

namespace CadastroDeContatos.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Senha { get;set; }
    }
}
