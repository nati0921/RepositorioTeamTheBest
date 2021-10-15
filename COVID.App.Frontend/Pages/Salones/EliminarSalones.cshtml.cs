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
    public class EliminarSalonesModel : PageModel
    {
        private static IRepositorioSalon _repoSalon = new RepositorioSalon(new Persistencia.AppContext());
        [BindProperty]
        public Salon salones { get; set; }

        public IActionResult OnGet(int idSalon)
        {
            salones = _repoSalon.GetSalon(idSalon);
            return Page();
        }

        public IActionResult OnPost()
        {
            _repoSalon.DeleteSalon(salones.id);
            return RedirectToPage("./Salones");
        }
    }
}
