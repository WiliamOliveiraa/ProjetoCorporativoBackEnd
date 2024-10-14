using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetoCorporativo.Data;
using ProjetoCorporativo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoCorporativo.Pages.Demandas
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Demanda> Demanda { get; set; }

        public async Task OnGetAsync()
        {
            Demanda = await _context.Demandas.ToListAsync();
        }
    }
}
