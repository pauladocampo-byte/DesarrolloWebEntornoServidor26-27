public class Coche
{
    List<string> marcasValidas = new List<string> { "Toyota", "Seat", "Ford", "Honda" };>
    private string marca;
    public string Marca 
    {
        get 
        { 
            return Marca; 
        }     
        set
        {
            if(marcasValidas.Contains(value))
            {
                Marca = value;
            }
            else
            {
                throw new ArgumentException("Marca no válida");
            }
        }
    }
            
        
    public string Modelo { get; private set; }

    public Coche(string marca, string modelo)
    {
        Marca = marca;
        Modelo = modelo;
    }

    public string Describir()
    {
        return $"La marca es :{Marca} y el modelo es: {Modelo}";
    }
}
