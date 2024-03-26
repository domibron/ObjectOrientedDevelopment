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
        public Vector2 Position;
        public Vector2 Direction;

        public GameObject()
        {
            Position = Vector2.Zero;
            Direction = Vector2.Zero;
        }

        public GameObject(Vector2 position)
        {
            Position = position;
            Direction = Vector2.Zero;
        }

        public GameObject(Vector2 position, Vector2 direction)
        {
            Position = position;
            Direction = direction;
        }
    }
}
