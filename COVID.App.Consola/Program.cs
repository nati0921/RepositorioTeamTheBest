using System;
using COVID.App.Dominio;
using COVID.App.Persistencia;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID.App.Consola
{
    class Program
    {
       private static IRepositorioProfesor _repoProfesor = new RepositorioProfesor(new Persistencia.AppContext());
       private static IRepositorioEstudiante _repoEstudiante = new RepositorioEstudiante(new Persistencia.AppContext());
       private static IRepositorioDirectivo _repoDirectivo = new RepositorioDirectivo(new Persistencia.AppContext());
       private static IRepositorioPersonal_Aseo _repoPersonalAseo = new RepositorioPersonal_Aseo(new Persistencia.AppContext());
        static void Main(string[] args)

        {
            
            
            bool salir = false;
            while (!salir)
            {
               Console.WriteLine("                          Bienvenido                                   ");
               Console.WriteLine("                Asistente para seguimiento COVID-19                     ");
               Console.WriteLine("-----------------------------------------------------------------------");
               Console.WriteLine("                        MENÚ PRINCIPAL                             ");
               Console.ForegroundColor = ConsoleColor.White;
               Console.Write("                           1.Registrar Profesor \n");
                Console.Write("                           2.Registrar Estudiante\n");
                Console.Write("                           3.Registar Directivo\n");
                Console.Write("                           4.Registrar Personal de Aseo\n"); 
                Console.Write("                           5.salir\n");       
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Seleccione opcion...");
                int opcion = Convert.ToInt32(Console.ReadLine());

                //métodos son acciones, las propiedades son valores
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("nombre :");
                        string nombre=Console.ReadLine();
                        Console.WriteLine("apellido :");
                        string apellido=Console.ReadLine();
                        Console.WriteLine("edad :");
                        int edad=Convert.ToInt32(Console.ReadLine());
                        
                        
                        Console.WriteLine("departamento :");
                        string departamento=Console.ReadLine();
                        Console.WriteLine("asignatura :");
                        string asignatura=Console.ReadLine();
                        var profesor =new Profesor()
                        {
                            nombre=nombre,
                            apellido=apellido,
                            edad=edad,
                            estado=Estado.negativo,
                            departamento=departamento,
                            asignatura=asignatura
                        };
                        _repoProfesor.AddProfesor(profesor);
                        
                        

                        Console.Write("Presione una tecla para continuar...");
                        Console.ReadKey();
                        
                        break;

                    case 2:
                        Console.WriteLine("nombre :");
                        string nombreEstudiante=Console.ReadLine();
                        Console.WriteLine("apellido :");
                        string apellidoEstudiante=Console.ReadLine();
                        Console.WriteLine("edad :");
                        int edadEstudiante=Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("carrera :");
                        string carrera=Console.ReadLine();
                        Console.WriteLine("semestre :");
                        int semestre=Convert.ToInt32(Console.ReadLine());
                        var estudiante =new Estudiante()
                        {
                            nombre=nombreEstudiante,
                            apellido=apellidoEstudiante,
                            edad=edadEstudiante,
                            estado=Estado.negativo,
                            carrera=carrera,
                            semestre=semestre
                        };
                        _repoEstudiante.AddEstudiante(estudiante);                                            
                        Console.Write("Presione una tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case 3:
                        Console.WriteLine("nombre :");
                        string nombreDirectivo=Console.ReadLine();
                        Console.WriteLine("apellido :");
                        string apellidoDirectivo=Console.ReadLine();
                        Console.WriteLine("edad :");
                        int edadDirectivo=Convert.ToInt32(Console.ReadLine());
                        
                        
                        Console.WriteLine("facultad :");
                        string facultadDirectivo=Console.ReadLine();
                        var directivo =new Directivo()
                        {
                            nombre=nombreDirectivo,
                            apellido=apellidoDirectivo,
                            edad=edadDirectivo,
                            estado=Estado.negativo,
                            facultad=facultadDirectivo
                        };
                        _repoDirectivo.AddDirectivo(directivo);
                        Console.Write("Presione una tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case 4:
                        Console.WriteLine("nombre :");
                        string nombrePersonalAseo=Console.ReadLine();
                        Console.WriteLine("apellido :");
                        string apellidoPersonalAseo=Console.ReadLine();
                        Console.WriteLine("edad :");
                        int edadPersonalAseo=Convert.ToInt32(Console.ReadLine());
                        
                        
                        //Console.WriteLine("turno :");
                        //Turno turnoPersonalAseo=Console.ReadLine();
                        var personalAseo =new Personal_Aseo()
                        {
                            nombre=nombrePersonalAseo,
                            apellido=apellidoPersonalAseo,
                            edad=edadPersonalAseo,
                            estado=Estado.negativo,
                            turno=Turno.pm
                        };
                        _repoPersonalAseo.AddPersonal_Aseo(personalAseo);
                        Console.Write("Presione una tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 5:
                    salir = true;
                    break;
                    default:
                    Console.WriteLine("Elige una opcion entre 1 y 4");
                    break;

                }
            }
        }
    }
}
