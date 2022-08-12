// https://www.hackerrank.com/challenges/sparse-arrays/problem

using System;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        var inputCount = int.Parse(Console.ReadLine());
        var stringMap = new Dictionary<string, int>();

        for (var i = 0; i < inputCount; i++)
        {
            var input = Console.ReadLine();
            if (stringMap.ContainsKey(input))
                stringMap[input]++;
            else
                stringMap.Add(input, 1);
        }

        var queryCount = int.Parse(Console.ReadLine());
        var output = new int[queryCount];
        for (var i = 0; i < queryCount; i++)
        {
            var queryString = Console.ReadLine();
            if (stringMap.ContainsKey(queryString))
                output[i] = stringMap[queryString];
        }

        foreach (var item in output)
            Console.WriteLine(item);
    }
}
