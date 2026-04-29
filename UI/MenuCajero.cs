using System;
using EjerciciosParcialProg3.Models;
using EjerciciosParcialProg3.Core;
using EjerciciosParcialProg3.Utils;
using EjerciciosParcialProg3.UI;

namespace EjerciciosParcialProg3.UI
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
                
                // Configuración de layout dinámica
                int maxMenuLen = Math.Max(
                    $"Titular: {cuenta.Titular}".Length,
                    $"Tipo: {cuenta.TipoCuenta} | Saldo: ${cuenta.Saldo:F2}".Length
                );
                int ancho = Math.Max(50, maxMenuLen + 10);
                int alto = 16;
                int xMenu = 10;
                int yMenu = 3;

                // Dibujado del frame principal
                Dibujo.DibujarCuadroDoble(xMenu, yMenu, ancho, alto);
                Dibujo.EscribirCentradoX(" CAJERO AUTOMÁTICO ", yMenu + 1, colorFondo: ConsoleColor.DarkBlue);
                Dibujo.EscribirIzquierda($"Titular: {cuenta.Titular}", yMenu + 3, offsetX: xMenu + 3);
                Dibujo.EscribirIzquierda($"Tipo: {cuenta.TipoCuenta} | Saldo: ${cuenta.Saldo}", yMenu + 4, offsetX: xMenu + 3);
                
                Dibujo.DibujarLineaCroppedX("─", new int[] { xMenu + 1, yMenu + 5 }, ancho - 2);

                // Opciones
                Dibujo.EscribirIzquierda("1. Consultar Saldo", yMenu + 7, offsetX: xMenu + 5);
                Dibujo.EscribirIzquierda("2. Depositar Dinero", yMenu + 8, offsetX: xMenu + 5);
                Dibujo.EscribirIzquierda("3. Retirar Dinero", yMenu + 9, offsetX: xMenu + 5);
                Dibujo.EscribirIzquierda("4. Ver Historial", yMenu + 10, offsetX: xMenu + 5);
                Dibujo.EscribirIzquierda("5. Calcular Interés", yMenu + 11, offsetX: xMenu + 5);
                Dibujo.EscribirIzquierda("6. Salir", yMenu + 13, offsetX: xMenu + 5);

                // Ajuste de posición: bajamos el input para que no se superponga con el borde (alto + yMenu + 2)
                int yInput = yMenu + alto + 1;
                Dibujo.EscribirLienzo(">>> Seleccione Opción: ", xMenu + 5, yInput);
                Console.SetCursorPosition(VarGlobales.origX + xMenu + 27, VarGlobales.origY + yInput);

                string opcion = Console.ReadLine() ?? "";

                // Área de resultados (un poco más abajo del input)
                int yRes = yInput + 2;

                Func<int> menu = opcion switch
                {
                    "1" => () => { Dibujo.EscribirLienzo($"SALDO ACTUAL: ${cuenta.Saldo:F2}", xMenu + 5, yRes, ConsoleColor.Cyan); return yRes + 4; },
                    "2" => () => EjecutarDeposito(cuenta, xMenu, yRes),
                    "3" => () => EjecutarRetiro(cuenta, xMenu, yRes),
                    "4" => () => MostrarHistorial(cuenta),
                    "5" => () => EjecutarInteres(cuenta, xMenu, yRes),
                    "6" => () => { salir = true; Dibujo.EscribirLienzo("Saliendo...", xMenu + 5, yRes, ConsoleColor.Yellow); return yRes + 4; },
                    _ => () => { Dibujo.EscribirLienzo("Opción no válida.", xMenu + 5, yRes, ConsoleColor.Red); return yRes + 4; }
                };

                int finalY = menu();

                if (!salir)
                {
                    Dibujo.EscribirLienzo("[Presione una tecla para continuar]", xMenu + 5, finalY, ConsoleColor.DarkGray);
                    Console.ReadKey();
                }
            }
            Console.Clear(); // Limpieza final al salir
        }

        private static int EjecutarDeposito(CuentaBancaria cuenta, int xMenu, int yRes)
        {
            Dibujo.EscribirLienzo("Monto a depositar: ", xMenu + 5, yRes);
            string montoStr = Console.ReadLine() ?? "";
            if (double.TryParse(montoStr, out double monto))
            {
                string mensaje = cuenta.Depositar(monto);
                Dibujo.EscribirLienzo(mensaje, xMenu + 5, yRes + 1, ConsoleColor.Yellow);
            }
            else
            {
                Dibujo.EscribirLienzo("Debe ingresar un número válido.", xMenu + 5, yRes + 1, ConsoleColor.Red);
            }
            return yRes + 4;
        }

        private static int EjecutarRetiro(CuentaBancaria cuenta, int xMenu, int yRes)
        {
            Dibujo.EscribirLienzo("Monto a retirar: ", xMenu + 5, yRes);
            string montoStr = Console.ReadLine() ?? "";
            if (double.TryParse(montoStr, out double monto))
            {
                string mensaje = cuenta.Retirar(monto);
                Dibujo.EscribirLienzo(mensaje, xMenu + 5, yRes + 1, ConsoleColor.Yellow);
            }
            else
            {
                Dibujo.EscribirLienzo("Debe ingresar un número válido.", xMenu + 5, yRes + 1, ConsoleColor.Red);
            }
            return yRes + 4;
        }

        private static int MostrarHistorial(CuentaBancaria cuenta)
        {
            Console.Clear();
            
            // Calcular el ancho necesario
            int maxLen = " HISTORIAL DE TRANSACCIONES ".Length;
            if (cuenta.Historial.Count == 0)
            {
                maxLen = Math.Max(maxLen, "No hay transacciones registradas.".Length);
            }
            else
            {
                foreach (var t in cuenta.Historial)
                {
                    maxLen = Math.Max(maxLen, t.Length);
                }
            }
            int anchoCuadro = Math.Max(70, maxLen + 8);

            // Ajustar alto del cuadro dependiendo de cuántas transacciones hay
            int altoCuadro = Math.Max(15, cuenta.Historial.Count + 6);
            Dibujo.DibujarCuadroSimple(5, 2, anchoCuadro, altoCuadro);
            Dibujo.EscribirCentradoX(" HISTORIAL DE TRANSACCIONES ", 3, colorFondo: ConsoleColor.DarkGray);
            
            int yOff = 5;
            if (cuenta.Historial.Count == 0)
            {
                Dibujo.EscribirIzquierda("No hay transacciones registradas.", yOff, offsetX: 8);
                yOff++;
            }
            else
            {
                foreach (var t in cuenta.Historial)
                {
                    Dibujo.EscribirIzquierda(t, yOff++, offsetX: 8);
                }
            }
            return yOff + 2;
        }

        private static int EjecutarInteres(CuentaBancaria cuenta, int xMenu, int yRes)
        {
            if (cuenta.TipoCuenta == TipoCuenta.Ahorro)
            {
                Dibujo.EscribirLienzo("Meses a proyectar: ", xMenu + 5, yRes);
                if (int.TryParse(Console.ReadLine(), out int meses) && meses > 0)
                {
                    Console.Clear();
                    double[] evolucion = cuenta.CalcularEvolucionInteres(meses);

                    int maxLen = $" EVOLUCIÓN DEL INTERÉS ({meses} MESES) ".Length;
                    for (int i = 0; i < meses; i++)
                    {
                        string linea = $"Mes {i + 1:D2}: ${evolucion[i]:F2}";
                        maxLen = Math.Max(maxLen, linea.Length);
                    }
                    int anchoCuadro = Math.Max(70, maxLen + 8);

                    int altoCuadro = meses + 6; // Ajustamos el alto del cuadro para que entren todos
                    Dibujo.DibujarCuadroSimple(5, 2, anchoCuadro, altoCuadro);
                    Dibujo.EscribirCentradoX($" EVOLUCIÓN DEL INTERÉS ({meses} MESES) ", 3, colorFondo: ConsoleColor.DarkGray);
                    
                    int yOff = 5;
                    for (int i = 0; i < meses; i++)
                    {
                        Dibujo.EscribirIzquierda($"Mes {i + 1:D2}: ${evolucion[i]:F2}", yOff++, offsetX: 8);
                    }
                    return yOff + 2; // Devolvemos la posición Y debajo del cuadro
                }
                else
                {
                    Dibujo.EscribirLienzo("Cantidad de meses inválida.", xMenu + 5, yRes + 1, ConsoleColor.Red);
                    return yRes + 4;
                }
            }
            else
            {
                Dibujo.EscribirLienzo("Las cuentas corrientes no generan interés.", xMenu + 5, yRes, ConsoleColor.Red);
                return yRes + 4;
            }
        }
    }
}
