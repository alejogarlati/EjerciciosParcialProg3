using System;

namespace EjerciciosParcialProg3.Models
{
    public interface INotificador
    {
        string Enviar(string destinatario, string mensaje);
        int MensajesEnviados { get; }
        string PlatNoti {get; }
    }

    // Clase Intermedia: Implementa el Template Method
    public abstract class NotificadorBase : INotificador
    {
        public int MensajesEnviados { get; private set; }
        public abstract string PlatNoti { get; }

        // El método de la interfaz. Lo implementamos acá para no repetirlo en los hijos.
        public string Enviar(string destinatario, string mensaje)
        {
            MensajesEnviados++; // 1. Tarea común a todos (contar)
            return EnviarMensajeConcreto(destinatario, mensaje); // 2. Tarea específica (delegada al hijo)
        }

        // Obligamos a los hijos a que nos digan cómo se envía específicamente
        protected abstract string EnviarMensajeConcreto(string destinatario, string mensaje);
    }

    // Clases Finales: Solo se preocupan por su propia forma de enviar
    public class NotificadorEmail : NotificadorBase
    {
        public override string PlatNoti => "EMAIL";
        protected override string EnviarMensajeConcreto(string destinatario, string mensaje)
        {
            return $"[{PlatNoti}] Enviando correo a {destinatario}: '{mensaje}'";
        }
    }

    public class NotificadorSMS : NotificadorBase
    {
        public override string PlatNoti => "SMS";
        protected override string EnviarMensajeConcreto(string destinatario, string mensaje)
        {
            return $"[{PlatNoti}] Enviando SMS al número {destinatario}: '{mensaje}'";
        }
    }

    public class NotificadorPush : NotificadorBase
    {
        public override string PlatNoti => "PUSH";
        protected override string EnviarMensajeConcreto(string destinatario, string mensaje)
        {
            return $"[{PlatNoti}] Notificando en la app de {destinatario}: '{mensaje}'";
        }
    }
}
