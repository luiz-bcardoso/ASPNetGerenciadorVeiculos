using ASPNetGerenciadorVeiculos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;
using System.Text.RegularExpressions;

namespace ASPNetGerenciadorVeiculos.Pages.Veiculos
{
    public class EditarModel : PageModel
    {
        [BindProperty]
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

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var veiculos = CarregarVeiculos();

            var index = veiculos.FindIndex(u => u.Id == Veiculo.Id);
            if (index == -1)
                return RedirectToPage("/Veiculos/Index");

            veiculos[index] = Veiculo;

            SalvarVeiculos(veiculos);

            return RedirectToPage("/Veiculos/Index");
        }

        private List<Veiculo> CarregarVeiculos()
        {
            var lista = new List<Veiculo>();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "veiculos.txt");

            if (System.IO.File.Exists(path))
            {
                var linhas = System.IO.File.ReadAllLines(path);
                foreach (var linha in linhas)
                {
                    var dados = linha.Split(';');
                    if (dados.Length == 8 && int.TryParse(dados[0], out int id))
                    {
                        lista.Add(new Veiculo
                        {
                            Id = id,
                            Nome = dados[1],
                            Modelo = dados[2],
                            Marca = dados[3],
                            Renavam = dados[4],
                            AnoFabricacao = int.Parse(dados[5]),
                            AnoModelo = int.Parse(dados[6]),
                            DirFoto = dados[7]
                        });
                    }
                }
            }

            return lista;
        }
        private void SalvarVeiculos(List<Veiculo> veiculos)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "veiculos.txt");
            var linhas = veiculos.Select(u => $"{u.Id};{u.Nome};{u.Modelo};{u.Marca};{u.Renavam};{u.AnoFabricacao};{u.AnoModelo};{u.DirFoto}");
            System.IO.File.WriteAllLines(path, linhas);
        }
    }
}
