using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen01SO
{
    class Program
    {
        static void Main(string[] args)
        {
        //Menú Principal, menú de Ejemplos
            //Si no Selecciona las opciones del menú, este mostrara un mensaje y cerrara la consola.
            int VNQuantum = 0;
            int VNProceso = 0;
            bool ValidacionQuantum, ValidacionNProceso, Salir;
            Salir = true;
            string Seleccion = "";
            string SeleccionEjem = "";
            Procedimientos pr = new Procedimientos();
            while (Salir!=false)
            {
                
           
            Console.WriteLine("Seleccione..." + "\n" + "a. Para Ejemplos." + "\n" + "b.Para ingresar su propio proceso." + "\n"+"s.Salir.");
            Seleccion = Console.ReadLine();
            Console.Clear();
            switch (Seleccion)
            {
                    
                case "a":
                   
                        Console.WriteLine("Seleccione Ejemplos..." + "\n" + "a. Quantum de 35" + "\n" + "b.Quantum de 20" + "\n" + "c.Quantum de 10" + "\n" + "s.Regresar al menú principal.");
                    SeleccionEjem = Console.ReadLine();
                    switch (SeleccionEjem)
                    {

                        case "a":
                           
                            pr.DatosQuedamos();
                            pr.Validaciones(35);
                            pr.ImprimirDatos();
                            pr.ImprimirProceso();
                            pr.Limpiar();
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case "b":
                           
                            pr.DatosQuedamos();
                            pr.Validaciones(20);
                            pr.ImprimirDatos();
                            pr.ImprimirProceso();
                            pr.Limpiar();
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case "c":
                           
                            pr.DatosQuedamos();
                            pr.Validaciones(10);
                            pr.ImprimirDatos();
                            pr.ImprimirProceso();
                            pr.Limpiar();
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case "s":
                           
                            Console.Clear();
                            break;
                        default:
                            Console.WriteLine("No selecciono ninguna de las opciones especificadas en el Sub-menú.");
                            Console.ReadKey();
                            break;
                    }
            
                    break;
                case "b":
                      //Validación del ingreso Procesos y el Quantum, estos deben de ser numeros.
                        Console.WriteLine("Introduzca el numero de procesos que ingresara");
                        ValidacionNProceso = Int32.TryParse(Console.ReadLine(), out VNProceso);
                        if (ValidacionNProceso && VNProceso != 0)
                        {
                            Console.WriteLine("Introduzca el valor del Quantum ");
                            ValidacionQuantum = Int32.TryParse(Console.ReadLine(), out VNQuantum);
                            if (ValidacionQuantum && VNQuantum != 0)
                            {

                                pr.Cargar(VNProceso);
                                pr.ValidacionesTeclado(VNQuantum);
                                pr.ImprimirDatos();
                                pr.ImprimirProceso();
                                pr.Limpiar();
                                Console.ReadKey();
                                Console.Clear();
                            }

                            
                        }

                        else
                        {

                            Console.Write("Ingreso incorrecto.....");
                            Console.ReadKey();
                            Console.Clear();
                        }

                    break;

                case "s":
                    Salir = false;
                    break;
                default:
              
                    Console.WriteLine("No selecciono ninguna de las opciones especificadas en el menú.");
                    Console.ReadKey();
                     Console.Clear();
                break;
                    
            }



            }


        }
    }
}
