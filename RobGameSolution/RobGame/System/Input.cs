using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class Input
    {
        public static string? GetInput(int min, int max)
        {
            string? input = Console.ReadLine();

            if (input == null)
            {
                return null;
            }

            if (!Util.ValidateInput(input, min, max))
            {
                return null;
            }

            return input;
        }

        public static ConsoleKey GetControlInput()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            return keyInfo.Key;
        }
    }
}
