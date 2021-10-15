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
    public class DetallesProfesoresModel : PageModel
    {
        private static IRepositorioProfesor _repoProfesor = new RepositorioProfesor(new Persistencia.AppContext());

        public Profesor profesores { get; set; }

        //codigo para crear el formulario de filtro de busqueda 
        public IActionResult OnGet(int idProfesor)
        {
            //Filtrobusqueda = filtrobusqueda;
            profesores = _repoProfesor.GetProfesor(idProfesor);
            if(profesores == null)
            {
                return RedirectToPage("./Lista/Profesor/Profesor");
            }
            else{
                return Page();
            }
        }
    }
}