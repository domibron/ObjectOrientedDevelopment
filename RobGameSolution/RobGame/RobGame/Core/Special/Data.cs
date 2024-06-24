using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobGame.Core.Special
{
    // All the data:
    // 0 - Nothing.
    // 1 - Wall.
    // 2 - Player Start and player.
    // 3 - Coin Spawn.
    // 4 - Guard spawn and guard.
    
    // Guard data:
    // 0 - Nothing.
    // 1 - Guard spawn.
    // 2 and up | 2+ - Guard cord.

    /// <summary>
    /// The data for the game that holds level data and guard positions.
    /// </summary>
    ///
    public static class Data
    {
        // Example of the level data.
        public static readonly int[][,] Example = new int[][,]
        {
            new int[,] { // Level data
                {0,0,0},
                {0,0,0},
                {0,0,0}
            },
            new int[,] { // Guard 1
                {0,0,0},
                {0,0,0},
                {0,0,0}
            }
        };

    }
}
