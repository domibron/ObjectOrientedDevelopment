using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RobGame.Core.Collectables
{
    /// <summary>
    /// The base collectable class for all collectables.
    /// </summary>
    public abstract class Collectable : GameObject
    {
        /// <summary>
        /// The unique identifyer.
        /// </summary>
        public virtual int ID { get; }

        /// <summary>
        /// A function for a on collect event.
        /// </summary>
        public virtual void Collect() { }

        /// <summary>
        /// Creates a new collectable with a unique id, set position and rotation.
        /// </summary>
        /// <param name="id">The unique ID</param>
        /// <param name="position">The current postion on the grid</param>
        /// <param name="rotation">The current rotation</param>
        public Collectable(int id, Vector2Int position, Vector2 rotation) : base(position, rotation)
        {
            ID = id;
        }

        /// <summary>
        /// Creates a new collectable with the unique ID.
        /// </summary>
        /// <param name="id">The unique ID</param>
        public Collectable(int id) : base()
        {
            ID = id;
        }
    }
}
