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
    public class DetalleSedeModel : PageModel
    {
        private static IRepositorioSede _repoSede = new RepositorioSede(new Persistencia.AppContext());
        
        public Sede Sedes {get;set;}
        
        public IActionResult OnGet(int idSede)
        {
         
            Sedes = _repoSede.GetSede(idSede);
            if(Sedes == null)
            {
                return RedirectToPage("./Sedes");
            }
            else{
                return Page();
            }
        }
    }
}
