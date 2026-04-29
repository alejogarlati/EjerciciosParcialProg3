using System;
using System.Collections.Generic;
using EjerciciosParcialProg3.Models;

namespace EjerciciosParcialProg3.Core
{
    public class GestorNotificaciones
    {
        private List<INotificador> Notificadores;
        
        public GestorNotificaciones()
        {
            Notificadores = new List<INotificador>();
        }

        public void AgregarNotificador(INotificador notificador)
        {
            Notificadores.Add(notificador);
        }

        public List<string> NotificarATodos(string destinatario, string mensaje)
        {
            List<string> resultados = new List<string>();
            foreach (INotificador n in Notificadores) {
                resultados.Add(n.Enviar(destinatario, mensaje));
            }
            return resultados;
        }

        public List<string> MostrarReporte()
        {
            List<string> reporte = new List<string>();
            foreach (INotificador n in Notificadores) {
                reporte.Add($"Canal {n.PlatNoti}: {n.MensajesEnviados} notificaciones enviadas.");
            }
            return reporte;
        }
    }
}
