# Actividad final — Gestión de vehículos

Proyecto de consola .NET 10 que resuelve la actividad final del tema. Las clases están separadas por archivo y agrupadas en espacios de nombres:

- `Models/Vehiculo.cs`: clase base con marca, modelo, constructor y método virtual `MostrarInfo`.
- `Models/Coche.cs`: hereda de `Vehiculo`, llama al constructor base con `base(...)`, añade las puertas y sobrescribe `MostrarInfo` con `override`.
- `Models/Moto.cs`: hereda de `Vehiculo`, reutiliza `base(...)` y añade la cilindrada.
- `Interfaces/IReparable.cs`: contrato con el método `Reparar`.
- `Program.cs`: crea la lista de tipo `List<Vehiculo>`, recorre la flota y demuestra polimorfismo y comprobación de interfaz con `is`.

Se validan datos esenciales (marca, modelo, número de puertas y cilindrada) para evitar objetos inválidos.

Desde esta carpeta, ejecuta:

```sh
dotnet run
```
