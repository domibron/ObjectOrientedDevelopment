using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public class Util
    {
        public static void Write(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void WriteLine(string text, ConsoleColor color)
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
                    Write(ScreenDraw.Pixel, (ConsoleColor)color);
                    return true;
                }
                else
                {
                    Write(ScreenDraw.ErrorPixel, ConsoleColor.Red);
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

                Write(ScreenDraw.Pixel, colour);

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

                Write(ScreenDraw.Pixel, colour);

                return true;
            }
            else
            {
                Write(ScreenDraw.ErrorPixel, ConsoleColor.Red);
                return false;
            }
        }
    }
}
