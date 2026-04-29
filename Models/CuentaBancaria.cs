using System;
using System.Collections.Generic;

namespace EjerciciosParcialProg3.Models
{
    public enum TipoCuenta { Ahorro, Corriente };
    
    public enum TipoTran { Deposito, Retiro};
    
    public class CuentaBancaria
    {
        public int Id { get; private set; }
        private static int autoincrementCuentas = 0;
        
        public string Titular { get; set; }
        public double Saldo { get; private set; }
        public TipoCuenta TipoCuenta { get; private set; }
        
        private readonly List<string> historial = new();
        public IReadOnlyList<string> Historial => historial.AsReadOnly();

        public CuentaBancaria(string titular, TipoCuenta tipoCuenta) {
            Id = autoincrementCuentas++;
            Titular = titular;
            Saldo = 0;
            TipoCuenta = tipoCuenta;
        }

        public string Depositar(double monto) {
            if (monto <= 0) {
                return "El monto no puede ser igual o menor a 0.";
            }
            Saldo += monto;
            RegistrarTran(monto, DateTime.Now, TipoTran.Deposito, Saldo);
            return "Depósito realizado.";
        }

        public string Retirar(double monto) {
            if (monto > Saldo) {
                return "Saldo insuficiente.";
            } else if (monto <= 0) {
                return "Monto inválido.";
            }
            Saldo -= monto;
            RegistrarTran(monto, DateTime.Now, TipoTran.Retiro, Saldo);
            return "Retiro exitoso.";
        }

        private void RegistrarTran(double monto, DateTime fechaHora, TipoTran tipoTran, double saldoHistorico) {
            string registro = $"[{fechaHora:dd/MM/yy HH:mm}] {tipoTran,-8} | Monto: ${monto,8:F2} | Saldo: ${saldoHistorico,8:F2}";
            historial.Add(registro);
        }

        public double[] CalcularEvolucionInteres(int meses) {
            double[] evolucion = new double[meses];
            double tasa = 0.03;

            for (int i = 0; i < meses; i++) {
                if (TipoCuenta == TipoCuenta.Ahorro) {
                    evolucion[i] = Saldo * Math.Pow(1 + tasa, i + 1);
                } else {
                    evolucion[i] = Saldo;
                }
            }
            return evolucion;
        }
    }
}
