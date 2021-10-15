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
    public class EditarSedeModel : PageModel
    {
        private static IRepositorioSede _repoSede = new RepositorioSede(new Persistencia.AppContext());
        [BindProperty]
        public Sede Sedes {get;set;}

        public IActionResult OnGet(int? idSede)
        {
            if(idSede.HasValue)
            {
                Sedes = _repoSede.GetSede(idSede.Value);
            }
            else
            {
                Sedes = new Sede();
            }
            
            if(Sedes == null)
            {
                return RedirectToPage("./Sedes");
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
                if(Sedes.id>0)
                {
                    Sedes = _repoSede.UpdateSede(Sedes);
                }
                else
                {
                    _repoSede.AddSede(Sedes);
                }
                return RedirectToPage("./Sedes");
            }
        }
        
    }
}
