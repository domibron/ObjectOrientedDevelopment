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

		private float GuardWaitTime = 1f;

        private Dictionary<int, Guard> AllGuards = new Dictionary<int, Guard>();
		private Dictionary<int, Coin> AllCoins = new Dictionary<int, Coin>();

		private int CoinsRemaing = 0;

		private bool _inGame = false;

        private DateTime _time1 = DateTime.Now;
        private DateTime _time2 = DateTime.Now;

		private float _deltaTime = 0f;

		private int[] _collidableObjects = new int[] { 1 };


		public void LoadLevel(int[][,] levelData)
		{
			_currentGame = levelData[0];

			// call init function.

			_inGame = true;

			ScreenDraw.Draw(_currentGame);

			// This starts the game loop.
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

			_inGame = false;

        }

		private void GameWin()
		{
			// dunno

			_inGame = false;

        }

		private void GameLoop()
		{
			float GuardTickTimer = 0;


			// This should be called per frame.
			// Keep in mind that drawing per frame is not good and we must update each cell.
			while (_inGame)
			{
				// we update the delta time for counting for ticks.
				CalcDeltaTime();

				// this will pause the application.
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
					if (CheckCollision(_player.Position, direction, _collidableObjects))
					{
						// dont move...
						// cannot debug out
					}
					else if (CheckCollision(_player.Position, direction, new int[] { 3 }))
					{
						_player.Position += direction;
						// we draw the new player position and remove the old player.

						// we collect the coin.
						int? coinID = GetCoinID(_player.Position);

						if (coinID.HasValue) CollectCoin(coinID.Value);
                    }
                    else
					{
                        _player.Position += direction;
                        // we draw the new player position and remove the old player.
                    }
                }

				// move all the guards
				// do time check.
				if (GuardTickTimer <= 0)
				{
					MoveGuards();

					GuardTickTimer = GuardWaitTime;
                }
				else
				{
                    GuardTickTimer -= _deltaTime;
                }

				// we dont do coin collision here.

				// we need guard on player collision detection. We moved all the guards.
				if (true) GameLose();
				


				if (CoinsRemaing <= 0) GameWin();

				


			}
		}

		private void MoveGuards()
		{
			foreach (Guard guard in AllGuards.Values)
			{
                // do goblidy gap
				guard.MoveTick();

            }
		}

		private int? GetCoinID(Vector2Int posOnGrid)
		{
			foreach (Coin coin in AllCoins.Values)
			{
				if (coin.Position == posOnGrid)
				{
					return coin.ID;
				}
			}

			return null;
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
            _time2 = DateTime.Now;
            _deltaTime = (_time2.Ticks - _time1.Ticks) / 10000000f;
            Console.WriteLine(_deltaTime);  // *float* output {0,2493331}
            Console.WriteLine(_time2.Ticks - _time1.Ticks); // *int* output {2493331}
            _time1 = _time2;
        }
	}
}
