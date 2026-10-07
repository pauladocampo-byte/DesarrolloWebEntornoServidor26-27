GestorFiguras gestor = new GestorFiguras();
gestor.Agregar(new Circulo("Rojo", 5));
gestor.Agregar(new Rectangulo("Azul", 10, 5));
gestor.Agregar(new Circulo("Verde", 3));
gestor.Agregar(new Rectangulo("Amarillo", 12, 10));

gestor.MostrarTodas();
