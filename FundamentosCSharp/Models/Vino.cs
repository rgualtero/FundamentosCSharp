using System;
using System.Collections.Generic;
using System.Text;

namespace FundamentosCSharp.Models
{
    //Hereda la clase Bebidas asi ya tiene los atributos y metodos de Bebida
    //Implementa la Interface IBebidaAlcoholica para solucionar Multiherencia
    class Vino : Bebidas, IBebidaAlcoholica
    {
        public int Alcohol { get; set; }

        public Vino(int Cantidad, string Nombre = "Cervezas")
            : base(Nombre, Cantidad)
        {

        }

        public void ConsumoMax()
        {
            Console.WriteLine("Metodo de Interfaz Clase Vino");
        }
    }
}
