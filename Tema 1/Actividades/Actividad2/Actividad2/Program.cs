
    float num1 = 0, num2 = 0, num3 = 0, num4 = 0, num5 = 0, promedio;

    Console.WriteLine("Inserta un numero:");
    if (!float.TryParse(Console.ReadLine(), out num1))
    {
        Console.WriteLine("Ha habido un error a la hora de hacer la conversion");
    }

    Console.Write("Inserta un numero:");
    if (!float.TryParse(Console.ReadLine(), out num2))
    {
        Console.WriteLine("Ha habido un error a la hora de hacer la conversion");
    }

    Console.Write("Inserta un numero:");
    if (!float.TryParse(Console.ReadLine(), out num3))
    {
        Console.WriteLine("Ha habido un error a la hora de hacer la conversion");
    }

    Console.Write("Inserta un numero:");
    if (!float.TryParse(Console.ReadLine(), out num4))
    {
        Console.WriteLine("Ha habido un error a la hora de hacer la conversion");
    }

    Console.Write("Inserta un numero:");
    if (!float.TryParse(Console.ReadLine(), out num5))
    {
        Console.WriteLine("Ha habido un error a la hora de hacer la conversion");
    }

    promedio = (num1 + num2 + num3 + num4 + num5) / 5;

    Console.WriteLine("El promedio de los numeros es: " + promedio);
    Console.ReadKey(); // <--- Agrega esto
