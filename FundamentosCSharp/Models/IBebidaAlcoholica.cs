using System;
using System.Collections.Generic;
using System.Text;

namespace FundamentosCSharp.Models
{
    interface IBebidaAlcoholica
    {
        int Alcohol { set; get; }

        void ConsumoMax();

    }
}
