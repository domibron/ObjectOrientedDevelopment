using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RobGame.Core.Collectables
{
    public abstract class Collectable : GameObject
    {
        public virtual int ID { get; }

        public virtual void Collect() { }

        public Collectable(int id, Vector2Int position, Vector2 rotation) : base(position, rotation)
        {
            ID = id;
        }

        public Collectable(int id) : base()
        {
            ID = id;
        }
    }
}
