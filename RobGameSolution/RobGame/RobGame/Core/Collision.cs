using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobGame.Core
{
    public interface Collision
    {

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
