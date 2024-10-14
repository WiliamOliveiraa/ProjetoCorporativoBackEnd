using System;

namespace ProjetoCorporativo.Models
{
    public class Notificacao
    {
        public int Id { get; set; }

        public int DemandaId { get; set; }

        public string Mensagem { get; set; }

        public DateTime DataEnvio { get; set; } = DateTime.Now;

        public Demanda Demanda { get; set; }
    }
}
