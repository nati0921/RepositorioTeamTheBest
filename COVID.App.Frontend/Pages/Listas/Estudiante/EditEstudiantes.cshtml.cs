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
    public class EditEstudiantesModel : PageModel
    {
        private static IRepositorioEstudiante _repoEstudiante = new RepositorioEstudiante(new Persistencia.AppContext());
        [BindProperty]
        public Estudiante estudiantes { get; set; }

        public IActionResult OnGet(int? idEstudiante)
        {
            if(idEstudiante.HasValue)
            {
                estudiantes = _repoEstudiante.GetEstudiante(idEstudiante.Value);
            }
            else
            {
                estudiantes = new Estudiante();
            }
            
            if(estudiantes == null)
            {
                return RedirectToPage("./Listas/Estudiante/Estudiantes");
            }
            else
            {
                return Page();
            }
        }  

        public IActionResult OnPost(){
            if(!ModelState.IsValid)
            {
                //return RedirectToPage("./Estudiantes");
                return Page();                
            }
            else
            {
                if(estudiantes.id>0)
                {
                    estudiantes = _repoEstudiante.UpdateEstudiante(estudiantes);
                }
                else
                {
                    _repoEstudiante.AddEstudiante(estudiantes);
                }
                return RedirectToPage("./Estudiantes");
            }
        }
    }
}
