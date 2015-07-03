using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_2
{
    
    public struct ItemRange
        {
            
            public int startInterval;
            public int endInterval;
            
            public static bool TryParseRange(string range, out ItemRange range)
            {
                string borderBefore = "({[";
                string borderAfter = ")}]";
                bool allcorrect = false;
                start = 0;
                end = 0;
                if (borderBefore.Contains(range[0]) && borderAfter.Contains(range[range.Length - 2]))
                {
                    string[] items = range.Substring(1, range.Length-1).Split(',');
                    if (items.Length == 2)
                    {
                        allcorrect = int.TryParse(items[0], out range.startInterval) & int.TryParse(items[1], out range.endInterval);
                    }
                }
                return allcorrect;
            }


            public bool IsDigitInRange(int digit, bool strong = false, params ItemRange[] ranges)
            {
                bool result = true;
                foreach (var range in ranges)
                {
                    if (strong)
                    {
                        if (digit < range.startInterval && digit > range.endInterval)
                        {
                            result = false;
                        }
                    }
                    else
                    {
                        if (digit <= range.startInterval && digit >= range.endInterval)
                        {
                            result = false;
                        }
                    }
                }
                return result;
            }

        }
    
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
