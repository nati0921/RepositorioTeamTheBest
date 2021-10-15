using System.Collections.Generic;
using COVID.App.Dominio;
using System.Linq;

namespace COVID.App.Persistencia 
{
    public interface IRepositorioEstudiante
    {   
        //GetAllEstudiante
        IEnumerable<Estudiante> GetAllEstudiantes();
        //AddEstudiante
        Estudiante AddEstudiante(Estudiante estudiante);
        //UpdateEstudiante
        Estudiante UpdateEstudiante(Estudiante estudiante);
        //delete estudiante
        void DeleteEstudiante(int idEstudiante);
        //GetEstudiante
        Estudiante GetEstudiante(int idEstudiante);
    }
}