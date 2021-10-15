using System;
using System.Collections.Generic;

namespace COVID.App.Dominio
{
    public class HistoriaClinica 
    {
        public int id { get; set; }
        public string Sintoma {get; set;}
        public DateTime fecha {get; set;}
        public Persona persona {get; set;}
    }
}     
