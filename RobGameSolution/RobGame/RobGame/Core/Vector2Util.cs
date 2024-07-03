using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobGame.Core
{
    
    public struct Vector2Int
    {
        /// <summary>
        /// The X axis (-1 is left, 1 is right).
        /// </summary>
        public int X;

        /// <summary>
        /// The Y axis (-1 is up, 1 is down).
        /// </summary>
        public int Y;

        /// <summary>
        /// Creates a new Vector2Int
        /// </summary>
        /// <param name="x">X Axis</param>
        /// <param name="y">Y Axis</param>
        public Vector2Int(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        // defualt values.

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

        /// <summary>
        /// Adds two vectors together and returns a new vector.
        /// </summary>
        /// <param name="lhs">Left hand side value.</param>
        /// <param name="rhs">Right hand side value.</param>
        /// <returns>Vector2Int</returns>
        public static Vector2Int operator +(Vector2Int lhs, Vector2Int rhs)
        {
            return new Vector2Int(lhs.X + rhs.X, lhs.Y + rhs.Y);
        }

        /// <summary>
        /// Subtracts two vectors together and returns a new vector.
        /// </summary>
        /// <param name="lhs">Left hand side value.</param>
        /// <param name="rhs">Right hand side value.</param>
        /// <returns>Vector2Int</returns>
        public static Vector2Int operator -(Vector2Int lhs, Vector2Int rhs)
        {
            return new Vector2Int(lhs.X - rhs.X, lhs.Y - rhs.Y);
        }

        /// <summary>
        /// Compares a Vector2Int to this Vector2Int.
        /// </summary>
        /// <param name="vector">The vector to compare to this vector.</param>
        /// <returns></returns>
        public bool Equals(Vector2Int vector)
        {
            return (vector.X == this.X && vector.Y == this.Y);
        }

        /// <summary>
        /// Checks if lhs vector is equal to rhs vector.
        /// </summary>
        /// <param name="lhs">Left hand side value.</param>
        /// <param name="rhs">Right hand side value.</param>
        /// <returns>bool</returns>
        public static bool operator ==(Vector2Int lhs, Vector2Int rhs)
        {
            return lhs.Equals(rhs);
        }

        /// <summary>
        /// Checks if lhs vector does not equal rhs vector.
        /// </summary>
        /// <param name="lhs">Left hand side value.</param>
        /// <param name="rhs">Right hand side value.</param>
        /// <returns>Vector2Int</returns>
        public static bool operator !=(Vector2Int lhs, Vector2Int rhs)
        {
            return !(lhs == rhs);
        }

        /// <summary>
        /// Converts the vector into a string.
        /// </summary>
        /// <returns>String of a vector as "[x, y]"</returns>
        public override string ToString()
        {
            return "[" + X.ToString() + ", " + Y.ToString() + "]";
        }
    }
    
}
