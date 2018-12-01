using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp
{
    public class Day7
    {
        Dictionary<string, int> programNameWeight = new Dictionary<string, int>();
        Dictionary<string, List<string>> programRelations = new Dictionary<string, List<string>>();
        private int shouldBe = 0;

        public string Part1(string input)
        {
            input = input.Replace(",", "");
            var programs = input.Split(new[] { Environment.NewLine, " " }, StringSplitOptions.RemoveEmptyEntries).Where(l => !l.Contains("(") && !l.Contains(">")).Select(l => l);
            var notDuplicate = programs.Where(p => programs.Count(x => x == p) == 1);

            return notDuplicate.First();
        }
        
        public int Part2(string input, string startTower)
        {
            shouldBe = 0;
            input = input.Replace(",", "");

            var programLines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Select(l => l);
            foreach (var programString in programLines.Select(p => p.Replace(" (", "_").Replace(")", "")).Select(p => p.Contains(" ") ? p.Substring(0, p.IndexOf(" ")) : p))
            {
                var values = programString.Split("_");
                programNameWeight.Add(values[0], int.Parse(values[1]));
            }
            foreach (var programString in programLines)
            {
                var programName = programString.Substring(0, programString.IndexOf(" "));
                var relatedPrograms = new List<string>();
                if (programString.Contains("->"))
                {
                    var otherPrograms = programString.Substring(programString.IndexOf(">") + 1);
                    foreach (var program in otherPrograms.Replace(",", "")
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(l => l.Trim()))
                    {
                        relatedPrograms.Add(program);
                    }
                }

                programRelations.Add(programName, relatedPrograms);
            }
            
            GetTowerWeight(startTower);

            return shouldBe;
        }
        
        public int GetTowerWeight(string program)
        {
            var programTower = programRelations[program];
            var weight = programNameWeight[program];
            var maxW = int.MinValue;
            var maxWName = "";
            var minW = int.MaxValue;

            foreach (var p in programTower)
            {
                var newWeight = GetTowerWeight(p);
                weight += newWeight;

                if (newWeight > maxW)
                {
                    maxW = newWeight;
                    maxWName = p;
                }
                else if (newWeight < minW)
                {
                    minW = newWeight;
                }
            }

            if (programTower.Any() && shouldBe == 0 && maxW != minW)
            {
                shouldBe = programNameWeight[maxWName] - (maxW - minW);
            }

            return weight;
        }
    }
}
