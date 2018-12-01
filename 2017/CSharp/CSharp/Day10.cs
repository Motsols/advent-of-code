
using System;

namespace CSharp
{
    public class Day10
    {
        public int Solve(int[] sequence, int[] lengths, bool day2 = false)
        {
            int pos = 0, skipSize = 0;
            foreach (int length in lengths)
            {
                var subSequence = new int[length];
                if (length > 1)
                {
                    int endPos = (pos + length -1) % sequence.Length;
                    int subPos = pos;
                    for (int i = 0; i < length; i++)
                    {
                        subSequence[i] = sequence[subPos];
                        subPos = ++subPos % sequence.Length;
                    }
                    foreach (var subNum in subSequence)
                    {
                        if (endPos < 0)
                            endPos = sequence.Length - 1;
                        sequence[endPos] = subNum;
                        endPos--;
                    }
                }
                pos = (pos + length + skipSize) % sequence.Length;
                skipSize++;
            }
            return sequence[0] * sequence[1];
        }
    }
}
