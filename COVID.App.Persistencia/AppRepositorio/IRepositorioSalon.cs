using System.Collections.Generic;
using COVID.App.Dominio;
using System.Linq;

namespace COVID.App.Persistencia 
{
    public interface  IRepositorioSalon
    {
         //GetAllSalon
        
        IEnumerable<Salon> GetAllSalon();
         
       
        //AddSalon
        Salon AddSalon(Salon salon);
        //UpdateSede
        Salon UpdateSalon(Salon salon);
        //DeleteSalon
        void DeleteSalon(int idSalon);
        //GetSalon
        Salon GetSalon(int idSalon);
        
    }
}