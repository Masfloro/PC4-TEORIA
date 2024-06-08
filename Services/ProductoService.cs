using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PC4_TEORIA.Models;

namespace PC4_TEORIA.Services
{
    public class ProductoService
    {

        public List<Producto> obtenerTendenciaProductos()
        {
            List<Producto> resultado = new List<Producto>{
                new Producto { ProductoId = 1, NombreProducto = "Schindler's List (1993)" },
                new Producto { ProductoId = 2, NombreProducto = "The Godfather: Part II (1974)" },
                new Producto { ProductoId = 3, NombreProducto = "The Silence of the Lambs (1991)" },
                new Producto { ProductoId = 4, NombreProducto = "Saving Private Ryan (1998)" },
            };

            return resultado;

        }

        public List<Producto> obtenerTodosProductos()
        {
            List<Producto> resultado = new List<Producto>{
                new Producto { ProductoId = 1, NombreProducto = "Schindler's List (1993)" },
                new Producto { ProductoId = 2, NombreProducto = "The Godfather: Part II (1974)" },
                new Producto { ProductoId = 3, NombreProducto = "The Silence of the Lambs (1991)" },
                new Producto { ProductoId = 4, NombreProducto = "Saving Private Ryan (1998)" },
                new Producto { ProductoId = 5, NombreProducto = "Gladiator (2000)" },
                new Producto { ProductoId = 6, NombreProducto = "The Green Mile (1999)" },
                new Producto { ProductoId = 7, NombreProducto = "Braveheart (1995)" },
                new Producto { ProductoId = 8, NombreProducto = "The Departed (2006)" },
                new Producto { ProductoId = 9, NombreProducto = "Titanic (1997)" },
                new Producto { ProductoId = 10, NombreProducto = "Goodfellas (1990)" },
                new Producto { ProductoId = 11, NombreProducto = "The Usual Suspects (1995)" },
                new Producto { ProductoId = 12, NombreProducto = "Se7en (1995)" },
                new Producto { ProductoId = 13, NombreProducto = "Django Unchained (2012)" },
                new Producto { ProductoId = 14, NombreProducto = "The Lion King (1994)" },
                new Producto { ProductoId = 15, NombreProducto = "Back to the Future (1985)" },
                new Producto { ProductoId = 16, NombreProducto = "The Terminator (1984)" },
                new Producto { ProductoId = 17, NombreProducto = "Alien (1979)" },
                new Producto { ProductoId = 18, NombreProducto = "Jaws (1975)" },
                new Producto { ProductoId = 19, NombreProducto = "Jurassic Park (1993)" },
                new Producto { ProductoId = 20, NombreProducto = "The Prestige (2006)" }

            };
            return resultado;
        }

    }
}