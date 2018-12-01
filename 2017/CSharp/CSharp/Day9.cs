
namespace CSharp
{
    public class Day9
    {
        public int Solve(string input, bool day2 = false)
        {
            var score = 0;
            var level = 0;
            var garbage = false;
            var garbageCount = 0;
            var modified = RemoveEscapedCharacters(input);
            foreach (var c in modified)
            {
                if (c == '>')
                    garbage = false;
                else if (c == '{' && !garbage)
                    level++;
                else if (c == '}' && !garbage)
                {
                    score += level;
                    level--;
                }
                else if (c == '<' && !garbage)
                    garbage = true;
                else if (garbage)
                    garbageCount++;
            }

            return day2 ? garbageCount : score;
        }

        private string RemoveEscapedCharacters(string input)
        {
            while (true)
            {
                if (input.IndexOf("!") > -1)
                    input = input.Remove(input.IndexOf("!"), 2);
                else
                    break;
            }

            return input;
        }

        public int Other(string input)
        {
            int groupCount = 0, score = 0, garbageCount = 0;
            bool inGarbage = false;
            for (int x = 0; x < input.Length; x++)
            {
                char c = input[x];
                if (c == '<' && !inGarbage)
                {
                    inGarbage = true;
                    continue;
                }
                if (inGarbage)
                {
                    if (c == '!')
                    {
                        x++;
                        continue;
                    }
                    if (c == '>')
                    {
                        inGarbage = false;
                        continue;
                    }
                    garbageCount++;
                }
                else
                {
                    if (c == '{')
                    {
                        groupCount++;
                    }
                    else if (c == '}')
                    {
                        score += groupCount;
                        groupCount--;
                    }
                }
            }
            return garbageCount;
        }

        public int Other2(string input)
        {
            int sum = 0;
            int groupNestLevel = 0;
            bool inGarbage = false;
            bool skipNext = false;
            int removedcharacters = 0;
            foreach (var chr in input)
            {
                if (skipNext)
                {
                    skipNext = false;
                    continue;
                }

                if (chr == '!')
                {
                    skipNext = true;
                    continue;
                }

                if (chr == '<')
                {
                    if (inGarbage == false)
                    {
                        inGarbage = true;
                        continue;
                    }
                }
                if (chr == '>')
                {
                    inGarbage = false;
                    continue;
                }

                if (chr == '{' && !inGarbage)
                {
                    groupNestLevel++;
                }

                if (chr == '}' && !inGarbage)
                {
                    sum += groupNestLevel;
                    groupNestLevel--;

                }

                if (inGarbage)
                {
                    removedcharacters++;
                }
            }

            return removedcharacters;
        }

        public int Other3(string input)
        {
            int i = 0, count = 0, totalScr = 0, tmpScr = 0; bool GC = false;
            while (i <= input.Length - 1)
            {
                var c = input[i];
                if (c == '!' && GC) { i += 2; }
                else if (GC && c != '>') { i++; count++; }
                else if (GC && c == '>') { GC = false; i++; }
                else if (c == '<') { GC = true; i++; }
                else if (c == '{') { tmpScr++; i++; }
                else if (c == '}') { totalScr += tmpScr; tmpScr--; i++; }
                else { i++; }
            }
            return count;
        }
    }
}
