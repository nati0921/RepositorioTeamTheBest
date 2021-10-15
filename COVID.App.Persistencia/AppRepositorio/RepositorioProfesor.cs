using COVID.App.Dominio;
using System.Collections.Generic;
using System;
using System.Linq;


namespace COVID.App.Persistencia  
{
    public class RepositorioProfesor : IRepositorioProfesor
    {
        
        private static AppContext _appContext;

        public RepositorioProfesor(AppContext appContext)
        {
            _appContext = appContext;
        }

        Profesor IRepositorioProfesor.AddProfesor(Profesor profesor)
        {
            var profesorAdicionado = _appContext.Profesores.Add(profesor);
            _appContext.SaveChanges();
           
            return profesorAdicionado.Entity;
        }

        Profesor IRepositorioProfesor.UpdateProfesor(Profesor profesor)
        {
           
            var profesorEncontrado = _appContext.Profesores.FirstOrDefault(p => p.id == profesor.id);
            if (profesorEncontrado != null)
            {
                profesorEncontrado.nombre = profesor.nombre;
                profesorEncontrado.apellido = profesor.apellido;
                profesorEncontrado.edad = profesor.edad;
                
                profesorEncontrado.estado =profesor.estado;
                profesorEncontrado.departamento = profesor.departamento;
                profesorEncontrado.asignatura = profesor.asignatura;

                _appContext.SaveChanges();
            }
            return profesorEncontrado;
        }

        void IRepositorioProfesor.DeleteProfesor (int idProfesor)
        {
            
            var profesorEncontrado = _appContext.Profesores.FirstOrDefault(p => p.id == idProfesor);
            if (profesorEncontrado == null)
                return;
            _appContext.Profesores.Remove(profesorEncontrado);
            _appContext.SaveChanges();
        }
        
        Profesor IRepositorioProfesor.GetProfesor(int idProfesor)
        {
            var ProfesorEncontrado = _appContext.Profesores.FirstOrDefault(p => p.id == idProfesor);
            return ProfesorEncontrado;
        }

        IEnumerable<Profesor> IRepositorioProfesor.GetAllProfesores()
        {
            return _appContext.Profesores;
        }

        IQueryable<Profesor> IRepositorioProfesor.GetProfesorPorNombre(string filtro)
        {
            IQueryable<Profesor> profesores = _appContext.Profesores.Where(p => p.nombre.Contains(filtro));
            var profesorEncontrado = profesores;
            return profesorEncontrado;
        }

        IQueryable<Profesor> IRepositorioProfesor.GetProfesorDetalle(int idProfesor)
        {
            IQueryable<Profesor> profesores = _appContext.Profesores.Where(p => p.id == idProfesor);
            var profesorEncontrado= profesores;
            return profesorEncontrado;
        }
    }
}
