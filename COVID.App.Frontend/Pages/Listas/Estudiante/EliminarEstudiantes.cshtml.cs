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
    public class EliminarEstudiantesModel : PageModel
    {
        private static IRepositorioEstudiante _repoEstudiante = new RepositorioEstudiante(new Persistencia.AppContext());
        [BindProperty]
        public Estudiante estudiantes {get;set;}

        public IActionResult OnGet(int idEstudiante)
        {
            estudiantes = _repoEstudiante.GetEstudiante(idEstudiante);
            return Page();
        }

        public IActionResult OnPost()
        {
            
            _repoEstudiante.DeleteEstudiante(estudiantes.id);
            return RedirectToPage("./Estudiantes");
        }
    }
}
