using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using COVID.App.Persistencia;
using COVID.App.Dominio;

namespace COVID.App.Frontend.Pages
{
    public class EditarDirectivoModel : PageModel
    {
        private static IRepositorioDirectivo _repoDirectivo = new RepositorioDirectivo(new Persistencia.AppContext());
        [BindProperty]
        public Directivo directivos { get; set; }

        //codigo para crear el formulario de filtro de busqueda 
        public IActionResult OnGet(int? idDirectivo)
        {
            if(idDirectivo.HasValue)
            {
                directivos = _repoDirectivo.GetDirectivo(idDirectivo.Value);
            }
            else
            {
                directivos = new Directivo();
            }
            //Filtrobusqueda = filtrobusqueda;
            
            if(directivos == null)
            {
                return RedirectToPage("./Listas/Directivo/Directivo");
            }
            else
            {
                return Page();
            }
        }  

        public IActionResult OnPost(){
            if(!ModelState.IsValid)
            {
                return Page();                
            }
            else
            {
                if(directivos.id>0)
                {
                    directivos = _repoDirectivo.UpdateDirectivo(directivos);
                }
                else
                {
                    _repoDirectivo.AddDirectivo(directivos);
                }
                return RedirectToPage("./Directivo");
            }
        }
    }
}
