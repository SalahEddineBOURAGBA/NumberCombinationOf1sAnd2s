using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace number1and2Combination
{
    public class Helper
    {
        private List<HashSet<List<int>>> NList { get; set; }
        public Helper()
        {
            NList = new List<HashSet<List<int>>>();
        }

        public HashSet<List<int>> Compute(int input)
        {
            if(input <= 0)
            {
                return null;
            }

            // Initialise NList
            if(NList.Count <= input)
            {
                for(int i = NList.Count; i <= input; ++i)
                {
                    NList.Add(null);
                }
            }

            if(NList[1] == null)
            {
                NList[1] = new HashSet<List<int>>(new HashSetComparer())
                {
                    new List<int> { 1 }
                };
            }
            
            if (input == 1)
            {
                return NList[1];
            }

            if(NList[2] == null)
            {
                NList[2] = new HashSet<List<int>>(new HashSetComparer())
                {
                    new List<int> { 1, 1 },
                    new List<int> { 2 }
                };
            }
            
            if (NList[input] != null)
            {
                return NList[input];
            }

            for (int i = 3; i <= input; ++i)
            {
                if(NList[i] == null)
                {
                    var result = new HashSet<List<int>>(new HashSetComparer());
                    foreach (var item in NList[i-1])
                    {
                        for(int j = 0; j <= item.Count; ++j)
                        {
                            var temp = new List<int>(item);
                            // combination with 1 by default inserting 1 will definily amount to input
                            temp.Insert(j, 1);
                            result.Add(temp);
                            // combination with 2, add 1 to values with 1 to become 2
                            temp = new List<int>(item);
                            foreach (var elt in Convert1To2(temp))
                            {
                                result.Add(elt);
                            }
                        }
                    }
                    NList[i] = result;
                }
            }

            return NList[input];
        }

        private List<List<int>> Convert1To2(List<int> input)
        {
            var result = new List<List<int>>();
            for(int i = 0; i < input.Count; ++i)
            {
                if(input[i] == 1)
                {
                    var temp = new List<int>(input);
                    temp[i] = 2;
                    result.Add(temp);
                }
            }
            return result;
        }
    }

    public class HashSetComparer : IEqualityComparer<List<int>>
    {
        /*public int Compare([AllowNull] List<int> x, [AllowNull] List<int> y)
        {
            if(x.SequenceEqual(y))
            {
                return 0;
            }

            for(int i=0; i<Math.Min(x.Count, y.Count); ++i)
            {
                if(x[i] != y[i])
                {
                    return x[i].CompareTo(y[i]);
                }
            }

            if(x.Count < y.Count)
            {
                return -1;
            }
            
            return 1;
        }
        */

        public bool Equals([AllowNull] List<int> x, [AllowNull] List<int> y)
        {
            return x.SequenceEqual(y);
        }

        public int GetHashCode([DisallowNull] List<int> input)
        {
            int result = 0;
            for(int i = 0; i < input.Count; ++i)
            {
                result += input[i] * (int)Math.Pow(2, i);
            }
            return result;
        }
    }
}
