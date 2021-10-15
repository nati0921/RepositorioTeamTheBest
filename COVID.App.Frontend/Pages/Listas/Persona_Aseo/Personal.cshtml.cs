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
    public class PersonalModel : PageModel
    {
        private static IRepositorioPersonal_Aseo _repoPersonal = new RepositorioPersonal_Aseo(new Persistencia.AppContext());
        
        public IEnumerable<Personal_Aseo> Personal_Aseo {get;set;}
        
        public void OnGet()
        {
            Personal_Aseo = _repoPersonal.GetAllPersonal_Aseo();
        }
    }
}
