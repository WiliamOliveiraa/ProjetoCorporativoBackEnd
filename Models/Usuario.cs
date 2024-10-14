using System.ComponentModel.DataAnnotations;

namespace ProjetoCorporativo.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }

        public string Perfil { get; set; } // Ex: "Admin", "Funcionario"
    }
}
