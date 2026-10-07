namespace Forum.Models
{
    public static class ForumData
    {
        private static readonly List<ForumMessage> AspNetMessages =
    [
        new() { Author = "Ana", Subject = "¡Hola, foro!", Body = "Este es el foro de ASP.NET.", PostedAt = new DateTime(2026, 9, 15, 10, 30, 0) },
        new() { Author = "Luis", Subject = "¿Por dónde empiezo?", Body = "Estoy aprendiendo rutas y controladores.", PostedAt = new DateTime(2026, 9, 16, 9, 15, 0) },
        new() { Author = "Marta", Subject = "Una respuesta", Body = "La acción recibe el nombre del foro desde la URL.", PostedAt = new DateTime(2026, 9, 17, 12, 0, 0) },
        new() { Author = "Pablo", Subject = "HTML y Razor", Body = "Razor codifica el texto para mostrarlo con seguridad.", PostedAt = new DateTime(2026, 9, 18, 14, 45, 0) }
    ];

        private static readonly List<ForumMessage> CSharpMessages =
        [
            new() { Author = "Elena", Subject = "¿Qué es una variable?", Body = "Una variable guarda un valor con un nombre y un tipo, por ejemplo int edad = 20;.", PostedAt = new DateTime(2026, 9, 19, 9, 0, 0) },
        new() { Author = "Diego", Subject = "Clases y objetos", Body = "Una clase describe datos y comportamientos; un objeto es una instancia de esa clase.", PostedAt = new DateTime(2026, 9, 20, 10, 30, 0) },
        new() { Author = "Sara", Subject = "¿Para qué sirve una lista?", Body = "List<string> permite almacenar una colección de textos que puede crecer.", PostedAt = new DateTime(2026, 9, 21, 11, 15, 0) }
        ];

        public static List<ForumMessage> GetMessages(string forumName)
        {
            // Las condiciones seleccionan la lista de mensajes según el nombre del foro.
            if (string.Equals(forumName, "asp.net", StringComparison.OrdinalIgnoreCase))
                return AspNetMessages;

            if (string.Equals(forumName, "csharp", StringComparison.OrdinalIgnoreCase))
                return CSharpMessages;

            return [];
        }
    }
}
