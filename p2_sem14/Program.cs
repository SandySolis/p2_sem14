using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p2_sem14
{
    internal class Program
    {
        static int[] edades = new int[1000];
        static bool[] vacunados = new bool[1000];
        static int contador = 0;
        static void Main(string[] args)
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("================================");
                Console.WriteLine("Encuesta Covid-19");
                Console.WriteLine("================================");
                Console.WriteLine("1: Realizar Encuesta");
                Console.WriteLine("2: Mostrar Datos de la encuesta");
                Console.WriteLine("3: Mostrar Resultados");
                Console.WriteLine("4: Buscar Personas por edad");
                Console.WriteLine("5: Salir");
                Console.WriteLine("================================");
                Console.Write("Ingrese una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        RealizarEncuesta();
                        break;
                    case 2:
                        MostrarDatos();
                        break;
                    case 3:
                        MostrarResultados();
                        break;
                    case 4:
                        BuscarPorEdad();
                        break;
                }
            } while (opcion != 5);
        }

        static void RealizarEncuesta()
        {
            Console.Clear();
            Console.WriteLine("===================================");
            Console.WriteLine("Encuesta de vacunación");
            Console.WriteLine("===================================");
            Console.Write("¿Qué edad tienes?: ");
            edades[contador] = int.Parse(Console.ReadLine());
            Console.WriteLine("Te has vacunado");
            Console.WriteLine("1: Sí");
            Console.WriteLine("2: No");
            Console.WriteLine("===================================");
            Console.Write("Ingrese una opción: ");
            vacunados[contador] = int.Parse(Console.ReadLine()) == 1;
            contador++;

            Console.Clear();
            Console.WriteLine("===================================");
            Console.WriteLine("Encuesta de vacunación");
            Console.WriteLine("===================================");
            Console.WriteLine("¡Gracias por participar!");
            Console.WriteLine("===================================");
            Console.WriteLine("Presione una tecla ...");
            Console.ReadKey();
        }

        static void MostrarDatos()
        {
            Console.Clear();
            Console.WriteLine("===================================");
            Console.WriteLine("Datos de la encuesta");
            Console.WriteLine("===================================");
            Console.WriteLine("ID    | Edad | Vacunado");
            Console.WriteLine("=======================");
            for (int i = 0; i < contador; i++)
            {
                Console.WriteLine($"{i.ToString("D4")}  |  {edades[i]}  |   {(vacunados[i] ? "Si" : "No")}");
            }
            Console.WriteLine("===================================");
            Console.WriteLine("Presione una tecla para regresar ...");
            Console.ReadKey();
        }

        static void MostrarResultados()
        {
            int vacunadosCount = 0;
            int[] rangosEdad = new int[6];
            for (int i = 0; i < contador; i++)
            {
                if (vacunados[i])
                    vacunadosCount++;
                if (edades[i] <= 20)
                    rangosEdad[0]++;
                else if (edades[i] <= 30)
                    rangosEdad[1]++;
                else if (edades[i] <= 40)
                    rangosEdad[2]++;
                else if (edades[i] <= 50)
                    rangosEdad[3]++;
                else if (edades[i] <= 60)
                    rangosEdad[4]++;
                else
                    rangosEdad[5]++;
            }

            Console.Clear();
            Console.WriteLine("===================================");
            Console.WriteLine("Resultados de la encuesta");
            Console.WriteLine("===================================");
            Console.WriteLine($"{vacunadosCount} personas se han vacunado");
            Console.WriteLine($"{contador - vacunadosCount} personas no se han vacunado");
            Console.WriteLine("Existen:");
            Console.WriteLine($"{rangosEdad[0]} personas entre 01 y 20 años");
            Console.WriteLine($"{rangosEdad[1]} personas entre 21 y 30 años");
            Console.WriteLine($"{rangosEdad[2]} personas entre 31 y 40 años");
            Console.WriteLine($"{rangosEdad[3]} personas entre 41 y 50 años");
            Console.WriteLine($"{rangosEdad[4]} personas entre 51 y 60 años");
            Console.WriteLine($"{rangosEdad[5]} personas de más de 61  años");
            Console.WriteLine("===================================");
            Console.WriteLine("Presione una tecla para regresar ...");
            Console.ReadKey();
        }

        static void BuscarPorEdad()
        {
            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("Busca a personas por edad");
            Console.WriteLine("================================");
            Console.Write("¿Qué edad quieres buscar?: ");
            int edadBuscada = int.Parse(Console.ReadLine());

            int vacunadosCount = 0;
            int noVacunadosCount = 0;
            for (int i = 0; i < contador; i++)
            {
                if (edades[i] == edadBuscada)
                {
                    if (vacunados[i])
                        vacunadosCount++;
                    else
                        noVacunadosCount++;
                }
            }

            Console.WriteLine($"{vacunadosCount} se vacunaron");
            Console.WriteLine($"{noVacunadosCount} no se vacunaron");
            Console.WriteLine("================================");
            Console.WriteLine("Presione una tecla para regresar ...");
            Console.ReadKey();
        }
    }
}


