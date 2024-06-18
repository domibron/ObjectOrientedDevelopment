using RobGame.Core.Characters;
using RobGame.Core.Collectables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static RobGame.Core.Vector2Util;

namespace RobGame.Core
{
	public class GameManager
	{
		private int[,] _currentGame = new int[,] { };

		private Player _player = new Player();

		private Dictionary<int, Guard> AllGuards = new Dictionary<int, Guard>();
		private Dictionary<int, Coin> AllCoins = new Dictionary<int, Coin>();

		private int CoinsRemaing = 0;

		private bool _inGame = false;

		public void LoadLevel(int[,] level)
		{
			_currentGame = level;

			_inGame = true;

			ScreenDraw.Draw(_currentGame);

			while (_inGame)
			{
				GameLoop();
			}
		}

		public void AddCoin(Coin coin)
		{
			CoinsRemaing++;
			AllCoins.Add(CoinsRemaing, coin);
		}

		public void AddGuard(Guard guard)
		{
			AllGuards.Add(AllGuards.Count, guard);
		}

		public void CollectCoin(int id)
		{
			AllCoins[id].Collect();
			AllCoins.Remove(id);
		}

		private void GameLose()
		{
			// dunno
		}

		private void GameWin()
		{
			// dunno
		}

		private void GameLoop()
		{
			ConsoleKey key = Input.GetControlInput();

			if (key == ConsoleKey.W || key == ConsoleKey.S || key == ConsoleKey.D || key == ConsoleKey.A)
			{
				// we need to check if the player goes into a wall?//////?//?//?

			}


		}
	}
}
