using System;
using EjerciciosParcial.Models;
using EjerciciosParcial.Core;
using UI.Utils;

namespace EjerciciosParcial.UI
{
    public static class MenuCajero
    {
        public static void MostrarMenu(CuentaBancaria cuenta)
        {
            Console.Clear(); // Limpieza inicial
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                
                // Configuración de layout
                int ancho = 50;
                int alto = 16;
                int xMenu = 10;
                int yMenu = 3;

                // Dibujado del frame principal
                Dibujo.DibujarCuadroDoble(xMenu, yMenu, ancho, alto);
                Dibujo.EscribirCentradoX(" CAJERO AUTOMÁTICO ", yMenu + 1, colorFondo: ConsoleColor.DarkBlue);
                Dibujo.EscribirIzquierda($"Titular: [TODO]", yMenu + 3, offsetX: xMenu + 3);
                Dibujo.EscribirIzquierda($"Tipo: [TODO] | Saldo: $[TODO]", yMenu + 4, offsetX: xMenu + 3);
                
                Dibujo.DibujarLineaCroppedX("─", new int[] { xMenu + 1, yMenu + 5 }, ancho - 2);

                // Opciones
                Dibujo.EscribirIzquierda("1. Consultar Saldo", yMenu + 7, offsetX: xMenu + 5);
                Dibujo.EscribirIzquierda("2. Depositar Dinero", yMenu + 8, offsetX: xMenu + 5);
                Dibujo.EscribirIzquierda("3. Retirar Dinero", yMenu + 9, offsetX: xMenu + 5);
                Dibujo.EscribirIzquierda("4. Ver Historial", yMenu + 10, offsetX: xMenu + 5);
                Dibujo.EscribirIzquierda("5. Aplicar Interés", yMenu + 11, offsetX: xMenu + 5);
                Dibujo.EscribirIzquierda("6. Salir", yMenu + 13, offsetX: xMenu + 5);

                // Ajuste de posición: bajamos el input para que no se superponga con el borde (alto + yMenu + 2)
                int yInput = yMenu + alto + 1;
                Dibujo.EscribirLienzo(">>> Seleccione Opción: ", xMenu + 5, yInput);
                Console.SetCursorPosition(VarGlobales.origX + xMenu + 27, VarGlobales.origY + yInput);

                string opcion = Console.ReadLine() ?? "";

                // Área de resultados (un poco más abajo del input)
                int yRes = yInput + 2;

                Action menu = opcion switch
                {
                    "1" => () => Dibujo.EscribirLienzo($"SALDO ACTUAL: $[TODO]", xMenu + 5, yRes, ConsoleColor.Cyan),
                    "2" => () => {
                        Dibujo.EscribirLienzo("Monto a depositar: ", xMenu + 5, yRes);
                        Console.ReadLine(); // Simular input
                        Dibujo.EscribirLienzo("[TODO: Implementar depósito]", xMenu + 5, yRes + 1, ConsoleColor.Yellow);
                    },
                    "3" => () => {
                        Dibujo.EscribirLienzo("Monto a retirar: ", xMenu + 5, yRes);
                        Console.ReadLine(); // Simular input
                        Dibujo.EscribirLienzo("[TODO: Implementar retiro]", xMenu + 5, yRes + 1, ConsoleColor.Yellow);
                    },
                    "4" => () => {
                        Console.Clear();
                        Dibujo.DibujarCuadroSimple(5, 2, 70, 15);
                        Dibujo.EscribirCentradoX(" HISTORIAL DE TRANSACCIONES ", 3, colorFondo: ConsoleColor.DarkGray);
                        Dibujo.EscribirIzquierda("[TODO: Implementar historial]", 5, offsetX: 8);
                    },
                    "5" => () => Dibujo.EscribirLienzo("[TODO: Implementar interés]", xMenu + 5, yRes, ConsoleColor.Yellow),
                    "6" => () => { salir = true; Dibujo.EscribirLienzo("Saliendo...", xMenu + 5, yRes, ConsoleColor.Yellow); },
                    _ => () => Dibujo.EscribirLienzo("Opción no válida.", xMenu + 5, yRes, ConsoleColor.Red)
                };

                menu();

                if (!salir)
                {
                    Dibujo.EscribirLienzo("[Presione una tecla para continuar]", xMenu + 5, yRes + 4, ConsoleColor.DarkGray);
                    Console.ReadKey();
                }
            }
            Console.Clear(); // Limpieza final al salir
        }
    }
}
