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
    public class EliminarPersonalModel : PageModel
    {
        private static IRepositorioPersonal_Aseo _repoPersonal = new RepositorioPersonal_Aseo(new Persistencia.AppContext());
        [BindProperty]
        public Personal_Aseo personal_aseo { get; set; }

        public IActionResult OnGet(int idPersonal_Aseo)
        {
            personal_aseo = _repoPersonal.GetPersonal_Aseo(idPersonal_Aseo);
            return Page();
        }

        public IActionResult OnPost()
        {
            
            _repoPersonal.DeletePersonal_Aseo(personal_aseo.id);
            return RedirectToPage("./Personal");
        }
    }
}
