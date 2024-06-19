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

        public Coin(int id, Vector2Int position, Vector2 rotation) : base(id, position, rotation) { 
        
        }

        public Coin(int id) : base(id)
        {

        }

        public override void Collect()
        {

        }
    }
}
