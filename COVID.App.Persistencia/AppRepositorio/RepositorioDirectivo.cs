using COVID.App.Dominio;
using System.Collections.Generic;
using System.Linq;

namespace COVID.App.Persistencia  
{
    public class RepositorioDirectivo : IRepositorioDirectivo
    {
        private static AppContext _appContext;

        public RepositorioDirectivo(AppContext appContext)
        {
            _appContext = appContext;
        }

        Directivo IRepositorioDirectivo.AddDirectivo(Directivo directivo)
        {
            var directivoAdicionado = _appContext.Directivos.Add(directivo);
            _appContext.SaveChanges();
           
            return directivoAdicionado.Entity;
        }

        Directivo IRepositorioDirectivo.UpdateDirectivo(Directivo directivo)
        {
           
            var directivoEncontrado = _appContext.Directivos.FirstOrDefault(d => d.id == directivo.id);
            if (directivoEncontrado != null)
            {
                directivoEncontrado.nombre = directivo.nombre;
                directivoEncontrado.apellido = directivo.apellido;
                directivoEncontrado.edad = directivo.edad;
                
                directivoEncontrado.estado =directivo.estado;
                directivoEncontrado.facultad = directivo.facultad;
  
                
                

                _appContext.SaveChanges();
            }
            return directivoEncontrado;
        }

        void IRepositorioDirectivo.DeleteDirectivo (int idDirectivo)
        {
            
            var directivoEncontrado = _appContext.Directivos.FirstOrDefault(d => d.id == idDirectivo);
            if (directivoEncontrado == null)
                return;
            _appContext.Directivos.Remove(directivoEncontrado);
            _appContext.SaveChanges();
        }

        Directivo IRepositorioDirectivo.GetDirectivo(int idDirectivo)
        {
            var directivoEncontrado= _appContext.Directivos.FirstOrDefault(d => d.id == idDirectivo);
            return directivoEncontrado;
        }

        IEnumerable<Directivo> IRepositorioDirectivo.GetAllDirectivos()
        {
            return _appContext.Directivos;
        }
    }
}