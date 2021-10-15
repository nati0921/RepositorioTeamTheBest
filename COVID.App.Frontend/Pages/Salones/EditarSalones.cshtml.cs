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
    public class EditarSalonesModel : PageModel
    {
        private static IRepositorioSalon _repoSalon = new RepositorioSalon(new Persistencia.AppContext());
        private static IRepositorioSede _repoSede = new RepositorioSede(new Persistencia.AppContext());
        [BindProperty]
        public Salon salones { get; set; }
        public Sede Sedes {get;set;}
        //codigo para crear el formulario de filtro de busqueda 
        public IActionResult OnGet(int? idSalon)
        {   
            if(idSalon.HasValue)
            {   
                salones = _repoSalon.GetSalon(idSalon.Value);
            }
            else
            {
                salones = new Salon();
            }
            
            if(salones == null)
            {
                return RedirectToPage("./Salon/Salones");
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
                if(salones.id>0)
                {
                    salones = _repoSalon.UpdateSalon(salones);
                }
                else
                {
                    _repoSalon.AddSalon(salones);
                }
                return RedirectToPage("./Salones");
            }
        }
    }
}
