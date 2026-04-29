using System;
using System.Collections.Generic;
using EjerciciosParcialProg3.Models;

namespace EjerciciosParcialProg3.Core
{
    public class GestorNotificaciones
    {
        // TODO: Declarar una lista privada de tipo INotificador
        
        public GestorNotificaciones()
        {
            // TODO: Inicializar la lista
        }

        public void AgregarNotificador(INotificador notificador)
        {
            // TODO: Agregar el notificador a la lista
        }

        public void NotificarATodos(string destinatario, string mensaje)
        {
            // TODO: Recorrer todos los notificadores de la lista e invocar su método Enviar()
        }

        public void MostrarReporte()
        {
            // TODO: Recorrer la lista y mostrar por consola cuántos mensajes envió cada notificador.
            // Pista: Podés usar notificador.GetType().Name para obtener el nombre "NotificadorEmail", etc.
        }
    }
}
