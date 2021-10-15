using COVID.App.Dominio;
using System.Collections.Generic;
using System.Linq;

namespace COVID.App.Persistencia

{
    public class RepositorioEstudiante : IRepositorioEstudiante
    {
        private static AppContext  _appContext;

        public RepositorioEstudiante(AppContext appContext)
        {
            _appContext = appContext;
        }

        Estudiante IRepositorioEstudiante.AddEstudiante(Estudiante estudiante)
        {
            var EstudianteAdicionado = _appContext.Estudiantes.Add(estudiante);
            _appContext.SaveChanges();

            return EstudianteAdicionado.Entity;
        }
        Estudiante IRepositorioEstudiante.UpdateEstudiante(Estudiante estudiante)
        {
            var EstudianteEncontrado =_appContext.Estudiantes.FirstOrDefault(e => e.id == estudiante.id);
            if(EstudianteEncontrado!=null)
            {
                EstudianteEncontrado.nombre=estudiante.nombre;
                EstudianteEncontrado.apellido=estudiante.apellido;
                EstudianteEncontrado.edad=estudiante.edad;
                EstudianteEncontrado.estado=estudiante.estado;
                EstudianteEncontrado.carrera=estudiante.carrera;
                EstudianteEncontrado.semestre=estudiante.semestre;
                
                _appContext.SaveChanges();

            }
            return EstudianteEncontrado;

        }
        void IRepositorioEstudiante.DeleteEstudiante(int idEstudiante)
        {
          var EstudianteEncontrado =_appContext.Estudiantes.FirstOrDefault(e => e.id == idEstudiante);
          if (EstudianteEncontrado == null)
              return;
            _appContext.Estudiantes.Remove(EstudianteEncontrado);
            _appContext.SaveChanges();
          
        }

        Estudiante IRepositorioEstudiante.GetEstudiante(int idEstudiante)//Estudiante
        {
           
            var EstudianteEncontrado= _appContext.Estudiantes.FirstOrDefault(e => e.id == idEstudiante);
            return EstudianteEncontrado;

            //Estudiante estudiantes = _appContext.Estudiantes.Where(p => p.id == idEstudiante);
            //var EstudianteEncontrado= estudiantes;
            //return EstudianteEncontrado;
        }

        IEnumerable<Estudiante> IRepositorioEstudiante.GetAllEstudiantes()
        {
            return _appContext.Estudiantes;
        }
    }

    
}