using System;

namespace FernChair
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("INPUT");
            Console.WriteLine("------------------------------------------");
            
            int numberOfChairs;

            //Allow integer only.
            if (!int.TryParse(Console.ReadLine(), out numberOfChairs))
                Console.WriteLine("##########{ERROR}: Invalid Input Value.##########");
            else
            { 
                FernChairPacking startPacking = new FernChairPacking();
                startPacking.PackFernChairs(numberOfChairs);
            }

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("==========================================");
            Console.WriteLine("Press any key to exit..");
            Console.WriteLine("==========================================");
            Console.ReadKey();
        }
    }
}
