using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RobGame.Core
{
    /// <summary>
    /// The core of the game, the game object class holds the position and rotation of a object.
    /// </summary>
    public class GameObject
    {
        /// <summary>
        /// The current position of the object.
        /// </summary>
        public Vector2Int Position;

        /// <summary>
        /// The current rotation of the object.
        /// </summary>
        public Vector2 Direction;

        /// <summary>
        /// Creates a new game object with defult values.
        /// </summary>
        public GameObject()
        {
            Position = Vector2Int.Zero;
            Direction = Vector2.Zero;
        }

        /// <summary>
        /// Creates a new game object with a specified position.
        /// </summary>
        /// <param name="position">The position the game object is.</param>
        public GameObject(Vector2Int position)
        {
            Position = position;
            Direction = Vector2.Zero;
        }

        /// <summary>
        /// Creates a new game object with a specified position and rotation.
        /// </summary>
        /// <param name="position">The position the game object is.</param>
        /// <param name="direction">The rotation the game object is.</param>
        public GameObject(Vector2Int position, Vector2 direction)
        {
            Position = position;
            Direction = direction;
        }
    }
}
