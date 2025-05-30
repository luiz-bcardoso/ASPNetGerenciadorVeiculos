using ASPNetGerenciadorVeiculos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPNetGerenciadorVeiculos.Pages.Veiculos
{
    public class CadastrarModel : PageModel
    {
        [BindProperty]
        public Veiculo veiculo {get; set;}
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();
            else
            {
                using (var writer = new StreamWriter("veiculos.txt", true)) //Grava em arquivo (o true não sobreescreve)
                {
                    writer.WriteLine(veiculo);
                    return RedirectToPage("/Veiculos/Index");
                }
            }
        }
    }
}
