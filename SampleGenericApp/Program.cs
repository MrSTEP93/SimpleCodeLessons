using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleGenericLib;

namespace SampleGenericApp
{
    internal class Program
    {
        public enum Names
        {
            Vasuya = 0,
            Petya,
            Akakiy,
            Katya
        }
        public enum Brands
        {
            Apple = 0,
            Oracle,
            Tesla
        }
        static void Main(string[] args)
        {
            SampleGenericLib.TipaNetwork<Names> networkNames = new TipaNetwork<Names>();
        }

        #region home
        static void Main(string[] args)
        {
            Console.WriteLine("Для имен:");
            TipaNetwork<Names> networkNames = new TipaNetwork<Names>();
            networkNames.SendNahui(Names.Akakiy.ToString());
            networkNames.SendNahui(Brands.Apple.ToString());
            networkNames.SendNahui(Brands.Tesla.ToString());
            networkNames.SendNahui("Pidor");
            networkNames.SendNahui(Names.Petya.ToString());
            networkNames.SendVpizdu(Names.Akakiy);
            //networkNames.SendVpizdu(Brands.Oracle);

            Console.WriteLine("\nДля брендов:");
            TipaNetwork<Brands> networkBrands = new TipaNetwork<Brands>();
            networkBrands.SendNahui(Brands.Oracle.ToString());
            networkBrands.SendNahui(Names.Katya.ToString());
            networkBrands.SendVpizdu(Brands.Apple);
            networkBrands.SendVpizdu(Brands.Oracle);
            networkBrands.SendVpizdu(Brands.Tesla);
            //networkBrands.SendVpizdu(Names.Katya);

            networkNames.ShowInfo(networkNames.ToString());
            networkBrands.ShowInfo(networkBrands.ToString());
            Console.ReadLine();
        }
        #endregion
    }
}
