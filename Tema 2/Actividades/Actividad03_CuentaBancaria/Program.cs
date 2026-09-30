CuentaBancaria cuenta1 = new CuentaBancaria("Paula", 1200m);
CuentaBancaria cuenta2 = new CuentaBancaria("Carlos", 500m);

cuenta1.Ingresar(300m);
cuenta1.Retirar(200m);
cuenta2.Retirar(100m);
cuenta2.Ingresar(50m);

// Reto opcional: prueba una transferencia y después consulta los saldos.
cuenta1.Transferir(cuenta2, 200m);

Console.WriteLine("=== Cuenta 1 ===");
cuenta1.MostrarInformacion();
Console.WriteLine();
Console.WriteLine("=== Cuenta 2 ===");
cuenta2.MostrarInformacion();
