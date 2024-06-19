using RobGame.Core.Characters;
using RobGame.Core.Collectables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

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

        private DateTime time1 = DateTime.Now;
        private DateTime time2 = DateTime.Now;

		float deltaTime = 0f;

        public void LoadLevel(int[,] level)
		{
			_currentGame = level;

			_inGame = true;

			ScreenDraw.Draw(_currentGame);

				GameLoop();
			
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

			// This should be called per frame.
			// Keep in mind that drawing per frame is not good and we must update each cell.
			while (_inGame)
			{
				// we update the delta time for counting for ticks.
				CalcDeltaTime();


                ConsoleKey key = Input.GetControlInput();

				Vector2Int direction = Vector2Int.Zero;

				bool moving = false;

				switch (key)
				{
					case ConsoleKey.W:
                        direction = Vector2Int.Up;
                        moving = true;
						break;
					case ConsoleKey.A:
						direction = Vector2Int.Left;
						moving = true;
						break;
					case ConsoleKey.S:
						direction = Vector2Int.Down;
						moving = true;
						break;
					case ConsoleKey.D:
						direction = Vector2Int.Right;
						moving = true;
						break;
                }

				if (moving)
				{
					if (CheckCollision(_player.Position, direction, new int[] { 0, 1 }))
					{
						// dont move...
					}
				}

			}
		}

		private bool CheckCollision(Vector2Int pos, Vector2Int direction, int[] collidables)
		{
			if (!_inGame) throw new NullReferenceException("Cannot access level data when not in a game!");

			Vector2Int checkSqure = pos + direction;

			// checks if we have the collision int and returns the result.
			return collidables.Contains<int>(_currentGame[checkSqure.X, checkSqure.Y]);
		}

		private void CalcDeltaTime()
		{
            time2 = DateTime.Now;
            deltaTime = (time2.Ticks - time1.Ticks) / 10000000f;
            Console.WriteLine(deltaTime);  // *float* output {0,2493331}
            Console.WriteLine(time2.Ticks - time1.Ticks); // *int* output {2493331}
            time1 = time2;
        }
	}
}
