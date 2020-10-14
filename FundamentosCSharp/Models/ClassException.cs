using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FundamentosCSharp.Models
{
    public class ClassException
    {
        //Listado
        List<Cervezas> Objcervezas = new List<Cervezas>()
        {
            new Cervezas(){Alcohol=10, Cantidad=100, Marca="Club", Nombre="Negra"},
            new Cervezas(){Alcohol=20, Cantidad=200, Marca="Poker", Nombre="October"},
            new Cervezas(){Alcohol=30, Cantidad=300, Marca="Heineken", Nombre="Michelada"},
            new Cervezas(){Alcohol=40, Cantidad=400, Marca="Corona", Nombre="White"}
        };

        //Metosdo
        public int GetCantidad(string Nombre)
        {
            var cerveza = (from d in Objcervezas
                           where d.Nombre == Nombre
                           select d).First();
            return cerveza.Cantidad;
        }
    }
}
