using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoCorporativo.Data;
using ProjetoCorporativo.Models;

namespace ProjetoCorporativo.Services
{
    public class NotificacaoService
    {
        private readonly ApplicationDbContext _context;

        public NotificacaoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task EnviarNotificacoesAsync()
        {
            var hoje = DateTime.Now.Date;
            var demandasProximas = await _context.Demandas
                .Where(d => d.Prazo.Date == hoje.AddDays(1) && d.Status != "Concluída")
                .ToListAsync();

            foreach (var demanda in demandasProximas)
            {
                var notificacao = new Notificacao
                {
                    DemandaId = demanda.Id,
                    Mensagem = $"A demanda '{demanda.Titulo}' está com prazo para amanhã."
                };

                _context.Notificacoes.Add(notificacao);
                // Aqui você pode integrar com um serviço de e-mail ou SMS para enviar a notificação
            }

            await _context.SaveChangesAsync();
        }
    }
}
