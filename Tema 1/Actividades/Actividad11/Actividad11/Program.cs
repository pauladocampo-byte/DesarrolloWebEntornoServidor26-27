
    int montecastelo, cuadrado;
    Console.Write("Introduce un numero: ");

    int.TryParse(Console.ReadLine(), out montecastelo);

    cuadrado = calcularCuadrado(montecastelo);

    Console.WriteLine("El cuadrado es: " + cuadrado);

    Console.ReadKey();


int calcularCuadrado(int numero)
{
    int cuadrado;
    cuadrado = numero * numero;
    return cuadrado;
}