using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics;

namespace BusinessLogicActiuni
{
    public class Financial_Instrument
    {
        public Financial_Instrument(FirmaTranzactionata firma=null)
        {
            if (firma == null)
            {
                firma = new FirmaTranzactionata();
            }

            this.firma = firma;
        }
        public string Symbol
        {
            get
            {
                return firma.Symbol;
            }
            set
            {
                firma.Symbol = value;
            }
        }
        public FirmaTranzactionata firma;
        public decimal Price { get; set; }
        public int Volume { get; set; }
        public DateTime TransactionDate { get; set; }

    }
    
}
