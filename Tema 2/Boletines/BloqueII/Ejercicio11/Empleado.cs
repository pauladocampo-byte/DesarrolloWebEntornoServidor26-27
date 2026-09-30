using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio11
{
    abstract class Empleado
    {
        //Atributos
        private String nombre;
        private int edad;
        private double salario;

        //Constantes
        public const double PLUS = 300;
        private bool plusAplicado;

        //Constructores
        public Empleado(String nombre, int edad, double salario)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.salario = salario;
        }

        //Metodos
        public String getNombre()
        {
            return nombre;
        }

        public void setNombre(String nombre)
        {
            this.nombre = nombre;
        }

        public int getEdad()
        {
            return edad;
        }

        public void setEdad(int edad)
        {
            this.edad = edad;
        }

        public double getSalario()
        {
            return salario;
        }

        public void setSalario(double salario)
        {
            this.salario = salario;
        }

        public String toString()
        {
            return "nombre=" + nombre + ", edad=" + edad + ", salario=" + salario + ", ";
        }

        public override String ToString()
        {
            return this.nombre;
        }

        //Metodo abstracto, obliga a las clases hijas que implementen esta función
        public abstract bool plus();

        protected bool AplicarPlusUnaVez()
        {
            if (plusAplicado) return false;
            salario += PLUS;
            plusAplicado = true;
            return true;
        }
    }
}
