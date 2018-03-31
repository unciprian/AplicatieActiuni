namespace BusinessLogicActiuni
{
    public enum PropertyType
    {
        NotKNown=0,
        PrivateOwnership =1,
        Listed=2
    }
    public abstract class Firma
    {
        public string Name { get; protected set; }
        public virtual PropertyType GetMyProperty()
        {
            return PropertyType.NotKNown;
        }
        public int x()
        {
            return 1;
        }
        public abstract string Country();
    }

    //TODO: implement firma netranzactionata + teste - DONE, mai am de facut teste
    //TODO : lista <firma>, unele tranzactionate, altele not
    // chemat GetMyProperty
    //TODO: citit private, protected, internal, public
    //TODO: implementat un enum care sa zica daca firma e in S&P 500 , DowJones, NasDaq -DONE
    // citit FlagsAttribute  -daca nu te descurci, nu e problema
    // pus ca proprietate pe firmatranzactionata - DONE
    // TODO: facut clase derivate firma S&P 500 si  firma DowJones - DONE
    // pentru care procent comision de cumparare este diferit -DONE
    //TODO:
    // CREAT METODA IN O CLASA
    //DOWNLOADAT https://www.quandl.com/api/v1/datasets/WIKI/MSFT.csv?column=4&sort_order=asc&collapse=quarterly&trim_start=2012-01-01&trim_end=2013-12-31
    // incearca Httpclient C#
    // google for download file C#
    // parsat fisierul  separat cu n, nu \r\n = use split
    // pus in clase si intr-o listaw


    //NEXT TIME :ef
    public class FirmaTranzactionata:Firma
    {
        public enum MemberOfIndex
        {
            NotKnown = 0,
            SP500 = 1,
            DowJones = 2,
            Nasdaq = 4
        }

        public FirmaTranzactionata()
        {
            Name = "andrei";
        }

        public decimal ComisionCumparare { get; protected set; }

        public string Symbol { get; set; }

        public override string Country()
        {
            return "RO";
        }

        public override PropertyType GetMyProperty()
        {
            base.GetMyProperty(); //este necesar sa apelam  functia din base?
            return PropertyType.Listed;
        }
        public int x()
        {
            return 2;
        }

        public virtual MemberOfIndex GetMemberOfIndex ()
        {
            return MemberOfIndex.NotKnown;
        }

    }

    public class FirmaNetranzactionata : Firma
    {
        public FirmaNetranzactionata()
        {
            Name = "netranzactionata";
        }

        public override string Country()
        {
            return "RO";
        }

        public override PropertyType GetMyProperty()
        {
            base.GetMyProperty();
            return PropertyType.PrivateOwnership;
        }
        public int x()
        {
            return 2;
        }
    }



}
