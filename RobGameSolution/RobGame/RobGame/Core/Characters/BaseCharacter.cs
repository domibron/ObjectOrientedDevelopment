using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RobGame.Core.Characters
{
    public abstract class BaseCharacter : GameObject
    {
        public virtual void SetPos(Vector2Int newPosition)
        {
            Position = newPosition;
        }

        public virtual void SetRot(Vector2 newRotation)
        {
            Direction = newRotation;
        }

        public virtual void Destroy()
        {

        }

        // keep an eye
        public BaseCharacter(Vector2Int position, Vector2 rotation) : base(position, rotation)
        {

        }

        public BaseCharacter()
        {
            Position = Vector2Int.Zero;
            Direction = Vector2.Zero;
        }

    }
}
