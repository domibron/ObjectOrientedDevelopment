using RobGame.Core.Characters;
using RobGame.Core.Collectables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobGame.Core
{
    public class GameManager
    {
        private int[,] CurrentGame;

        private Dictionary<int, Guard> AllGuards = new Dictionary<int, Guard>();
        private Dictionary<int, Coin> AllCoins = new Dictionary<int, Coin>();

        private int CoinsRemaing = 0;

        public GameManager(int[,] level)
        {
            CurrentGame = level;
        }
    }
}
