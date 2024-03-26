using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RobGame.Core
{
    public abstract class Collectable : GameObject
    {
        public virtual int ID { get; }

        public virtual void Collect() { }

        Collectable(int id, Vector2 position, Vector2 rotation) : base(position, rotation)
        {
            ID = id;
        }

        Collectable(int id) : base()
        {
            ID = id;
        }
    }
}
