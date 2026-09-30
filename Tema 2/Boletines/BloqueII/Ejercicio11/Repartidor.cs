using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio11
{
    class Repartidor : Empleado
    {
        //Atributos
        private String zona;

        //Constructores
        public Repartidor(String zona, String nombre, int edad, double salario) : base(nombre, edad, salario)
        {
            this.zona = zona;
        }

        //Metodos
        public String getZona()
        {
            return zona;
        }

        public void setZona(String zona)
        {
            this.zona = zona;
        }

    public new String toString()
        {
            return base.toString() + " zona=" + zona;
        }

        /**
         * Si tiene menos de 25 años y la zona es "zona 3",
         * aumentamos el sueldo al empleado
         * @return 
         */
    public override bool plus()
        {

            if (base.getEdad() < 25 && string.Equals(this.zona?.Trim(), "zona 3", StringComparison.OrdinalIgnoreCase))
            {
                return AplicarPlusUnaVez();
            }

            return false;
        }
    }
}
