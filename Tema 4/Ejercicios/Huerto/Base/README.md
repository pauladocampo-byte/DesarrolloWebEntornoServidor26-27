# Base del alumnado — Huerto urbano

Requisitos: .NET 10 SDK y SQL Server Express LocalDB (la configuración `DefaultConnection` apunta a `(localdb)\\MSSQLLocalDB`). Desde esta carpeta ejecuta:

```bash
dotnet run --project HuertoUrbano/HuertoUrbano.csproj
```

La base es un esqueleto MVC compilable con EF Core SQL Server registrado; construye el modelo, contexto y operaciones según el enunciado.
