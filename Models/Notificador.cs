using System;

namespace EjerciciosParcialProg3.Models
{
    public interface INotificador
    {
        void Enviar(string destinatario, string mensaje);
        int MensajesEnviados { get; }
    }

    public class NotificadorEmail : INotificador {
        
    }
}
