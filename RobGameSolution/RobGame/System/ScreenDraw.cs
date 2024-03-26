using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public class ScreenDraw
    {
        public static string HalfPxiel = "█";
        public static string Pixel = "██";
        public static string ErrorPixel = "[]";

        public static bool DrawScreen(int[,] array)
        {
            for(int y = 0; y < array.GetLength(0); y++)
            {
                for(int x = 0; x < array.GetLength(1); x++)
                {
                    Util.DrawPixel(array[y, x]);
                }

                Console.Write("\n");
            }

            return true;
        }

        public static bool DrawScreen(List<List<int>> list)
        {
            for (int y = 0; y < list.Count; y++)
            {
                for (int x = 0; x < list[y].Count; x++)
                {
                    Util.DrawPixel(list[y][x]);
                }

                Console.Write("\n");
            }

            return true;
        }


    }
}