using COVID.App.Dominio;
using System.Collections.Generic;
using System.Linq;

namespace COVID.App.Persistencia  
{
    public class RepositorioSede : IRepositorioSede
    {
        
        private static AppContext _appContext;

        public RepositorioSede(AppContext appContext)
        {
            _appContext = appContext;
        }

       Sede IRepositorioSede.AddSede(Sede sede)
        {
            var sedeAdicionado = _appContext.Sedes.Add(sede);
            _appContext.SaveChanges();
           
            return sedeAdicionado.Entity;
        }

        Sede IRepositorioSede.UpdateSede(Sede sede)
        {
           
            var sedeEncontrado = _appContext.Sedes.FirstOrDefault(s => s.id == sede.id);
            if (sedeEncontrado != null)
            {
                sedeEncontrado.nombre_sede = sede.nombre_sede;
                sedeEncontrado.cantidad_salones = sede.cantidad_salones;
                             
                _appContext.SaveChanges();
            }
            return sedeEncontrado;
        }

        void IRepositorioSede.DeleteSede (int idSede)
        {
            
            var sedeEncontrado = _appContext.Sedes.FirstOrDefault(s => s.id == idSede);
            if (sedeEncontrado == null)
                return;
            _appContext.Sedes.Remove(sedeEncontrado);
            _appContext.SaveChanges();
        }

       Sede IRepositorioSede.GetSede(int idSede)
        {
           
            var sedeEncontrado= _appContext.Sedes.FirstOrDefault(s => s.id == idSede);
            return sedeEncontrado;
        }

        IEnumerable<Sede> IRepositorioSede.GetAllSede()
        {
            return _appContext.Sedes;
        }
         
       
    }
}