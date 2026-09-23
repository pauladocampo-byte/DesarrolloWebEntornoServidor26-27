
        double num1, num2;

        // Leer primer número
        Console.Write("Introduce el primer número: ");
        while (!double.TryParse(Console.ReadLine(), out num1))
        {
            Console.Write("Entrada no válida. Intenta de nuevo: ");
        }

        // Leer segundo número
        Console.Write("Introduce el segundo número: ");
        while (!double.TryParse(Console.ReadLine(), out num2))
        {
            Console.Write("Entrada no válida. Intenta de nuevo: ");
        }

        // Operaciones
        double suma = num1 + num2;
        double resta = num1 - num2;
        double producto = num1 * num2;

        // Controlamos división por 0
        string division = num2 != 0
            ? (num1 / num2).ToString()
            : "No se puede dividir entre cero";

        // Mostrar resultados
        Console.WriteLine("\nResultados:");
        Console.WriteLine($"Suma: {suma}");
        Console.WriteLine($"Resta: {resta}");
        Console.WriteLine($"Producto: {producto}");
        Console.WriteLine($"División: {division}");

