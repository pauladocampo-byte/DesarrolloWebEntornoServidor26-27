
    int numeroIngresado = 0;
    do
    {
        int factorial = 1;
        Console.Write("Ingresa un numero: ");
        int.TryParse(Console.ReadLine(), out numeroIngresado);

        for (int i = numeroIngresado; i >= 1; i--)
        {
            factorial *= i;
        }

        Console.WriteLine("El factorial de {0} es {1}", numeroIngresado, factorial);

    } while (numeroIngresado > 0);

    Console.ReadKey();
