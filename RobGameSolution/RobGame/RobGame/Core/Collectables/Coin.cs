using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RobGame.Core.Collectables
{
    public class Coin : Collectable
    {
        public new int ID;

        public Coin(int id, Vector2Int position, Vector2 rotation) : base(id, position, rotation)
        { 
            ID = id;
        }

        public Coin(int id) : base(id)
        {
            ID = id;
        }

        public override void Collect()
        {

        }
    }
}
