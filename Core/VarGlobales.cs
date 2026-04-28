using System;

namespace EjerciciosParcial.Core
{
    public static class VarGlobales
    {
        public static string[] temas = { "Oscuro", "Claro", "Azul"};
        public static int indiceTemaActual = 0;

        // Pantalla
        public static int origX = Console.CursorLeft + 1;
        public static int origY = Console.CursorTop + 1;
        public static int origWidth = 271;
        public static int origHeight = 71;

        public static (ConsoleColor, ConsoleColor) ObtenerColoresTemaActual()
        {
            ConsoleColor temaActualFondo = ConsoleColor.White;
            ConsoleColor temaActualTexto = ConsoleColor.White;

            if (indiceTemaActual == 0)
            {
                temaActualFondo = ConsoleColor.Black;
                temaActualTexto = ConsoleColor.White;
            }
            else if (indiceTemaActual == 1)
            {
                temaActualFondo = ConsoleColor.White;
                temaActualTexto = ConsoleColor.Black;
            }
            else if (indiceTemaActual == 2)
            {
                temaActualFondo = ConsoleColor.DarkBlue;
                temaActualTexto = ConsoleColor.White;
            }

            return (temaActualFondo, temaActualTexto);
        }
    }
}