using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RobGame.Core
{
    public abstract class BaseCharacter : GameObject
    {
        public virtual void SetPos(Vector2 newPosition)
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
        BaseCharacter(Vector2 position, Vector2 rotation) : base(position, rotation)
        {

        }

        BaseCharacter()
        {
            Position = Vector2.Zero;
            Direction = Vector2.Zero;
        }

    }
}
