using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RobGame.Core.Collectables
{
    /// <summary>
    /// The coin class is used for the coin collectable. it inherits from the collectable class.
    /// </summary>
    public class Coin : Collectable
    {
        /// <summary>
        /// Very important unique identifyer, this must be unique to the coin.
        /// </summary>
        public new int ID;

        /// <summary>
        /// Creates a new coin with the unique id at a position with a rotation.
        /// </summary>
        /// <param name="id">Unique ID</param>
        /// <param name="position">The postion on the level grid</param>
        /// <param name="rotation">The current rotation</param>
        public Coin(int id, Vector2Int position, Vector2 rotation) : base(id, position, rotation)
        { 
            ID = id;
        }

        /// <summary>
        /// Creates a new coin with the id, everything else is set to defult.
        /// </summary>
        /// <param name="id"></param>
        public Coin(int id) : base(id)
        {
            ID = id;
        }

        /// <summary>
        /// A function that can be used for a collect event.
        /// </summary>
        public override void Collect()
        {

        }
    }
}
