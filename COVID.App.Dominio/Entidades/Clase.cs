using System;
using System.Collections.Generic;

namespace COVID.App.Dominio 
{
    public class Clase
    {
       public int id { get; set; }
       public string nombre { get; set; }
       public Profesor profesor { get; set; }
       public int cantidad_inscritos { get; set; }
       public System.Collections.Generic.List<Estudiante>  estudiante { get; set; }
       public Salon salon { get; set; }
       public string Dia { get; set; }
       public int DuracionClase { get; set;}
       public string hora { get; set; }
    }
}