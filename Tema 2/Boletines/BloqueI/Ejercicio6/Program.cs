using System;

namespace Ejercicio6
{
    class Program
    {
        static void Main(string[] args)
        {
            ReproductorMP3 reproductor = new ReproductorMP3();
            reproductor.CambiarCancion("Viva la vida");
            reproductor.Reproducir();
            reproductor.SubirVolumen(15);
            Console.WriteLine(reproductor);
            reproductor.Pausar();
            Console.WriteLine(reproductor);
        }
    }
}
