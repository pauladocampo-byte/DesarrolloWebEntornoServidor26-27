    Console.WriteLine("Mi clave segura es: " + GeneradorPassSuperSeguras());
    Console.ReadKey();


 string GeneradorPassSuperSeguras()
{
    string claveSegura = "";

    Random rand = new Random();

    //1 letra mayuscula
    claveSegura += (char)rand.Next('A', 'Z' + 1);

    //Entre 6 y 8 digitos
    int cantidadDigitos = rand.Next(6, 8 + 1);
    for (int i = 0; i < cantidadDigitos; i++)
    {
        //claveSegura += (char)rand.Next('0', '9' + 1);
        claveSegura +=rand.Next(0, 9 + 1);
    }

    //1 simbolo
    claveSegura += (char)rand.Next(33, 47 + 1);

    //2 letras minusculas
    claveSegura += (char)rand.Next('a', 'z' + 1);
    claveSegura += (char)rand.Next('a', 'z' + 1);

    return claveSegura;
}
