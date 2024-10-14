using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetoCorporativo.Data;
using ProjetoCorporativo.Models;
using System.Threading.Tasks;

namespace ProjetoCorporativo.Pages.Demandas
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Demanda Demanda { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Demandas.Add(Demanda);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
