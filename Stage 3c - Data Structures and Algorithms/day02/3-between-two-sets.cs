//https://www.hackerrank.com/challenges/between-two-sets/problem

using System;
using System.Linq;

class Solution
{
    static void Main(String[] args)
    {
        //No need to capture number of elments in set A and B as I use foreach loop to iterate them.
        Console.ReadLine();
        var a_temp = Console.ReadLine().Split(' ');
        var setA = Array.ConvertAll(a_temp, Int32.Parse);
        var b_temp = Console.ReadLine().Split(' ');
        var setB = Array.ConvertAll(b_temp, Int32.Parse);
        int total = getTotalX(setA, setB);
        Console.WriteLine(total);
    }

    static int getTotalX(int[] a, int[] b)
    {
        var totalXs = 0;
        var maximumA = a.Max(); //Time-complexity O(n)
        var minimumB = b.Min(); //Time-complexity O(m)
        var counter = 1;
        var multipleOfMaxA = maximumA;

        while (multipleOfMaxA <= minimumB)
        {
            var factorOfAll = true;
            foreach (var item in a) //Time complexity O(n)
            {
                if (multipleOfMaxA % item != 0)
                {
                    factorOfAll = false;
                    break;
                }
            }
            if (factorOfAll)
            {
                foreach (var item in b) //Time complexity O(m)
                {
                    if (item % multipleOfMaxA != 0)
                    {
                        factorOfAll = false;
                        break;
                    }
                }
            }
            if (factorOfAll)
                totalXs++;
            counter++;
            multipleOfMaxA = maximumA * counter; //Here counter is the x factor which contributes to O(x(n+m)) complexity.
        }
        return totalXs;
    }
}
