using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    /// <summary>
    /// Input class is used to get the input from the player.
    /// </summary>
    public static class Input
    {
        /// <summary>
        /// Gets a input from the player that is between a number range (0 to inf).
        /// </summary>
        /// <param name="min">Lowes number.</param>
        /// <param name="max">Highest number.</param>
        /// <returns>String?</returns>
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

        /// <summary>
        /// Gets the console key from the player.
        /// </summary>
        /// <returns>ConsoleKey</returns>
        public static ConsoleKey GetControlInput()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            return keyInfo.Key;
        }
    }
}
