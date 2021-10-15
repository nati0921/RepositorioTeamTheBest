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
    public class EliminarProfesoresModel : PageModel
    {
        private static IRepositorioProfesor _repoProfesor = new RepositorioProfesor(new Persistencia.AppContext());
        [BindProperty]
        public Profesor profesores {get;set;}

        public IActionResult OnGet(int idProfesor)
        {
            profesores = _repoProfesor.GetProfesor(idProfesor);
            return Page();
        }

        public IActionResult OnPost()
        {
            
            _repoProfesor.DeleteProfesor(profesores.id);
            return RedirectToPage("./Profesor");
        }
    }
}
