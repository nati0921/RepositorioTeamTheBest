using System.Collections.Generic;
using System;

namespace COVID.App.Dominio 
{
    public class Salon 
    {
        public int id { get; set; }
        public int aforo { get; set; }
        public int numerosalon { get; set; }
        public Sede sede { get; set;}
        public string unidad { get; set; }

    }
}