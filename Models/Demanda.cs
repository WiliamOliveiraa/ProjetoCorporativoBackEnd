using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoCorporativo.Models
{
    public class Demanda
    {
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.Now;

        public string Status { get; set; }

        public DateTime Prazo { get; set; }
    }
}
