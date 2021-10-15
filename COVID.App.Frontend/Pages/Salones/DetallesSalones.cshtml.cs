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
    public class DetallesSalonesModel : PageModel
    {
        private static IRepositorioSalon _repoSalon = new RepositorioSalon(new Persistencia.AppContext());

        public Salon salones { get; set; }

        //codigo para crear el formulario de filtro de busqueda 
        public IActionResult OnGet(int idSalon)
        {
            //Filtrobusqueda = filtrobusqueda;
            salones = _repoSalon.GetSalon(idSalon);
            if(salones == null)
            {
                return RedirectToPage("./Salones/Salones");
            }
            else{
                return Page();
            }
        }
    }
}
