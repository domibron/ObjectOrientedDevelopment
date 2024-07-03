using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    /// <summary>
    /// The screen draw class is used to draw images to the screen using either 2d arrays or 2d lists.
    /// </summary>
    public static class ScreenDraw
    {
        /// <summary>
        /// Half of a pixel. (█)
        /// </summary>
        public static string HalfPxiel = "█";

        /// <summary>
        /// A whole pixel, this is a square. (██)
        /// </summary>
        public static string Pixel = "██";

        /// <summary>
        /// A whole pixel that represents a error. ([])
        /// </summary>
        public static string ErrorPixel = "[]";

        /// <summary>
        /// Draws a image based on the array and colour codes.
        /// </summary>
        /// <param name="array">The image to draw.</param>
        /// <param name="colourKeys">The colour keys to use.</param>
        public static void Draw(int[,] array, Dictionary<int, ConsoleColor> colourKeys)
        {
            // cycles through the array. and draws a pixel with the colour the number from the array.
            for (int y = 0; y < array.GetLength(0); y++)
            {
                for (int x = 0; x < array.GetLength(1); x++)
                {
                    DrawAt(x*2, y, Pixel, colourKeys[array[y, x]]);
                }

                Console.Write("\n");
            }
        }

        /// <summary>
        /// Draws a iamge with the given array.
        /// </summary>
        /// <param name="array">The image to draw.</param>
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

        /// <summary>
        /// Draws a iamge with the given list.
        /// </summary>
        /// <param name="list">The image to draw.</param>
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

        /// <summary>
        /// Draws a string at the given position on the console with a colour.
        /// </summary>
        /// <param name="x">The distance from the left side of the console.</param>
        /// <param name="y">The distance from the top of the console.</param>
        /// <param name="text">The text to display.</param>
        /// <param name="colour">The colour of the text.</param>
        public static void DrawAt(int x, int y, string text, ConsoleColor colour)
        {
            // stores previous location of the cursor.
            (int left, int top) = Console.GetCursorPosition();

            // set the cursor's position to the given coordinates.
            Console.SetCursorPosition(x, y);

            // draw the text with the given colour.
            Util.WriteColour(text, colour);

            // reset cursor's position.
            Console.SetCursorPosition(left, top);
        }

        /// <summary>
        /// Draws a string at the given position on the console.
        /// </summary>
        /// <param name="x">The distance from the left side of the console.</param>
        /// <param name="y">The distance from the top of the console.</param>
        /// <param name="text">The text to display.</param>
        public static void DrawAt(int x, int y, string text)
        {
            // stores previous location of the cursor.
            (int left, int top) = Console.GetCursorPosition();

            // set the cursor's position to the given coordinates.
            Console.SetCursorPosition(x, y);

            // writes the text.
            Console.Write(text);

            // reset cursor's position.
            Console.SetCursorPosition(left, top);
        }
    }
}