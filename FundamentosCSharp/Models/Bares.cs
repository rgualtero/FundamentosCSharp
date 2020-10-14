using System;
using System.Collections.Generic;
using System.Text;

namespace FundamentosCSharp.Models
{
    public class Bares
    {
        public string Nombre { get; set; }

        public List<Cervezas> BarCerveza = new List<Cervezas>();

        public Bares(string Nombre)
        {
            this.Nombre = Nombre;
        }
    }
}
