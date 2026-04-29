using System;
using EjerciciosParcialProg3.Core;
using EjerciciosParcialProg3.Models;
using UI.Utils;

namespace EjerciciosParcial.UI
{
    public static class MenuNotificaciones
    {
        public static void MostrarMenu()
        {
            // 1. Preparar el Gestor
            GestorNotificaciones gestor = new GestorNotificaciones();
            // TODO: Agregar los 3 notificadores (Email, SMS, Push) al gestor usando AgregarNotificador()

            Console.Clear();
            int x = 5, y = 2;
            Dibujo.DibujarCuadroSimple(x, y, 60, 15);
            Dibujo.EscribirCentradoX(" SISTEMA DE NOTIFICACIONES MULTICANAL ", y + 1, colorFondo: ConsoleColor.DarkMagenta);

            Dibujo.EscribirIzquierda("Ingrese Destinatario: ", y + 3, offsetX: x + 2);
            Console.SetCursorPosition(VarGlobales.origX + x + 24, VarGlobales.origY + y + 3);
            string destinatario = Console.ReadLine() ?? "Usuario";

            Dibujo.EscribirIzquierda("Ingrese Mensaje: ", y + 5, offsetX: x + 2);
            Console.SetCursorPosition(VarGlobales.origX + x + 19, VarGlobales.origY + y + 5);
            string mensaje = Console.ReadLine() ?? "Hola!";

            // 2. Ejecutar la acción
            Console.SetCursorPosition(VarGlobales.origX + x + 2, VarGlobales.origY + y + 7);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Enviando notificaciones...");
            Console.ResetColor();

            // TODO: Llamar a gestor.NotificarATodos(destinatario, mensaje)

            Console.SetCursorPosition(VarGlobales.origX + x + 2, VarGlobales.origY + y + 11);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Reporte de envíos:");
            Console.ResetColor();
            
            // TODO: Llamar a gestor.MostrarReporte()

            Dibujo.EscribirLienzo("[Presione cualquier tecla para salir]", x + 2, y + 14, ConsoleColor.DarkGray);
            Console.ReadKey();
        }
    }
}
