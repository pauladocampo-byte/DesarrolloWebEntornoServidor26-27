// El enunciado pide identificar los problemas de cada fragmento.
// Los fragmentos originales se dejan como comentarios para que el proyecto compile.

Console.WriteLine("Ejercicio 3 - Problemas en las sentencias");
Console.WriteLine();

Console.WriteLine("a) v1 = v2: error de compilación. No se convierte implícitamente int a short.");
Console.WriteLine("   Una conversión explícita puede perder información si el valor no cabe en short.");
Console.WriteLine("   short v1 = 379; int v2 = 3500; v1 = v2;");

Console.WriteLine("b) En C#, el tipo se escribe float, no single. Para float, 13.5 necesita el sufijo f.");
Console.WriteLine("   float x1 = 13.5f; double x2 = x1; es válido (conversión ampliadora).");
Console.WriteLine("   decimal x3 = x2; da error: double no se convierte implícitamente a decimal.");

Console.WriteLine("c) short d = 345 es válido, pero byte b = d da error por conversión estrechadora.");
Console.WriteLine("   Aunque 345 cabe en short, no cabe en byte; un cast explícito perdería información.");

Console.WriteLine("d) Math.Sqrt devuelve double y no se asigna implícitamente a int.");
Console.WriteLine("   Hay que decidir cómo convertir o redondear el resultado.");

Console.WriteLine("e) 9 / 5 realiza división entera y da 1 antes de asignarse a decimal.");
Console.WriteLine("   Para obtener 1,8, al menos uno de los operandos debe ser decimal o real.");

Console.WriteLine("f) Console.ReadLine devuelve texto (y puede ser null), no short.");
Console.WriteLine("   Hay que analizar el texto, por ejemplo con short.TryParse.");

Console.WriteLine("g) 30000000 sí cabe en una variable int; no hay problema.");

Console.WriteLine("h) 30000000 no cabe en short. Convert.ToInt16(y) compila, pero lanza OverflowException al ejecutarse.");

/* Fragmentos del enunciado:

// a)
short v1 = 379;
int v2 = 3500;
v1 = v2;

// b) En C# el tipo equivalente a Single es float.
float x1 = 13.5f;
double x2 = x1;
decimal x3 = x2;

// c)
short d = 345;
byte b = d;

// d)
int raiz = Math.Sqrt(9);

// e)
decimal division = 9 / 5;

// f)
short cantidad;
Console.WriteLine("Introduzca cantidad: ");
cantidad = Console.ReadLine();

// g)
int y = 30000000;

// h)
short x = Convert.ToInt16(y);
*/
