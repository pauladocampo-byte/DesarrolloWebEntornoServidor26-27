public class CuentaBancaria
{
    public string Titular { get; private set; }
    
    public decimal Saldo { get; private set; }

    public CuentaBancaria(string titular, decimal saldoInicial)
    {
        if (string.IsNullOrWhiteSpace(titular))
        {
            throw new ArgumentException("El titular es obligatorio.", nameof(titular));
        }

        if (saldoInicial < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(saldoInicial), "El saldo inicial no puede ser negativo.");
        }

        Titular = titular;
        Saldo = saldoInicial;
    }

    public void Ingresar(decimal cantidad)
    {
        if (cantidad <= 0)
        {
            Console.WriteLine("El ingreso debe ser mayor que cero.");
            return;
        }

        Saldo += cantidad;
        Console.WriteLine($"Ingreso de {cantidad:C} realizado correctamente.");
    }

    public bool Retirar(decimal cantidad)
    {
        if (cantidad <= 0)
        {
            Console.WriteLine("La cantidad a retirar debe ser mayor que cero.");
            return false;
        }

        if (cantidad > Saldo)
        {
            Console.WriteLine("No hay saldo suficiente.");
            return false;
        }

        Saldo -= cantidad;
        Console.WriteLine($"Retirada de {cantidad:C} realizada correctamente.");
        return true;
    }

    public bool TieneSaldo()
    {
        return Saldo > 0;
    }

    public void MostrarInformacion()
    {
        Console.WriteLine($"Titular: {Titular}");
        Console.WriteLine($"Saldo: {Saldo:C}");
        Console.WriteLine($"¿Tiene saldo? {TieneSaldo()}");
    }

    // Reto opcional: mover dinero solo si la retirada se completa.
    public bool Transferir(CuentaBancaria destino, decimal cantidad)
    {
        if (destino == null)
        {
            throw new ArgumentNullException(nameof(destino));
        }

        if (ReferenceEquals(this, destino))
        {
            Console.WriteLine("No se puede transferir a la misma cuenta.");
            return false;
        }

        if (!Retirar(cantidad))
        {
            return false;
        }

        destino.Saldo += cantidad;
        Console.WriteLine($"Transferencia a {destino.Titular} realizada correctamente.");
        return true;
    }
}
