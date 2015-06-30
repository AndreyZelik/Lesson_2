using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_2
{
    class Program
    {

        public struct ItemRange
        {
            public bool TryParseRange(string range, out int start, out int end)
            {
                string border_before = "({[";
                string border_after = ")}]";
                bool allcorrect = false;
                if (border_before.Contains(range[0]) && border_after.Contains(range[range.Length - 1]))
                {
                    string[] items = range.Substring(1, range.Length-1).Split(',');
                    if (items.Length == 2)
                    {
                        allcorrect = int.TryParse(items[0], out start) & int.TryParse(items[1], out end);
                    }
                }
                start = 0;
                end = 0;
                return allcorrect;
            }


            public bool IsDigitInRange(int digit, params string[] ranges)
            {
                foreach (var range in ranges)
                {
                    int start = 0;
                    int end = 0;

                    if (TryParseRange(range, out start, out end))
                    {
                        if (digit > start & digit < end)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }

        }


        static void Main(string[] args)
        {
        }
    }
}
