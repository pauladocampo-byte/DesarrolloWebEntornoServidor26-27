using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio8
{
    public class Globo
    {
        private int x = 50;
        private int y = 50;
        private int diametro = 20;
        private string color = "Blanco";

        public Globo(int x, int y, int diametro, string color)
        {
            if (diametro <= 0) throw new ArgumentOutOfRangeException(nameof(diametro));
            X = x;
            Y = y;
            Diametro = diametro;
            Color = color;
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int Diametro
        {
            get => diametro;
            set => diametro = value > 0 ? value : throw new ArgumentOutOfRangeException(nameof(value));
        }
        public string Color { get => color; set => color = string.IsNullOrWhiteSpace(value) ? "Blanco" : value.Trim(); }

    }
}
