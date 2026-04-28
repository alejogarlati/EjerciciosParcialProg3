using System;
using System.Collections.Generic;

namespace EjerciciosParcial.Models
{
    public enum TipoCuenta { Ahorro, Corriente };
    
    public class CuentaBancaria
    {
        private string _titular { get; set; }
        public double _saldo { get; private set; }
        public TipoCuenta _tipoCuenta { get; private set; }

        public CuentaBancaria(string titular, double saldo, TipoCuenta tipoCuenta) {
            _titular = titular;
            _saldo = 0;
            _tipoCuenta = tipoCuenta;
        }
    }
}
