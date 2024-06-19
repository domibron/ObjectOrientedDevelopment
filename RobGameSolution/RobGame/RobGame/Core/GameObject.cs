using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RobGame.Core
{
    public class GameObject
    {
        public Vector2Int Position;
        public Vector2 Direction;

        public GameObject()
        {
            Position = Vector2Int.Zero;
            Direction = Vector2.Zero;
        }

        public GameObject(Vector2Int position)
        {
            Position = position;
            Direction = Vector2.Zero;
        }

        public GameObject(Vector2Int position, Vector2 direction)
        {
            Position = position;
            Direction = direction;
        }
    }
}
