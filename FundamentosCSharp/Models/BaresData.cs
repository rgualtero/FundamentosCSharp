using System;
using System.Collections.Generic;
using System.Text;

namespace FundamentosCSharp.Models
{
    public class BaresData
    {
        public string Nombre { get; set; }
        public List<Bebidas> bebidas = new List<Bebidas>();

        
        //Constructor
        public BaresData(string Nombre)
        {
            this.Nombre = Nombre;
        }
    }
}
