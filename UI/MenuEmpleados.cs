using System;
using System.Collections.Generic;
using EjerciciosParcialProg3.Models;
using EjerciciosParcial.Core;
using UI.Utils;

namespace EjerciciosParcial.UI
{
    public static class MenuEmpleados
    {
        public static void MostrarMenu()
        {
            // Instanciamos los empleados de prueba
            List<Empleado> empleados = new List<Empleado>()
            {
                new EmpleadoTiempoCompleto("Carlos Gómez", 1001, 80000),
                new EmpleadoPartTime("Ana Martínez", 2002, 1500, 80), // 80hs a $1500
                new EmpleadoContratado("Luis Pérez", 3003, 60000, new DateTime(2026, 12, 31))
            };

            Console.Clear();
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                
                int ancho = 50;
                int alto = 10;
                int xMenu = 10;
                int yMenu = 3;

                Dibujo.DibujarCuadroDoble(xMenu, yMenu, ancho, alto);
                Dibujo.EscribirCentradoX(" SISTEMA DE EMPLEADOS ", yMenu + 1, colorFondo: ConsoleColor.DarkBlue);
                
                Dibujo.EscribirIzquierda("1. Listar Empleados", yMenu + 3, offsetX: xMenu + 5);
                Dibujo.EscribirIzquierda("2. Calcular Costo Total Nómina", yMenu + 4, offsetX: xMenu + 5);
                Dibujo.EscribirIzquierda("3. Salir", yMenu + 6, offsetX: xMenu + 5);

                int yInput = yMenu + alto + 1;
                Dibujo.EscribirLienzo(">>> Seleccione Opción: ", xMenu + 5, yInput);
                Console.SetCursorPosition(VarGlobales.origX + xMenu + 27, VarGlobales.origY + yInput);

                string opcion = Console.ReadLine() ?? "";
                int yRes = yInput + 2;

                int finalY = yRes;
                
                switch (opcion)
                {
                    case "1":
                        Console.Clear();
                        Dibujo.EscribirCentradoX(" NÓMINA DE EMPLEADOS ", 1, colorFondo: ConsoleColor.DarkGreen);
                        int currentY = 3;
                        double costoNominaListado = 0;
                        foreach (var emp in empleados)
                        {
                            string info = emp.MostrarInfo();
                            // Separamos las líneas del string para dibujarlas una debajo de la otra
                            foreach (var line in info.Split('\n'))
                            {
                                Dibujo.EscribirLienzo(line, 5, currentY++);
                            }
                            Dibujo.DibujarLineaCroppedX("─", new int[] { 5, currentY++ }, 60);
                            currentY++;
                            costoNominaListado += emp.CalcularSueldoMensual();
                        }
                        Dibujo.EscribirLienzo($"COSTO TOTAL DE NÓMINA: ${costoNominaListado:N2}", 5, currentY, ConsoleColor.Cyan);
                        finalY = currentY + 3;
                        break;
                    case "2":
                        double costoTotal = 0;
                        foreach (var emp in empleados)
                        {
                            costoTotal += emp.CalcularSueldoMensual();
                        }
                        Dibujo.EscribirLienzo($"COSTO TOTAL DE NÓMINA: ${costoTotal:N2}", xMenu + 5, yRes, ConsoleColor.Cyan);
                        finalY = yRes + 4;
                        break;
                    case "3":
                        salir = true;
                        Dibujo.EscribirLienzo("Saliendo...", xMenu + 5, yRes, ConsoleColor.Yellow);
                        finalY = yRes + 4;
                        break;
                    default:
                        Dibujo.EscribirLienzo("Opción no válida.", xMenu + 5, yRes, ConsoleColor.Red);
                        finalY = yRes + 4;
                        break;
                }

                if (!salir)
                {
                    Dibujo.EscribirLienzo("[Presione una tecla para continuar]", xMenu + 5, finalY, ConsoleColor.DarkGray);
                    Console.ReadKey();
                }
            }
        }
    }
}
