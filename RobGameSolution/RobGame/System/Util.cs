using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    /// <summary>
    /// The Util class holds the functions that are usful.
    /// </summary>
    public static class Util
    {
        /// <summary>
        /// Writes to the console with a given colour.
        /// </summary>
        /// <param name="text">Text to display.</param>
        /// <param name="color">The colour of the text.</param>
        public static void WriteColour(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Writes to the console with a new line and a given colour.
        /// </summary>
        /// <param name="text">Text to display.</param>
        /// <param name="color">The colour of the text.</param>
        public static void WriteLineColour(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Draws the pixel and colours it with the given int.
        /// </summary>
        /// <param name="colorInt">The int colour of the console color enum</param>
        /// <returns>bool</returns>
        public static bool DrawPixel(int colorInt)
        {
            if (colorInt >= 0)
            {
                object color;
                if (Enum.TryParse(typeof(ConsoleColor), Enum.GetName(typeof(ConsoleColor), colorInt), out color))
                {
                    WriteColour(ScreenDraw.Pixel, (ConsoleColor)color);
                    return true;
                }
                else
                {
                    WriteColour(ScreenDraw.ErrorPixel, ConsoleColor.Red);
                    return false;
                }
            }
            else if (colorInt == -1)
            {
                /// Can turn into its' own function.

                // save the coursor's position for later.
                (int cursorX, int cursorY) = Console.GetCursorPosition();

                // move the corsor right one space.
                Console.SetCursorPosition(cursorX + 1, cursorY);

                // set the colour of the cursour to the background colour.
                ConsoleColor colour = Console.BackgroundColor;

                // move the corsor back to it's original position.
                Console.SetCursorPosition(cursorX, cursorY);

                WriteColour(ScreenDraw.Pixel, colour);

                return true;
            }
            else if (colorInt == -2)
            {
                // save the coursor's position for later.
                (int cursorX, int cursorY) = Console.GetCursorPosition();

                // move the corsor right one space.
                Console.SetCursorPosition(cursorX + 1, cursorY);

                // set the colour of the cursour to the foreground colour.
                ConsoleColor colour = Console.ForegroundColor;

                // move the corsor back to it's original position.
                Console.SetCursorPosition(cursorX, cursorY);

                WriteColour(ScreenDraw.Pixel, colour);

                return true;
            }
            else
            {
                WriteColour(ScreenDraw.ErrorPixel, ConsoleColor.Red);
                return false;
            }
        }

        /// <summary>
        /// Validates the input given with the number range.
        /// </summary>
        /// <param name="input">Input from the player.</param>
        /// <param name="minRange">Min number.</param>
        /// <param name="maxRange">Man number.</param>
        /// <returns>bool</returns>
        public static bool ValidateInput(string input, int minRange, int maxRange)
        {
            int value;

            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            if (!Int32.TryParse(input, out value))
            {
                return false;
            }

            if (value < minRange || value > maxRange) 
            { 
                return false; 
            }

            return true;
        }

        /// <summary>
        /// Converts the input into a int.
        /// </summary>
        /// <param name="input">The input from the playe.</param>
        /// <returns>int</returns>
        public static int ConvertInput(string input)
        {
            int OutPut;

            bool Result = int.TryParse(input, out OutPut);

            if (Result)
            {
                return OutPut;
            }
            else
            {
                return -1;
            }
        }
    }
}
