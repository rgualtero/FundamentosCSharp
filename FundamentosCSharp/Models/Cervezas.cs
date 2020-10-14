using System;
using System.Collections.Generic;
using System.Text;

namespace FundamentosCSharp.Models
{
    //Hereda la clase Bebidas asi ya tiene los atributos y metodos de Bebida
    //Implementa la Interface IBebidaAlcoholica para solucionar Multiherencia
    public class Cervezas : Bebidas, IBebidaAlcoholica
    {
        //Atributo de la Interfaz
        public int Alcohol { get; set; }
        public string Marca { get; set; }

        //Constructor para Deserializar Json el cual requiere estar vacio
        public Cervezas() : base(null, 0)             
        {

        }

        //Constructor de la Clase
        public Cervezas (int Cantidad, string Nombre = "Cervezas")
            : base (Nombre, Cantidad)
        {
                    
        }

        //Metodo de la Interfaz
        public void ConsumoMax()
        {
            Console.WriteLine("Metodo de Interfaz Clase Cerveza");
        }


    }
}
