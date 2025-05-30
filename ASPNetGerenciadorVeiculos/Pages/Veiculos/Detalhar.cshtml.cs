using ASPNetGerenciadorVeiculos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPNetGerenciadorVeiculos.Pages.Veiculos
{
    public class DetalharModel : PageModel
    {
        public Veiculo Veiculo { get; set; }
        public IActionResult OnGet(int id)
        {
            var veiculos = CarregarVeiculos();

            Veiculo = veiculos.FirstOrDefault(u => u.Id == id);

            if (Veiculo == null)
            {
                return RedirectToPage("/Veiculos/Index");
            }
            return Page();
        }

        public List<Veiculo> CarregarVeiculos()
        {
            var Veiculos = new List<Veiculo>();
            if (System.IO.File.Exists("veiculos.txt"))
            {
                var linhas = System.IO.File.ReadAllLines("veiculos.txt");

                foreach (var linha in linhas)
                {
                    var dados = linha.Split(';');
                    //dados[0] = ID
                    //dados[1] = Nome ...

                    var veiculo = new Veiculo()
                    {
                        Id = int.Parse(dados[0]),
                        Nome = dados[1],
                        Modelo = dados[2],
                        Marca = dados[3],
                        Renavam = dados[4],
                        AnoFabricacao = int.Parse(dados[5]),
                        AnoModelo = int.Parse(dados[6]),
                        DirFoto = dados[7]
                    };
                    Veiculos.Add(veiculo);
                }
            }
            return Veiculos;
        }
    }
}
