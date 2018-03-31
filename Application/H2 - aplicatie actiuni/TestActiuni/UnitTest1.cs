using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogicActiuni;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace TestActiuni
{
    [TestClass]
    public class TestAveragePrice
    {
        [TestMethod]
        public void TestIfFoundAveragePrice()
        {
            #region arrange
            List<Financial_Instrument> fi = new List<Financial_Instrument>();
            Financial_Instrument fin = new Financial_Instrument();
            fin.Symbol = "TLV";
            fin.Price = 20;
            fi.Add(fin);
            Financial_Instrument fin1 = new Financial_Instrument();
            fin1.Symbol = "TLV";
            fin1.Price = 22;
            fi.Add(fin1);

            Financial_Instrument fin2 = new Financial_Instrument();
            fin2.Symbol = "ATLV";
            fin2.Price = 22;
            fi.Add(fin2);

            #endregion
            #region act
            Statistics a = new Statistics(fi);
            #endregion
            #region assert
            Assert.AreEqual(21, a.AveragePrice("TLV"));
            #endregion


        }

        [TestMethod]
        public void TestISymbolNotFound()
        {
            #region arrange
            List<Financial_Instrument> fi = new List<Financial_Instrument>();
            Financial_Instrument fin = new Financial_Instrument();
            fin.Symbol = "TLV";
            fin.Price = 20;
            fi.Add(fin);
            Financial_Instrument fin1 = new Financial_Instrument();
            fin1.Symbol = "TLV";
            fin1.Price = 22;
            fi.Add(fin1);

            Financial_Instrument fin2 = new Financial_Instrument();
            fin2.Symbol = "ATLV";
            fin2.Price = 22;
            fi.Add(fin2);

            #endregion
            #region act
            Statistics a = new Statistics(fi);
            #endregion
            #region assert
            Assert.AreEqual(null, a.AveragePrice("BCR"));
            #endregion


        }
    }

    [TestClass]
    public class TestAverageVolume
    {
        [TestMethod]
        public void TestIfFoundAverageVolume()
        {
            #region arrange
            List<Financial_Instrument> fi = new List<Financial_Instrument>();
            Financial_Instrument fin = new Financial_Instrument();
            fin.Symbol = "SNP";
            fin.Volume = 500;
            fi.Add(fin);
            Financial_Instrument fin1 = new Financial_Instrument();
            fin1.Symbol = "SNP";
            fin1.Volume = 1000;
            fi.Add(fin1);

            Financial_Instrument fin2 = new Financial_Instrument();
            fin2.Symbol = "RRC";
            fin2.Volume = 1000;
            fi.Add(fin2);
            #endregion
            #region act
            Statistics a = new Statistics(fi);
            #endregion
            #region assert
            Assert.AreEqual(750, a.AverageVolume("SNP"));
            #endregion
        }

    }


    [TestClass]
    public class TestDistinct
    {
        [TestMethod]
        public void TestDistinctSymbol1()
        {
            #region arrange
            List<Financial_Instrument> fi = new List<Financial_Instrument>();
            Financial_Instrument fin = new Financial_Instrument();
            fin.Symbol = "SNP";
            fi.Add(fin);
            Financial_Instrument fin1 = new Financial_Instrument();
            fin1.Symbol = "SNP";
            fi.Add(fin1);

            Financial_Instrument fin2 = new Financial_Instrument();
            fin2.Symbol = "RRC";
            fi.Add(fin2);
            #endregion
            #region act
            var simboluri = fi.Select(a => a.Symbol).Distinct().ToArray();
            #endregion
            #region assert
            Assert.AreEqual(2, simboluri.Length);
            #endregion
        }

        [TestMethod]
        public void TestDistinctSymbol2()
        {
            #region arrange
            List<Financial_Instrument> fi = new List<Financial_Instrument>();
            Financial_Instrument fin = new Financial_Instrument();
            fin.firma.Symbol = "SNP";
            fi.Add(fin);
            Financial_Instrument fin1 = new Financial_Instrument();
            fin1.Symbol = "SNP";
            fi.Add(fin1);

            #endregion
            #region act
            var simboluri = fi.Select(a => a.Symbol).Distinct().ToArray();
            #endregion
            #region assert
            Assert.AreEqual(1, simboluri.Length);
            #endregion
        }

        [TestMethod]
        public void TestVirtual()
        {
            FirmaTranzactionata ft = new FirmaTranzactionata();
            Assert.AreEqual(PropertyType.Listed, ft.GetMyProperty());
            Assert.AreEqual(2, ft.x());

            Firma ft1 = new FirmaTranzactionata();
            Assert.AreEqual(PropertyType.Listed, ft1.GetMyProperty());
            Assert.AreEqual(1, ft1.x());

        }

    }


    [TestClass]
    public class TestFile
    {
        [TestMethod]
        public void TestFileExists()
        {
            #region arrange
            //Exista vreo modalitate prin care pot sa preiau calea CurrFile din Program.cs, nu sa o harcodez aici?
            string CurrFile = @"SourceFile.txt";
            #endregion
            #region act
            //trebuie neaparat sa am ceva in sectiunea act?
            #endregion
            #region assert
            Assert.IsTrue(File.Exists(CurrFile));
            #endregion
        }


        [TestMethod]
        public void TestFileNotEmpty()
        {
            #region arrange
            string CurrFile = @"SourceFile.txt";
            #endregion
            #region act
            string[] lines = File.ReadAllLines(CurrFile);
            #endregion
            #region assert
            Assert.AreNotEqual(0, lines.Length);
            #endregion
        }

    }

    [TestClass]
    public class TestStandardDeviation
    {
        [TestMethod]
        public void TestStdev()
        {
            #region arrange
            List<Financial_Instrument> fi = new List<Financial_Instrument>();
            FirmaTranzactionata ft = new FirmaTranzactionata();
            ft.Symbol = "SNP";
            Financial_Instrument fin = new Financial_Instrument(ft);
            
            fin.Price = 5;
            fi.Add(fin);

            FirmaTranzactionata ft1 = new FirmaTranzactionata();
            ft1.Symbol = "SNP";

            Financial_Instrument fin1 = new Financial_Instrument(ft1);
            
            fin1.Price =9;
            fi.Add(fin1);

            Financial_Instrument fin2 = new Financial_Instrument();
            fin2.Symbol = "RRC";
            fin2.Volume = 1000;
            fi.Add(fin2);
            #endregion
            #region act
            Statistics a = new Statistics(fi);
            #endregion
            #region assert
            Assert.AreEqual((decimal)2.83, Math.Round((decimal)a.StandardDev("SNP"),2));  // desi valorile sunt egale, daca unul e tip decimal 
            //si unul e double, nu le considera egale. De ce? Cum pot sa fac sa elimin nevoia asta de conversie?
            #endregion
        }

    }

}

