using COVID.App.Dominio;
using System.Collections.Generic;
using System.Linq;

namespace COVID.App.Persistencia  
{
    public class RepositorioSalon : IRepositorioSalon
    {
        
        private static AppContext _appContext;

        public RepositorioSalon(AppContext appContext)
        {
            _appContext = appContext;
        }

       Salon IRepositorioSalon.AddSalon(Salon salon)
        {
            var salonAdicionado = _appContext.Salones.Add(salon);
            _appContext.SaveChanges();
           
            return salonAdicionado.Entity;
        }

       Salon IRepositorioSalon.UpdateSalon(Salon salon)
        {
           
            var salonEncontrado = _appContext.Salones.FirstOrDefault(s => s.id == salon.id);
            if (salonEncontrado != null)
            {
                salonEncontrado.aforo = salon.aforo;
                salonEncontrado.numerosalon = salon.numerosalon;
                salonEncontrado.sede= salon.sede;
                salonEncontrado.unidad = salon.unidad;

                _appContext.SaveChanges();
            }
            return salonEncontrado;
        }

        void IRepositorioSalon.DeleteSalon (int idSalon)
        {
            
            var salonEncontrado = _appContext.Salones.FirstOrDefault(s => s.id == idSalon);
            if (salonEncontrado == null)
                return;
            _appContext.Salones.Remove(salonEncontrado);
            _appContext.SaveChanges();
        }

       Salon IRepositorioSalon.GetSalon(int idSalon)
        {
           
            var salonEncontrado= _appContext.Salones.FirstOrDefault(s => s.id == idSalon);
            return salonEncontrado;
        }

        IEnumerable<Salon> IRepositorioSalon.GetAllSalon()
        {
            return _appContext.Salones;
        }
         
       
    }
}