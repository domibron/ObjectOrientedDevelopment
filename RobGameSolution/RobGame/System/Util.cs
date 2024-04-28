using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class Util
    {
        public static void WriteColour(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void WriteLineColour(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

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
