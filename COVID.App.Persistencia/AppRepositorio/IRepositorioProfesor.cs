using System.Collections.Generic;
using COVID.App.Dominio;
using System;
using System.Linq;

namespace COVID.App.Persistencia 
{
    public interface  IRepositorioProfesor
    {
         //GetAllProfesores
        
        IEnumerable<Profesor> GetAllProfesores();
        //AddProfesor
        Profesor AddProfesor(Profesor profesor);
        //UpdateProfesor
        Profesor UpdateProfesor(Profesor profesor);
        //DeleteProfesor
        void DeleteProfesor(int idProfesor);
        //GetProfesor
        Profesor GetProfesor(int idProfesor);

        //GetProfesorPorNombre
        IQueryable<Profesor> GetProfesorPorNombre(string filtro);

        //GetProfesor
        IQueryable<Profesor> GetProfesorDetalle(int idProfesor);
        
    }
}