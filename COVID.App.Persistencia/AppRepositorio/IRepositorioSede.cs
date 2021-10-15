using System.Collections.Generic;
using COVID.App.Dominio;
using System.Linq;

namespace COVID.App.Persistencia 
{
    public interface  IRepositorioSede
    {
         //GetAllSede
        IEnumerable<Sede> GetAllSede();
        //AddSede
        Sede AddSede(Sede sede);
        //UpdateSede
        Sede UpdateSede(Sede sede);
        //DeleteSede
        void DeleteSede(int idSede);
        //GetSede
        Sede GetSede(int idSede);
        
    }
}