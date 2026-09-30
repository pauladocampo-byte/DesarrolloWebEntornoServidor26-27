using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio14
{
    public class Cuenta
    {
        double saldoActual;

        public Cuenta(double saldoActual)
        {
            if (saldoActual < 0) throw new ArgumentOutOfRangeException(nameof(saldoActual));
            this.SaldoActual = saldoActual;
        }

        public double SaldoActual { get => saldoActual; private set => saldoActual = value; }

        public void Depositar(double ingreso)
        {
            if (ingreso <= 0) throw new ArgumentOutOfRangeException(nameof(ingreso), "El depósito debe ser positivo.");
            SaldoActual += ingreso;
        }

        public void Retirar(double retirada)
        {
            if (retirada <= 0) throw new ArgumentOutOfRangeException(nameof(retirada), "La retirada debe ser positiva.");
            SaldoActual -= retirada;
            if (saldoActual < 0)
            {
                MessageBox.Show("La cuenta está en números rojos");
            }
        }

    }
}
