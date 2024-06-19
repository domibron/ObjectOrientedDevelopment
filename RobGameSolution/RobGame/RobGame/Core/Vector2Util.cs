using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobGame.Core
{
    
    public struct Vector2Int
    {
        public int X;
        public int Y;

        public Vector2Int(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public static Vector2Int Zero = new Vector2Int(0, 0);
        public static Vector2Int Up = new Vector2Int(0, -1);
        public static Vector2Int Down = new Vector2Int(0, 1);
        public static Vector2Int Left = new Vector2Int(1, 0);
        public static Vector2Int Right = new Vector2Int(-1, 0);
        public static Vector2Int One = new Vector2Int(1, 1);

        public static Vector2Int operator +(Vector2Int a, Vector2Int b)
        {
            return new Vector2Int(a.X + b.X, a.Y + b.Y);
        }

        public static Vector2Int operator -(Vector2Int a, Vector2Int b)
        {
            return new Vector2Int(a.X - b.X, a.Y - b.Y);
        }
    }
    
}
