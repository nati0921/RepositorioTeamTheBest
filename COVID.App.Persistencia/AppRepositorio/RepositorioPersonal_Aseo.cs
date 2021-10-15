using COVID.App.Dominio;
using System.Collections.Generic;
using System.Linq;

namespace COVID.App.Persistencia

{
    public class RepositorioPersonal_Aseo : IRepositorioPersonal_Aseo
    {
        private static AppContext  _appContext;

        public RepositorioPersonal_Aseo(AppContext appContext)
        {
            _appContext = appContext;
        }

        Personal_Aseo IRepositorioPersonal_Aseo.AddPersonal_Aseo(Personal_Aseo personal_aseo)
        {
            var Personal_AseoAdicionado = _appContext.Personal_Aseo.Add(personal_aseo);
            _appContext.SaveChanges();

            return Personal_AseoAdicionado.Entity;
        }
        Personal_Aseo IRepositorioPersonal_Aseo.UpdatePersonal_Aseo(Personal_Aseo personal_aseo)
        {
            var Personal_AseoEncontrado =_appContext.Personal_Aseo.FirstOrDefault(p => p.id == personal_aseo.id);
            if(Personal_AseoEncontrado!=null)
            {
                Personal_AseoEncontrado.nombre=personal_aseo.nombre;
                Personal_AseoEncontrado.apellido=personal_aseo.apellido;
                Personal_AseoEncontrado.edad=personal_aseo.edad;
                Personal_AseoEncontrado.estado=personal_aseo.estado;
                Personal_AseoEncontrado.turno=personal_aseo.turno;
                
                
                _appContext.SaveChanges();

            }
            return Personal_AseoEncontrado;

        }
        void IRepositorioPersonal_Aseo.DeletePersonal_Aseo(int idPersonal_Aseo)
        {
          var Personal_AseoEncontrado =_appContext.Personal_Aseo.FirstOrDefault(p => p.id == idPersonal_Aseo);
          if (Personal_AseoEncontrado == null)
              return;
            _appContext.Personal_Aseo.Remove(Personal_AseoEncontrado);
            _appContext.SaveChanges();
          
        }

        Personal_Aseo IRepositorioPersonal_Aseo.GetPersonal_Aseo(int idPersonal_Aseo)
        {
            var Personal_AseoEncontrado= _appContext.Personal_Aseo.FirstOrDefault(p => p.id == idPersonal_Aseo);
            return Personal_AseoEncontrado;
        }

        IEnumerable<Personal_Aseo> IRepositorioPersonal_Aseo.GetAllPersonal_Aseo()
        {
            return _appContext.Personal_Aseo;
        }
    }

    
}