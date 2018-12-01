using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp
{
    public class Day8
    {
        Dictionary<string, int> registers = new Dictionary<string, int>();
        public int Part1(string input, bool part2 = false)
        {
            var maxTotal = 0;
            var lines = input.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
            foreach (var registry in lines.Select(l => l.Substring(0, l.IndexOf(" "))).Distinct())
            {
                registers.Add(registry, 0);
            }

            var ops = lines.Select(l => new
            {
                Registry = l.SubStr(0),
                Increment = l.SubStr(1) == "inc",
                Amount = l.ToInt(2),
                ConditionValid = IsConditionValid(l.SubStr(4), l.SubStr(5), l.ToInt(6))
            });

            foreach (var operation in ops.Where(o => o.ConditionValid))
            {
                if (operation.Increment)
                    registers[operation.Registry] += operation.Amount;
                else
                    registers[operation.Registry] -= operation.Amount;

                if(registers[operation.Registry] > maxTotal)
                    maxTotal = registers[operation.Registry];
            }
            
            return part2 ? maxTotal : registers.Select(r => r.Value).Max();
        }

        private bool IsConditionValid(string name, string operation, int number)
        {
            return operation == ">" ? registers[name] > number :
            operation == "<" ? registers[name] < number :
            operation == ">=" ? registers[name] >= number :
            operation == "<=" ? registers[name] <= number :
            operation == "==" ? registers[name] == number :
            operation == "!=" ? registers[name] != number : 
            throw new Exception("Invalid operation");
        }
    }

    public static class StringExtension
    {
        public static string SubStr(this string s, int pos)
        {
            return s.Split(" ")[pos];
        }
        public static int ToInt(this string s, int pos)
        {
            return int.Parse(s.Split(" ")[pos]);
        }
    }
}