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
    public class SedesModel : PageModel
    {
        private static IRepositorioSede _repoSede = new RepositorioSede(new Persistencia.AppContext());
        
        public IEnumerable<Sede> Sedes {get;set;}
        
        public void OnGet()
        {
            Sedes = _repoSede.GetAllSede();
        }
    }
}
