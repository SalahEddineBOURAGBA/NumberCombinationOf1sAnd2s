using System;
using System.Collections.Generic;
using System.Linq;

namespace number1and2Combination
{
    public class NumberCombinationWith1and2s
    {
        private List<List<int>> NList { get; set; }
        public NumberCombinationWith1and2s()
        {
            NList = new List<List<int>>();
        }
        
        public int ComputeNumberOfCombinations(int input)
        {
            if (input <= 0)
            {
                return 0;
            }

            // Initialise NList
            if (NList.Count <= input)
            {
                for (int i = NList.Count; i <= input; ++i)
                {
                    NList.Add(null);
                }
            }

            if (NList[1] == null)
            {
                NList[1] = new List<int>() { 1 };
            }
            if (input == 1)
            {
                return NList[1].Sum();
            }

            if (NList[2] == null)
            {
                NList[2] = new List<int>() { 1, 1 };
            }

            if (NList[input] != null)
            {
                return NList[input].Sum();
            }

            for (int i = 3; i <= input; ++i)
            {
                if (NList[i] == null)
                {
                    var temp = new List<int>();
                    // every number is a combination of 1s
                    temp.Add(1);
                    // The previous number have x (2 + 1s) combinations => if we add 1 to it we'll have x+1 combinations
                    // example 2,1 (2 distinct combinations) => 2, 1, 1 (3 distinct combinations) => 2, 1, 1, 1 (4 distinct combinations)
                    temp.Add(NList[i - 1][1] + 1);
                    // Here where it gets tricky, by observing the pattern of combinations for the first 10 numbers we can formulate
                    // the equation for the combinations possible for each 2s with 1s with 2s > 1 which is:
                    // let Ni the number of 2s and Mi the numbers of 1s in the current iteration
                    // we have comb(Ni, Mi) = comb(Ni-1, (M-1)i-1) + comb((N-1)i-1, (M-1)i-1) 
                    // which can be proved by recursion
                    for (int j = 2; j < NList[i-1].Count; ++j)
                    {
                        temp.Add(NList[i - 1][j] + NList[i - 2][j - 1]);
                    }
                    // if the current number is pair add 1 which is the combination of 2s
                    if(i % 2 == 0)
                    {
                        temp.Add(1);
                    }

                    NList[i] = temp;
                }
            }

            return NList[input].Sum();
        }
    }
}
