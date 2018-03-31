using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicActiuni
{
    class Firma_SP500 : FirmaTranzactionata
    {
        public Firma_SP500()
        {
            ComisionCumparare = (decimal)0.5;
        }
        public override MemberOfIndex GetMemberOfIndex()
        {
            return MemberOfIndex.SP500;
        }
    }
}
