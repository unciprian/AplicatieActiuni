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
        public string Symbol { get; set; }
        public decimal Price { get; set; }
        public int Volume { get; set; }
        public DateTime TransactionDate { get; set; }

    }
    
}
