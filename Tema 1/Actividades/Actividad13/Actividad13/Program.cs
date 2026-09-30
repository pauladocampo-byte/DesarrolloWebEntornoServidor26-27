    bool arraysIguales = true;
    float[] notasAlumnos = new float[] { 5, 8, 9, 4.6f, 7, 6, 2.9f, 10, 1 };
    float[] copiaNotas = new float[notasAlumnos.Length];

    Array.Copy(notasAlumnos, copiaNotas, notasAlumnos.Length);

    for (int i = 0; i < notasAlumnos.Length; i++)
    {
        if (notasAlumnos[i] != copiaNotas[i])
        {
            arraysIguales = false;
            break;
        }
    }
    if (arraysIguales)
    {
        Console.WriteLine("Los arrays son iguales");
    }

    string textoNotasAlumnos = "", textoCopiaNotas = "";
    for (int i = 0; i < notasAlumnos.Length; i++)
    {
        if (i == notasAlumnos.Length - 1)
        {
            textoNotasAlumnos += notasAlumnos[i];
            textoCopiaNotas += copiaNotas[i];
        }
        else
        {
            textoNotasAlumnos += notasAlumnos[i] + ",";
            textoCopiaNotas += copiaNotas[i] + ",";
        }
    }
    Console.WriteLine(textoNotasAlumnos);
    Console.WriteLine(textoCopiaNotas);



