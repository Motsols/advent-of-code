
using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;

namespace CSharp
{
    public class Day3
    {
        Dictionary<string, int> dictionary = new Dictionary<string, int>();

        public int Part1(int input)
        {
            var number = 1;
            int x = 0;
            int y = 0;
            var maxX = 1;
            var maxY = 0;
            Move move = Move.Right;

            while (number < input)
            {
                if (move == Move.Right)
                {
                    x++;
                    if (x == maxX)
                    {
                        maxY++;
                        move = Move.Up;
                    }
                }
                else if (move == Move.Up)
                {
                    y++;
                    if (y == maxY)
                        move = Move.Left;
                }
                else if (move == Move.Left)
                {
                    x--;
                    if (x == -maxX)
                        move = Move.Down;
                }
                else if (move == Move.Down)
                {
                    y--;
                    if (y == -maxY)
                    {
                        maxX++;
                        move = Move.Right;
                    }
                }

                number++;
            }

            var result = Math.Abs(x) + Math.Abs(y);
            return result;
        }

        
        public int Part2(int input)
        {
            var number = 1;
            var latestTotal = 0;
            var maxX = 1;
            var maxY = 0;
            int x = 0;
            int y = 0;
            Move move = Move.Right;
            dictionary = new Dictionary<string, int>();
            dictionary.Add(GetDictionaryName(0,0), 1);

            while (latestTotal < input)
            {
                if (move == Move.Right)
                {
                    x++;
                    latestTotal = GetDictionaryValue(x, y);
                    dictionary.Add(GetDictionaryName(x, y), latestTotal);
                    if (x == maxX)
                    {
                        maxY++;
                        move = Move.Up;
                    }
                }
                else if (move == Move.Up)
                {
                    y++;
                    latestTotal = GetDictionaryValue(x, y);
                    dictionary.Add(GetDictionaryName(x, y), latestTotal);
                    if (y == maxY)
                        move = Move.Left;
                }
                else if (move == Move.Left)
                {
                    x--;
                    latestTotal = GetDictionaryValue(x, y);
                    dictionary.Add(GetDictionaryName(x, y), latestTotal);
                    if (x == -maxX)
                        move = Move.Down;
                }
                else if (move == Move.Down)
                {
                    y--;
                    latestTotal = GetDictionaryValue(x, y);
                    dictionary.Add(GetDictionaryName(x, y), latestTotal);
                    if (y == -maxY)
                    {
                        maxX++;
                        move = Move.Right;
                    }
                }

                number++;
            }
            
            return latestTotal;
        }

        private string GetDictionaryName(int x, int y)
        {
            return $"{x};{y}";
        }
        
        private int GetDictionaryValue(int x, int y)
        {
            var value = 0;
            var right = x + 1;
            var up = y + 1;
            var left = x - 1;
            var down = y - 1;

            try { value += dictionary[GetDictionaryName(right, y)];} catch { }
            try { value += dictionary[GetDictionaryName(right, up)]; } catch { }
            try { value += dictionary[GetDictionaryName(x, up)]; } catch { }
            try { value += dictionary[GetDictionaryName(left, up)]; } catch { }
            try { value += dictionary[GetDictionaryName(left, y)]; } catch { }
            try { value += dictionary[GetDictionaryName(left, down)]; } catch { }
            try { value += dictionary[GetDictionaryName(x, down)]; } catch { }
            try { value += dictionary[GetDictionaryName(right, down)]; } catch { }

            return value;
        }

        enum Move
        {
            Right, Up, Left, Down
        }
    }
}
