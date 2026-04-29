using System;
using EjerciciosParcialProg3.Models;
using EjerciciosParcial.UI;

namespace EjerciciosParcialProg3
{
    class Program
    {
        static void Main()
        {
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("          MENÚ DE EJERCICIOS");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Cajero Automático (Ejercicio 1)");
                Console.WriteLine("2. Sistema de Empleados (Ejercicio 2)");
                Console.WriteLine("3. Salir");
                Console.WriteLine("========================================");
                Console.Write(">>> Seleccione una opción: ");
                
                string opcion = Console.ReadLine() ?? "";

                switch (opcion)
                {
                    case "1":
                        // Inicialización de la cuenta (Simulación de inicio de sesión)
                        var miCuenta = new CuentaBancaria("Alejo Garlati", TipoCuenta.Ahorro);
                        // Ejecución del menú modularizado
                        MenuCajero.MostrarMenu(miCuenta);
                        break;
                    case "2":
                        MenuEmpleados.MostrarMenu();
                        break;
                    case "3":
                        salir = true;
                        Console.WriteLine("\nSaliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("\nOpción no válida. Presione cualquier tecla para intentar nuevamente.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
