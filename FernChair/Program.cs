using System;
using System.Numerics;

namespace FernChair
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("INPUT");
                Console.WriteLine("------------------------------------------");

                BigInteger numberOfChairs;

                //Allow integer only.
                if (!BigInteger.TryParse(Console.ReadLine(), out numberOfChairs))
                    Console.WriteLine("##########{ERROR}: Invalid Input Value.##########");
                else
                {
                    FernChairPacking startPacking = new FernChairPacking();
                    startPacking.PackFernChairs(numberOfChairs);
                }

                //Console.WriteLine("");
                //Console.WriteLine("");
                //Console.WriteLine("");
                Console.WriteLine("==========================================");
                //Console.WriteLine("Press any key to exit..");
                //Console.WriteLine("==========================================");
                Console.WriteLine("");
                //Console.ReadKey();
            }
        }
    }
}
