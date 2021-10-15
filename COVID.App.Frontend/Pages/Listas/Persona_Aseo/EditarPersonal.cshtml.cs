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
    public class EditarPersonalModel : PageModel
    {
        private static IRepositorioPersonal_Aseo _repoPersonal = new RepositorioPersonal_Aseo(new Persistencia.AppContext());
        [BindProperty]
        public Personal_Aseo personal_aseo { get; set; }

        //codigo para crear el formulario de filtro de busqueda 
        public IActionResult OnGet(int? idPersonal_Aseo)
        {
            if(idPersonal_Aseo.HasValue)
            {
                personal_aseo = _repoPersonal.GetPersonal_Aseo(idPersonal_Aseo.Value);
            }
            else
            {
                personal_aseo = new Personal_Aseo();
            }
            //Filtrobusqueda = filtrobusqueda;
            
            if(personal_aseo == null)
            {
                return RedirectToPage("./Listas/Persona_Aseo/Personal");
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
                if(personal_aseo.id>0)
                {
                    personal_aseo = _repoPersonal.UpdatePersonal_Aseo(personal_aseo);
                }
                else
                {
                    _repoPersonal.AddPersonal_Aseo(personal_aseo);
                }
                return RedirectToPage("./Personal");
            }
        }
    }
}
