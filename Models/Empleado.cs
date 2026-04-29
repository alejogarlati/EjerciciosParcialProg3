using System;

namespace EjerciciosParcialProg3.Models
{
    public abstract class Empleado
    {
        public string Nombre { get; private set; }
        public int Legajo { get; private set; }
        public double SueldoBase { get; protected set; }

        public abstract string TipoEmpleado { get; }

        public abstract double CalcularSueldoMensual();

        public virtual string MostrarInfo() {
            return $"Tipo: {TipoEmpleado}\nEmpleado: {Nombre}\nLegajo: {Legajo}\nSueldo mensual: ${CalcularSueldoMensual():N2}";
        }

        public Empleado(string nombre, int legajo, double sueldoBase) {
            this.Nombre = nombre;
            this.Legajo = legajo;
            this.SueldoBase = sueldoBase;
        }
    }

    public class EmpleadoTiempoCompleto : Empleado {
        public double BonoAnual = 50000;
        public override string TipoEmpleado => "Tiempo Completo";

        public override double CalcularSueldoMensual() {
            return SueldoBase + (BonoAnual / 12);
        }

        public EmpleadoTiempoCompleto(string nombre, int legajo, double sueldoBase) : base(nombre, legajo, sueldoBase) {}

        public override string MostrarInfo() {
            return base.MostrarInfo() + $"\nBono anual total(ya incluído en el sueldo): ${BonoAnual:N2}";
        }
    }

    public class EmpleadoPartTime : Empleado {
        public double SueldoHora { get; private set; }
        public double HorasMes { get; private set;}
        public override string TipoEmpleado => "Part Time";

        public EmpleadoPartTime(string nombre, int legajo, double sueldoHora, double horasMes) : base(nombre, legajo, 0) {
            this.SueldoHora = sueldoHora;
            this.HorasMes = horasMes;
        }

        public override double CalcularSueldoMensual() {
            return SueldoHora * HorasMes;
        }

        public override string MostrarInfo() {
            return base.MostrarInfo() + $"\nSueldo/hora: ${SueldoHora:N2}\nHoras/Mes : {HorasMes}";
        }
    }

    public class EmpleadoContratado : Empleado {
        public DateTime FinContrato { get; private set; }
        public int DiasRestantes => (FinContrato - DateTime.Now).Days;
        public override string TipoEmpleado => "Contratado por Tiempo Determinado";

        public override double CalcularSueldoMensual() {
            return SueldoBase;
        }

        public EmpleadoContratado(string nombre, int legajo, double sueldoBase, DateTime finContrato) : base(nombre, legajo, sueldoBase) {
            this.FinContrato = finContrato;
        }

        public override string MostrarInfo() {
            return base.MostrarInfo() + $"\nFecha de finalización de contrato: {FinContrato:dd/MM/yyyy} ({DiasRestantes} días restantes)";
        }
    }
}
