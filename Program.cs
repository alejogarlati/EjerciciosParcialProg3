using System;
using EjerciciosParcial.Models;
using EjerciciosParcial.UI;

namespace EjerciciosParcial
{
    class Program
    {
        static void Main(string[] args)
        {
            // Inicialización de la cuenta (Simulación de inicio de sesión)
            CuentaBancaria miCuenta = new CuentaBancaria("Alejo Garlati", 1000.0, TipoCuenta.Ahorro);

            // Ejecución del menú modularizado
            MenuCajero.MostrarMenu(miCuenta);
        }
    }
}
