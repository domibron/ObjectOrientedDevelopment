using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class ScreenDraw
    {
        public static string HalfPxiel = "█";
        public static string Pixel = "██";
        public static string ErrorPixel = "[]";

        public static void Draw(int[,] array, Dictionary<int, ConsoleColor> colourKeys)
        {
            for (int y = 0; y < array.GetLength(0); y++)
            {
                for (int x = 0; x < array.GetLength(1); x++)
                {
                    DrawAt(x*2, y, Pixel, colourKeys[array[y, x]]);
                }

                Console.Write("\n");
            }
        }

        [Obsolete("This will use the old spacing")]
        public static void Draw(int[,] array)
        {
            for(int y = 0; y < array.GetLength(0); y++)
            {
                for(int x = 0; x < array.GetLength(1); x++)
                {
                    Util.DrawPixel(array[y, x]);
                }

                Console.Write("\n");
            }
        }

        public static void Draw(List<List<int>> list)
        {
            for (int y = 0; y < list.Count; y++)
            {
                for (int x = 0; x < list[y].Count; x++)
                {
                    Util.DrawPixel(list[y][x]);
                }

                Console.Write("\n");
            }
        }

        public static void DrawAt(int x, int y, string text, ConsoleColor colour)
        {
            (int left, int top) = Console.GetCursorPosition();

            Console.SetCursorPosition(x, y);

            Util.WriteColour(text, colour);

            Console.SetCursorPosition(left, top);
        }

        public static void DrawAt(int x, int y, string text)
        {
            (int left, int top) = Console.GetCursorPosition();

            Console.SetCursorPosition(x, y);

            Console.Write(text);

            Console.SetCursorPosition(left, top);
        }
    }
}