using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicActiuni
{
    class Firma_DowJones : FirmaTranzactionata
    {
        public Firma_DowJones()
        {
            ComisionCumparare = (decimal)0.4;
        }
        public override MemberOfIndex GetMemberOfIndex()
        {
            return MemberOfIndex.DowJones;
        }
    }
}
