using System.Collections.Generic;
using COVID.App.Dominio;
using System.Linq;

namespace COVID.App.Persistencia 
{
    public interface  IRepositorioPersonal_Aseo
    {
         //GetAllPersonal_Aseo
        
        IEnumerable<Personal_Aseo> GetAllPersonal_Aseo();
        //AddPersonal_Aseo
        Personal_Aseo AddPersonal_Aseo(Personal_Aseo personal_aseo);
        //UpdatePersonal_Aseo
        Personal_Aseo UpdatePersonal_Aseo(Personal_Aseo personal_aseo);
        //DeletePersonal_Aseo
        void DeletePersonal_Aseo(int idPersonal_Aseo);
        //GetPersonal_Aseo
        Personal_Aseo GetPersonal_Aseo(int idPersonal_Aseo);
    }
}