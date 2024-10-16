using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetoCorporativo.Data;
using ProjetoCorporativo.Models;
using System.Threading.Tasks;

namespace ProjetoCorporativo.Pages.Demandas
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Demanda Demanda { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Demanda = await _context.Demandas.FirstOrDefaultAsync(m => m.Id == id);

            if (Demanda == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Demanda = await _context.Demandas.FindAsync(id);

            if (Demanda != null)
            {
                _context.Demandas.Remove(Demanda);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("Index");
        }
    }
}
