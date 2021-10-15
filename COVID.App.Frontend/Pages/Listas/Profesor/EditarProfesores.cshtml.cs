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
    public class EditarProfesoresModel : PageModel
    {
        private static IRepositorioProfesor _repoProfesor = new RepositorioProfesor(new Persistencia.AppContext());
        [BindProperty]
        public Profesor profesores { get; set; }
        
        //codigo para crear el formulario de filtro de busqueda 
        public IActionResult OnGet(int? idProfesor)
        {
            if(idProfesor.HasValue)
            {
                profesores = _repoProfesor.GetProfesor(idProfesor.Value);
            }
            else
            {
                profesores = new Profesor();
            }
            //Filtrobusqueda = filtrobusqueda;
            
            if(profesores == null)
            {
                return RedirectToPage("./Listas/Profesor/Profesor");
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
                if(profesores.id>0)
                {
                    profesores = _repoProfesor.UpdateProfesor(profesores);
                }
                else
                {
                    _repoProfesor.AddProfesor(profesores);
                }
                return RedirectToPage("./Profesor");
            }
        }
    }
}
