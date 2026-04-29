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
        private static int autoincrementTran = 0;
        
        public string Titular { get; set; }
        public double Saldo { get; private set; }
        public TipoCuenta TipoCuenta { get; private set; }
        private readonly List<Tran> tranList = new();
        public IReadOnlyList<Tran> tranPublic => tranList;

        public CuentaBancaria(string titular, TipoCuenta tipoCuenta) {
            Id = autoincrementCuentas++;
            Titular = titular;
            Saldo = 0;
            TipoCuenta = tipoCuenta;
        }

        public class Tran {
            public int Id { get; private set; }
            public int IdCuenta { get; private set; }
            public double Monto { get; private set; }
            public DateTime FechaHora { get; private set; }
            public TipoTran TipoTran { get; private set; }
            public double SaldoHistorico { get; private set; }

            public Tran(int idCuenta, double monto, DateTime fechaHora, TipoTran tipoTran, double saldoHistorico) {
                Id = autoincrementTran++;
                IdCuenta = idCuenta;
                Monto = monto;
                FechaHora = fechaHora;
                TipoTran = tipoTran;
                SaldoHistorico = saldoHistorico;
            }
        }

        public static string Depositar(CuentaBancaria cuenta, string monto) {
            if (!double.TryParse(monto, out double montoValidado)) {
                return "Debe ingresar un número válido.";
            } else if (montoValidado <= 0) {
                return "El monto no puede ser igual o menor a 0.";
            }
            cuenta.Saldo += montoValidado;
            RegistrarTran(cuenta, montoValidado, DateTime.Now, TipoTran.Deposito, cuenta.Saldo);
            return "Depósito realizado.";
        }

        public static string Retirar(CuentaBancaria cuenta, string monto) {
            if (!double.TryParse(monto, out double montoValidado)) {
                return "Debe ingresar un número válido.";
            } else if (montoValidado > cuenta.Saldo) {
                return "Saldo insuficiente.";
            } else if (montoValidado <= 0) {
                return "Monto inválido";
            }
            cuenta.Saldo -= montoValidado;
            RegistrarTran(cuenta, montoValidado, DateTime.Now, TipoTran.Retiro, cuenta.Saldo);
            return "Retiro exitoso";
        }

        public static void RegistrarTran(CuentaBancaria cuenta, double monto, DateTime fechaHora, TipoTran tipoTran, double saldoHistorico) {
            Tran t = new Tran(cuenta.Id, monto, fechaHora, tipoTran, saldoHistorico);
            cuenta.tranList.Add(t);
        }

        public static double[] CalcularEvolucionInteres(CuentaBancaria cuenta, int meses) {
            double[] evolucion = new double[meses];
            double tasa = 0.03;

            for (int i = 0; i < meses; i++) {
                if (cuenta.TipoCuenta == TipoCuenta.Ahorro) {
                    evolucion[i] = cuenta.Saldo * Math.Pow(1 + tasa, i + 1);
                } else {
                    evolucion[i] = cuenta.Saldo;
                }
            }
            return evolucion;
        }
    }
}
