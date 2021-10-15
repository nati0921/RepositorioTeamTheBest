using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using COVID.App.Persistencia;
using COVID.App.Dominio;
using Microsoft.AspNetCore.Authorization;

namespace COVID.App.Frontend.Pages
{
    [Authorize]
    public class ProfesorModel : PageModel
    {
        private static IRepositorioProfesor _repoProfesor = new RepositorioProfesor(new Persistencia.AppContext());
        
        public IEnumerable<Profesor> Profesores {get;set;}
        
        public void OnGet()
        {
            Profesores = _repoProfesor.GetAllProfesores();
        }
    }
}
