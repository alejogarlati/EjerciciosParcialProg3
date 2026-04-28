using System;
using EjerciciosParcial.Core;

namespace UI.Utils
{
    public static class Dibujo
    {
        public static void EscribirLienzo(string c, int x, int y, ConsoleColor? color = null, ConsoleColor? colorFondo = null)
        {
            var (fondoTema, textoTema) = VarGlobales.ObtenerColoresTemaActual();
            Console.ForegroundColor = color ?? textoTema;
            ConsoleColor colorOriginalFondo = Console.BackgroundColor;
            Console.BackgroundColor = colorFondo ?? fondoTema;
            
            Console.SetCursorPosition(VarGlobales.origX + x, VarGlobales.origY + y);
            Console.Write(c);
            
            Console.BackgroundColor = colorOriginalFondo;
        }

        public static void DibujarLineaFullX(string c, int y, ConsoleColor? color = null, ConsoleColor? colorFondo = null)
        {
            for (int i = 0; i < VarGlobales.origWidth - 1; i++)
            {
                EscribirLienzo(c, i, y, color, colorFondo);
            }
        }

        public static void CentrarCursorX(int y)
        {
            Console.SetCursorPosition(VarGlobales.origWidth / 2, y);
        }

        public static void CentrarCursorY(int x)
        {
            Console.SetCursorPosition(x, VarGlobales.origHeight / 2);
        }

        public static void CursorAlOrigen()
        {
            Console.SetCursorPosition(VarGlobales.origX, VarGlobales.origY);
        }

        public static void EscribirCentradoX(string texto, int y, ConsoleColor? color = null, ConsoleColor? colorFondo = null, bool margen = false)
        {
            int xCentrado = (VarGlobales.origWidth / 2) - (texto.Length / 2);
            EscribirLienzo(texto, xCentrado, y, color, colorFondo);

            if (margen)
            {
            // RELLENO COLOR LATERALES
            EscribirLienzo(" ",xCentrado - 1, y, color, colorFondo);
            EscribirLienzo(" ",xCentrado + texto.Length, y, color, colorFondo);

            //RELLENO COLOR ARRIBA Y ABAJO
            for (int x = xCentrado -1; x <= xCentrado + texto.Length; x++)
            {
                EscribirLienzo(" ", x, y - 1, color, colorFondo);
                EscribirLienzo(" ", x, y + 1, color, colorFondo);
            }
            }
        }

        // Alineado a la izquierda (empieza en la posición 0 del lienzo)
        public static void EscribirIzquierda(string texto, int y, ConsoleColor? color = null, int offsetX = 0, ConsoleColor? colorFondo = null)
        {
            EscribirLienzo(texto, 2 + offsetX, y, color, colorFondo);
        }
        
        // Alineado a la derecha
        public static void EscribirDerecha(string texto, int y, ConsoleColor? color = null, int offsetX = 0, ConsoleColor? colorFondo = null)
        {
            // Calculamos X restando el largo del texto al ancho total
            int xDerecha = VarGlobales.origWidth - texto.Length - 3 - offsetX;
            // Opcional: si quieres que no toque el borde exacto, resta 1 o 2 más
            // int xDerecha = origWidth - texto.Length - 1;
            EscribirLienzo(texto, xDerecha, y, color, colorFondo);
        }

        public static void DibujarLineaCroppedY(string c, int[] coord, int ext, ConsoleColor? color = null, ConsoleColor? colorFondo = null)
        {
            for (int i = 0; i < ext; i++)
            {
                EscribirLienzo(c, coord[0], coord[1] + i, color, colorFondo);
            }
        }

        public static void DibujarCuadroSimple(int x, int y, int ancho, int alto, ConsoleColor? color = null, ConsoleColor? colorFondo = null)
        {
            PintarAreaFondo(x + 1, y + 1, ancho - 2, alto - 2, colorFondo);

            // Líneas horizontales
            DibujarLineaCroppedX("─", new int[] { x + 1, y }, ancho - 2, color, colorFondo);
            DibujarLineaCroppedX("─", new int[] { x + 1, y + alto - 1 }, ancho - 2, color, colorFondo);

            // Líneas verticales (ahora ambas empiezan en y + 1)
            DibujarLineaCroppedY("│", new int[] { x, y + 1 }, alto - 2, color, colorFondo);
            DibujarLineaCroppedY("│", new int[] { x + ancho - 1, y + 1 }, alto - 2, color, colorFondo);

            // Esquinas
            EscribirLienzo("┌", x, y, color, colorFondo);
            EscribirLienzo("┐", x + ancho - 1, y, color, colorFondo);
            EscribirLienzo("└", x, y + alto - 1, color, colorFondo);
            EscribirLienzo("┘", x + ancho - 1, y + alto - 1, color, colorFondo);
        }

        public static void DibujarCuadroDoble(int x, int y, int ancho, int alto, ConsoleColor? color = null, ConsoleColor? colorFondo = null)
        {
            PintarAreaFondo(x + 1, y + 1, ancho - 2, alto - 2, colorFondo);

            // Líneas horizontales
            DibujarLineaCroppedX("═", new int[] { x + 1, y }, ancho - 2, color, colorFondo);
            DibujarLineaCroppedX("═", new int[] { x + 1, y + alto - 1 }, ancho - 2, color, colorFondo);

            // Líneas verticales (ahora ambas empiezan en y + 1)
            DibujarLineaCroppedY("║", new int[] { x, y + 1 }, alto - 2, color, colorFondo);
            DibujarLineaCroppedY("║", new int[] { x + ancho - 1, y + 1 }, alto - 2, color, colorFondo);

            // Esquinas
            EscribirLienzo("╔", x, y, color, colorFondo);
            EscribirLienzo("╗", x + ancho - 1, y, color, colorFondo);
            EscribirLienzo("╚", x, y + alto - 1, color, colorFondo);
            EscribirLienzo("╝", x + ancho - 1, y + alto - 1, color, colorFondo);
        }

        public static void PintarAreaFondo(int x, int y, int ancho, int alto, ConsoleColor? colorFondo = null)
        {
            var (fondoTema, _) = VarGlobales.ObtenerColoresTemaActual();
            ConsoleColor colorOriginalFondo = Console.BackgroundColor;
            Console.BackgroundColor = colorFondo ?? fondoTema;

            string lineaEspacios = new string(' ', ancho);

            for (int i = 0; i < alto; i++)
            {
                Console.SetCursorPosition(VarGlobales.origX + x, VarGlobales.origY + y + i);
                Console.Write(lineaEspacios);
            }

            Console.BackgroundColor = colorOriginalFondo;
        }

        public static void DibujarLineaCroppedX(string c, int[] coord, int ext, ConsoleColor? color = null, ConsoleColor? colorFondo = null)
        {
            int xInicio = coord[0];
            int y = coord[1];

            for (int i = 0; i < ext; i++)
            {
                // Sumamos i a la X para avanzar hacia la derecha
                EscribirLienzo(c, xInicio + i, y, color, colorFondo);
            }
        }
    }
}
