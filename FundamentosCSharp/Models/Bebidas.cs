using System;
using System.Collections.Generic;
using System.Text;

namespace FundamentosCSharp.Models
{
    public class Bebidas
    {
        public string Nombre { get; set; }
        public int Cantidad { get; set; }


        //Constructor
        public Bebidas(string Nombre, int Cantidad)
        {
            this.Nombre = Nombre;
            this.Cantidad = Cantidad;
        }


        //Metodo
        public void Beber(int CantidadConsumo)
        {
            this.Cantidad -= CantidadConsumo;
        }

    }
}
