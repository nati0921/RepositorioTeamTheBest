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
    public class SalonesModel : PageModel
    {
        private static IRepositorioSalon _repoSalon = new RepositorioSalon(new Persistencia.AppContext());
        
        public IEnumerable<Salon> Salones {get;set;}
        
        public void OnGet()
        {
            Salones = _repoSalon.GetAllSalon();
        }
    }
}
