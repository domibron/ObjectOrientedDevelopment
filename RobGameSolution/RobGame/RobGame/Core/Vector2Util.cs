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

        /// <summary>
        /// 0, 0
        /// </summary>
        public static Vector2Int Zero = new Vector2Int(0, 0);
        /// <summary>
        /// 0, -1
        /// </summary>
        public static Vector2Int Up = new Vector2Int(0, -1);
        /// <summary>
        /// 0, 1
        /// </summary>
        public static Vector2Int Down = new Vector2Int(0, 1);
        /// <summary>
        /// -1, 0
        /// </summary>
        public static Vector2Int Left = new Vector2Int(-1, 0);
        /// <summary>
        /// 1, 0
        /// </summary>
        public static Vector2Int Right = new Vector2Int(1, 0);
        /// <summary>
        /// 1,1
        /// </summary>
        public static Vector2Int One = new Vector2Int(1, 1);

        public static Vector2Int operator +(Vector2Int lhs, Vector2Int rhs)
        {
            return new Vector2Int(lhs.X + rhs.X, lhs.Y + rhs.Y);
        }

        public static Vector2Int operator -(Vector2Int lhs, Vector2Int rhs)
        {
            return new Vector2Int(lhs.X - rhs.X, lhs.Y - rhs.Y);
        }

        public bool Equals(Vector2Int vec)
        {
            return (vec.X == this.X && vec.Y == this.Y);
        }

        public static bool operator ==(Vector2Int lhs, Vector2Int rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Vector2Int lhs, Vector2Int rhs)
        {
            return !(lhs == rhs);
        }

        public override string ToString()
        {
            return X.ToString() + " " + Y.ToString();
        }
    }
    
}
