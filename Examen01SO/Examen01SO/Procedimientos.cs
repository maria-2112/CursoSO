using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen01SO
{
    class Procedimientos
    {
        //Se inicializan las listas y el Quantum
        public List<Procesos> ListaProcesos = new List<Procesos>();
        public List<Datos> ListaDatos = new List<Datos>();
        public int Quantum;
        public static int acumulador = 0;
        public void Cargar(int numProceso)
        {
            string proceso = "";
            bool ValidacionBurst_Time;
            int VNumBurst_Time = 0;
            var dato = new Datos();
            int contador = 0;

            for (int i = 0; i < numProceso; )
            {

                Console.Write("Ingrese el nombre del proceso:");

                proceso = Console.ReadLine();
                i++;
                do
                { //Valida que el Burst_Time sea un numero
                    Console.Write("Ingrese el Burst Time del proceso " + proceso + " :");
                    ValidacionBurst_Time = Int32.TryParse(Console.ReadLine(), out VNumBurst_Time);

                    if (ValidacionBurst_Time && VNumBurst_Time != 0)
                    {
                        contador++;
                        acumulador = acumulador + VNumBurst_Time;
                        //Se inicializa y agregar el objeto a la lista.
                        ListaDatos.Add(new Datos()
                        {
                            NumProceso = proceso,
                            Bust_time = VNumBurst_Time,
                            rafaga = VNumBurst_Time
                        });

                    }

                } while (contador < i);

            }

        }

        public void ImprimirDatos()
        { //Simula la tabla de valores inicial
            Console.WriteLine("\n");
            Console.WriteLine("Proceso  Burst_Time");

            for (int f = 0; f < ListaDatos.Count; f++)
            {
                Console.WriteLine("[" + ListaDatos[f].NumProceso + "]" + "      " + "[" + ListaDatos[f].Bust_time + "]");
            }
        }

        public void ImprimirProceso()
        { //Imprime los intervalos de ejecucion, ademas del Quantum utilizado y el contexto
            Console.WriteLine("\n\r");
            Console.WriteLine("Tiempo de Ejecucion");
            for (int f = 0; f < ListaProcesos.Count; f++)
            {

                Console.Write("[" + ListaProcesos[f].Proceso + " " + ListaProcesos[f].Tiempo_Ejecucion + "]" + "-");
            }

            Console.WriteLine("\n\r");
            Console.WriteLine("El Quantum es: " + Quantum);
            int contexto = ListaProcesos.Count - 1;
            Console.WriteLine("El numero de Cambios de Contexto es-> " + contexto);
        }
        public void Validaciones(int quantum)
        {   //Recolecta el quantum, establece el tiempo total de ejecución y recorre la lista hasta que el tiempo total llegue a 0.
            Quantum = quantum;

            var proceso = new Procesos();
            for (int i = 0; i < ListaDatos.Count; i++)
            {

                acumulador = acumulador + ListaDatos[i].Bust_time;
            }
            while (acumulador != 0)
            {
                for (int i = 0; i < ListaDatos.Count; i++)
                {

                    AgregarProcesos(ListaDatos[i]);
                }
            }
        }
        public void Limpiar()
        {
            ListaDatos.Clear();
            ListaProcesos.Clear();
        }
        public void ValidacionesTeclado(int quantum)
        { //Recolecta el quantum, recorre la lista hasta que el tiempo total llegue a 0, el tiempo de ejecución se va estableciendo a medida que se ingresan los valores.
            Quantum = quantum;

            var proceso = new Procesos();


            while (acumulador != 0)
            {
                for (int i = 0; i < ListaDatos.Count; i++)
                {

                    AgregarProcesos(ListaDatos[i]);
                }
            }
        }

        public void AgregarProcesos(Datos pdato)
        {
            pdato.Residuo = 0; //Obtiene el tiempo de ejecucion del proceso por agregar
            //Agrega el elemento inicial de los tiempos de ejecucion
            if (ListaProcesos.Count.Equals(0))
            {
                ListaProcesos.Add(new Procesos()
                {
                    Proceso = pdato.NumProceso,
                    Tiempo_Ejecucion = 0
                });
            }

            //Ejecucion del algoritmo de round robin.
            pdato.Residuo = ListaProcesos.Count > 0 ? ListaProcesos[ListaProcesos.Count - 1].Tiempo_Ejecucion : 0;
            if (pdato.rafaga != 0)
            {
                if (pdato.rafaga >= Quantum)
                {
                    pdato.rafaga = pdato.rafaga - Quantum;
                    pdato.Residuo = pdato.Residuo + Quantum;
                    acumulador = acumulador - Quantum;
                    if (acumulador < 0) { acumulador = 0; }

                }
                else
                {
                    if (pdato.rafaga < pdato.Bust_time)
                    {

                        pdato.Residuo = pdato.Residuo + pdato.rafaga;
                        acumulador = acumulador - pdato.rafaga;
                        if (acumulador < 0) { acumulador = 0; }
                        pdato.rafaga = 0;

                    }
                    else
                    {
                        pdato.rafaga = pdato.Bust_time - pdato.rafaga;
                        pdato.Residuo = pdato.Residuo + pdato.Bust_time;
                        acumulador = acumulador - pdato.Bust_time;
                        if (acumulador < 0) { acumulador = 0; }

                    }

                }

                ListaProcesos.Add(new Procesos()
                {
                    Proceso = pdato.NumProceso,
                    Tiempo_Ejecucion = pdato.Residuo
                });

            }
        }


        public void DatosQuedamos()
        { //Datos para los Ejemplos
            ListaDatos.Add(new Datos()
            {
                NumProceso = "P1",
                Bust_time = 53,
                rafaga = 53
            });
            ListaDatos.Add(new Datos()
            {
                NumProceso = "P2",
                Bust_time = 17,
                rafaga = 17
            });
            ListaDatos.Add(new Datos()
            {
                NumProceso = "P3",
                Bust_time = 68,
                rafaga = 68
            });
            ListaDatos.Add(new Datos()
            {
                NumProceso = "P4",
                Bust_time = 24,
                rafaga = 24
            });

        }

    }
}
