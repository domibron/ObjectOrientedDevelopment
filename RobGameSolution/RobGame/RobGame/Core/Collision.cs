using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobGame.Core
{
    /// <summary>
    /// A interface for advance collision detection.
    /// didn't use this so it serves no purpose.
    /// </summary>
    public interface Collision
    {
        
        /// <summary>
        /// Called when a object collides with this one.
        /// </summary>
        [Obsolete]
        public void OnCollision();

        //public bool CheckCollision(int x, int y, int[,] level, int[] collidables)
        //{
        //    foreach (var item in collidables)
        //    {
        //        if (level[y, x] == item)
        //        {
        //            return true;
        //        }
        //    }

        //    return false;
        //}
    }
}
