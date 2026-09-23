
    int numeroIngresado = 0, suma = 0;

    Console.Write("Inserta el numero: ");
    int.TryParse(Console.ReadLine(), out numeroIngresado);

    for (int i = 1; i <= numeroIngresado; i += 2)
    {
        suma += i;
    }

    Console.Write("La suma es: " + suma);
    Console.ReadKey();