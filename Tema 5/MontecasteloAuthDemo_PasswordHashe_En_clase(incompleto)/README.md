# MontecasteloAuthDemo — PasswordHasher (.NET 10)

Esta variante almacena contraseñas con `IPasswordHasher<Usuario>` de ASP.NET Core Identity, sin una columna Salt.

## Base de datos aislada

Esta copia usa exclusivamente la base `MontecasteloAuthDemo_PasswordHasher_net10`. `Program.cs` valida que la cadena efectiva `DefaultConnection` (incluidos los valores sobrescritos por variables de entorno) indique exactamente ese catálogo. Antes de aplicar migraciones, comprueba la cadena efectiva y verifica que el destino sea únicamente `MontecasteloAuthDemo_PasswordHasher_net10`. Aplica solo las migraciones de esta copia; no apuntes a `MontecasteloAuthDemo` ni a `MontecasteloAuthDemo_PasswordHasher`.

No hay seed de usuarios ni de administradores. El flujo actual de `/Account/Register` crea usuarios. La opción de rol Administrador existe solo para la demostración en clase: el registro público no debe permitir que los usuarios se asignen Admin a sí mismos en producción.
