Console.Write("Introduce un número entero: ");

if (!int.TryParse(Console.ReadLine(), out int numero))
{
    Console.WriteLine("Debes introducir un número entero válido.");
    return;
}

if (numero % 2 == 0)
{
    Console.WriteLine($"El número {numero} es PAR.");
}
else
{
    Console.WriteLine($"El número {numero} es IMPAR.");
}
