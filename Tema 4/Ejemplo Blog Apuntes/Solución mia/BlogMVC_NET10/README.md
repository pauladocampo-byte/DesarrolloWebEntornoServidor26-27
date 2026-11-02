# Blog MVC · Proyecto terminado · .NET 10

Proyecto resuelto siguiendo el recorrido de la presentación del tema 4: entidad `Post`, contexto `BlogContext`, configuración de EF Core y migraciones, datos iniciales, `BlogManager`, rutas, `BlogController` y vistas Razor. Las consultas, las acciones y el seed usan métodos síncronos, como en los apuntes de clase.

## Requisitos

- SDK de .NET 10.
- SQL Server LocalDB, o una instancia de SQL Server con una cadena de conexión válida.
- Visual Studio 2026 (versión 18 o posterior) para soporte oficial de `net10.0`; también se puede usar el SDK desde la terminal.

Los paquetes NuGet necesarios ya están declarados en `BlogMVC/BlogMVC.csproj`. Las versiones de Entity Framework Core están alineadas.

## Abrir y ejecutar

1. Abre `BlogMVC.sln` y selecciona `BlogMVC` como proyecto de inicio.
2. Comprueba la cadena `ConexionMontecastelo` en `BlogMVC/appsettings.json`.
3. Abre la Consola del Administrador de paquetes de Visual Studio y selecciona `BlogMVC` como proyecto predeterminado.
4. Aplica la migración incluida con `Update-Database`.
5. `Update-Database` aplica las migraciones y ejecuta `UseSeeding`, que añade tres publicaciones si la tabla está vacía. Después, ejecuta el proyecto: la web consulta y muestra las publicaciones; no ejecuta el seed en cada petición.

## Estado de la entrega

`UseSeeding` está activo. `HasData` está implementado como alternativa comentada en `BlogMVC/Data/BlogContext.cs` y no está activo. Para la explicación docente, consulta `HasData y UseSeeding - Explicacion docente.md` en la carpeta superior `2026-2027`.

El proyecto ya incluye la migración `CrearBlog`. Si quieres practicar la creación de una migración, trabaja sobre una copia: elimina la base de datos de prueba y los archivos de `Migrations`, ejecuta `Add-Migration CrearBlog` y después `Update-Database`.

### Alternativa con .NET CLI

Desde la carpeta `BlogMVC`:

```bash
dotnet tool install --global dotnet-ef --version 10.0.12
dotnet ef database update
```

Para practicar la creación de la migración desde cero, ejecuta `dotnet ef migrations add CrearBlog` antes de `dotnet ef database update`.

## Rutas incluidas

| URL | Resultado |
| --- | --- |
| `/Blog/Index` o `/` | Lista las publicaciones más recientes |
| `/blog/archive/2025/3` | Filtra publicaciones de marzo de 2025 |
| `/blog/1` | Abre un artículo de ejemplo en una base recién creada |
| `/blog/17` | Ejemplo de la ruta dinámica. Muestra el artículo 17 si existe |
| `/blog/9999` | Devuelve 404 porque el artículo no existe |

Los identificadores los genera SQL Server. Usa el enlace **Leer artículo** del listado para abrir siempre una publicación existente.

## Cómo se reparte el código

1. `Models/Post.cs` describe una publicación.
2. `Data/BlogContext.cs` expone `DbSet<Post> Posts`.
3. `Program.cs` configura la conexión y registra `BlogContext` en la DI; EF Core usa ese registro también en tiempo de diseño.
4. `Data/BlogSeed.cs` carga datos de ejemplo con `UseSeeding`.
5. `Program.cs` registra `BlogManager` y declara las rutas.
6. `Managers/BlogManager.cs` contiene consultas LINQ con `ToList` y `FirstOrDefault`.
7. `Controllers/BlogController.cs` llama al Manager y devuelve las vistas.
8. `Views/Blog` contiene `Index.cshtml`, `Archive.cshtml` y `ViewPost.cshtml`.

`BlogManager` es el nombre de la clase que agrupa las consultas. ASP.NET Core recibe esa clase mediante inyección de dependencias.

## Estructura

```text
BlogMVC.sln
└── BlogMVC/
    ├── Controllers/BlogController.cs
    ├── Data/BlogContext.cs
    ├── Data/BlogSeed.cs
    ├── Managers/BlogManager.cs
    ├── Migrations/
    ├── Models/Post.cs
    ├── Views/Blog/
    ├── Program.cs
    └── appsettings.json
```
