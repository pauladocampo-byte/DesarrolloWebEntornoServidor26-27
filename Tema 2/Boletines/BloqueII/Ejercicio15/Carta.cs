namespace Ejercicio15
{
    public class Carta<T>
    {
        public int Numero { get; }
        public T Palo { get; }

        public Carta(int numero, T palo)
        {
            Numero = numero;
            Palo = palo;
        }

        public override string ToString()
        {
            string nombre = Numero.ToString();
            if (Palo is Enumerados.PalosBarajaEspañola)
            {
                nombre = Numero switch
                {
                    1 => "As",
                    10 => "Sota",
                    11 => "Caballo",
                    12 => "Rey",
                    _ => nombre
                };
            }
            else if (Palo is Enumerados.PalosBarajaFrancesa)
            {
                nombre = Numero switch
                {
                    1 => "As",
                    11 => "Jota",
                    12 => "Reina",
                    13 => "Rey",
                    _ => nombre
                };
            }

            return $"{nombre} de {Palo}";
        }
    }
}
