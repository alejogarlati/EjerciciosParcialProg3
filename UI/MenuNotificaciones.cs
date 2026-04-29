using System;
using System.Collections.Generic;
using EjerciciosParcialProg3.Core;
using EjerciciosParcialProg3.Models;
using EjerciciosParcialProg3.Utils;

namespace EjerciciosParcialProg3.UI
{
    public static class MenuNotificaciones
    {
        public static void MostrarMenu()
        {
            // 1. Preparar el Gestor (se hace una sola vez)
            GestorNotificaciones gestor = new GestorNotificaciones();
            gestor.AgregarNotificador(new NotificadorEmail());
            gestor.AgregarNotificador(new NotificadorSMS());
            gestor.AgregarNotificador(new NotificadorPush());

            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                int x = 5, y = 2;
                Dibujo.DibujarCuadroSimple(x, y, 65, 20);
                Dibujo.EscribirCentradoX(" SISTEMA DE NOTIFICACIONES MULTICANAL ", y + 1, colorFondo: ConsoleColor.DarkMagenta);

                Dibujo.EscribirIzquierda("Ingrese Destinatario (o 'salir' para volver): ", y + 3, offsetX: x + 2);
                Console.SetCursorPosition(VarGlobales.origX + x + 49, VarGlobales.origY + y + 3);
                string destinatario = Console.ReadLine() ?? "";

                if (destinatario.ToLower() == "salir")
                {
                    salir = true;
                    continue; // Vuelve al inicio del bucle y sale
                } else if (destinatario == "") {
                    // TODO: Validaciones

                }

                Dibujo.EscribirIzquierda("Ingrese Mensaje: ", y + 5, offsetX: x + 2);
                Console.SetCursorPosition(VarGlobales.origX + x + 23, VarGlobales.origY + y + 5);
                string mensaje = Console.ReadLine() ?? "";

                // 2. Ejecutar la acción
                int currentY = y + 7;
                Dibujo.EscribirLienzo("Enviando notificaciones...", x + 2, currentY++, ConsoleColor.Yellow);

                // El gestor ahora devuelve una lista de strings con los mensajes simulados
                List<string> resultados = gestor.NotificarATodos(destinatario, mensaje);
                foreach (string res in resultados)
                {
                    Dibujo.EscribirLienzo(res, x + 4, currentY++);
                }

                currentY++;
                Dibujo.EscribirLienzo("Reporte de envíos general:", x + 2, currentY++, ConsoleColor.Cyan);
                
                // Pedimos el reporte, que también nos devuelve otra lista de strings
                List<string> reporte = gestor.MostrarReporte();
                foreach (string rep in reporte)
                {
                    Dibujo.EscribirLienzo(rep, x + 4, currentY++);
                }

                Dibujo.EscribirLienzo("[Presione cualquier tecla para enviar otro]", x + 2, currentY + 2, ConsoleColor.DarkGray);
                Console.ReadKey();
            }
        }
    }
}
