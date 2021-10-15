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
    public class DetallesDirectivoModel : PageModel
    {
        private static IRepositorioDirectivo _repoDirectivo = new RepositorioDirectivo(new Persistencia.AppContext());

        public Directivo directivos { get; set; }

        //codigo para crear el formulario de filtro de busqueda 
        public IActionResult OnGet(int idDirectivo)
        {
            //Filtrobusqueda = filtrobusqueda;
            directivos = _repoDirectivo.GetDirectivo(idDirectivo);
            if(directivos == null)
            {
                return RedirectToPage("./Lista/Estudiante/Estudiantes");
            }
            else{
                return Page();
            }
        }
    }
}
