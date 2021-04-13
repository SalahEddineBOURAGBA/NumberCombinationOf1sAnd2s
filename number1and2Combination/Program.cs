using System;

namespace number1and2Combination
{
    

    class Program
    {
        static void Main(string[] args)
        {
            var solver = new NumberCombinationWith1and2s();
            Console.WriteLine(solver.ComputeNumberOfCombinations(26));

            /*
             * Use the helper to manually genereate all possible combinations
             * It takes some time (~2mn) to compute for 26 but we get the result: 196418
            var resolver = new Helper();
            var a = resolver.Compute(26);
            Console.WriteLine(a.Count);
            */

            /* 
             * print all values
            Console.WriteLine("-------------------");
            foreach(var x in a)
            {
                foreach(var y in x)
                {
                    Console.Write($"{y} ");
                }
                Console.WriteLine();
            }
            */
        }
    }
}
