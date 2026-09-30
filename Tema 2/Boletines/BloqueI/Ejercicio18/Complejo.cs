using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio18
{
    public class Complejo
    {
        double parteReal;
        double parteImaginaria;

        public Complejo() { }

        public Complejo(double parteReal, double parteImaginaria)
        {
            this.parteReal = parteReal;
            this.parteImaginaria = parteImaginaria;
        }

        public double Real { get => parteReal; }
        public double Imaginaria { get => parteImaginaria; }

        public Complejo Sum(Complejo numero)
        {
            if (numero == null) throw new ArgumentNullException(nameof(numero));
            return new Complejo(parteReal + numero.parteReal, parteImaginaria + numero.parteImaginaria);
        }

        public Complejo Producto(Complejo numero)
        {
            if (numero == null) throw new ArgumentNullException(nameof(numero));
            return new Complejo(
                parteReal * numero.parteReal + parteImaginaria * numero.parteImaginaria,
                parteReal * numero.parteImaginaria + numero.parteReal * parteImaginaria);
        }

        public override string ToString() => $"{parteReal} + {parteImaginaria}i";
    }
}
