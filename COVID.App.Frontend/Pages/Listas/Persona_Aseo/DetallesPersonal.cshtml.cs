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
    public class DetallesPersonalModel : PageModel
    {
        private static IRepositorioPersonal_Aseo _repoPersonal = new RepositorioPersonal_Aseo(new Persistencia.AppContext());

        public Personal_Aseo personal_aseo { get; set; }
        

        //codigo para crear el formulario de filtro de busqueda 
        public IActionResult OnGet(int idPersonal_Aseo)
        {
            personal_aseo = _repoPersonal.GetPersonal_Aseo(idPersonal_Aseo);
            if(personal_aseo == null)
            {
                return RedirectToPage("./Lista/Persona_Aseo/Personal");
            }
            else{
                return Page();
            }
        }
    }
}
