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
    public class DetallesEstudiantesModel : PageModel
    {
        private static IRepositorioEstudiante _repoEstudiante = new RepositorioEstudiante(new Persistencia.AppContext());

        public Estudiante estudiantes { get; set; }

        //codigo para crear el formulario de filtro de busqueda 
        public IActionResult OnGet(int idEstudiante)
        {
            estudiantes = _repoEstudiante.GetEstudiante(idEstudiante);
            if(estudiantes == null)
            {
                return RedirectToPage("./Lista/Estudiante/Estudiantes");
            }
            else{
                return Page();
            }
        }
    }
}
