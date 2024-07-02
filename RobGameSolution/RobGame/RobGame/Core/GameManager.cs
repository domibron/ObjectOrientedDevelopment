using RobGame.Core.Characters;
using RobGame.Core.Collectables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using RobGame.Core.Special;

namespace RobGame.Core
{
	public class GameManager
	{
		private int[,] _currentGame = new int[,] { };

		private Player _player = new Player();

		private float GuardWaitTime = .7f;

        private Dictionary<int, Guard> AllGuards = new Dictionary<int, Guard>();
		private Dictionary<int, Coin> AllCoins = new Dictionary<int, Coin>();

		private int CoinsRemaing = 0;

		private bool _inGame = false;

        private DateTime _time1 = DateTime.Now;
        private DateTime _time2 = DateTime.Now;

		// used for spacing things like guard ticks.
		private float _deltaTime = 0f;

		// anything the player cannot collide with.
		private int[] _collidableObjects = [1];


		public void LoadLevel(int[][,] levelData)
		{
			_inGame = true;
			
			// we need to copy the data, not referance it.
			_currentGame = levelData[0];

			Console.Clear();

			ScreenDraw.Draw(_currentGame, Data.ColourKeys);
			
			// call init function.
			InitGame(levelData);



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

			CoinsRemaing--;

        }

		private void GameLose()
		{
			Console.Clear();

			ScreenDraw.Draw(Data.LoseScreen, new Dictionary<int, ConsoleColor> { { 0, ConsoleColor.Black }, { 1, ConsoleColor.Red } });

			Thread.Sleep(2000);

			_inGame = false;

        }

		private void GameWin()
		{
            Console.Clear();

            ScreenDraw.Draw(Data.WinScreen, new Dictionary<int, ConsoleColor> { { 0, ConsoleColor.Black }, { 1, ConsoleColor.DarkYellow } });

            Thread.Sleep(2000);

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
				ConsoleKey key = ConsoleKey.None;

                if (Console.KeyAvailable)
				{
                    key = Input.GetControlInput();
				}

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
					case ConsoleKey.Escape: // want a way to exit out.
						GameLose();
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
						ScreenDraw.DrawAt(_player.Position.X * 2, _player.Position.Y, ScreenDraw.Pixel, ConsoleColor.Black);

						_player.Position += direction;
						// we draw the new player position and remove the old player.

						ScreenDraw.DrawAt(_player.Position.X * 2, _player.Position.Y, ScreenDraw.Pixel, ConsoleColor.Blue);

						// we collect the coin.
						int? coinID = GetCoinID(_player.Position);

						if (coinID.HasValue) CollectCoin(coinID.Value);
					}
					else
					{
                        ScreenDraw.DrawAt(_player.Position.X*2, _player.Position.Y, ScreenDraw.Pixel, ConsoleColor.Black);

                        _player.Position += direction;
                        // we draw the new player position and remove the old player.

                        ScreenDraw.DrawAt(_player.Position.X*2, _player.Position.Y, ScreenDraw.Pixel, ConsoleColor.Blue);

                    }
                }

				bool guardsMoved = false;

				// move all the guards
				// do time check.
				if (GuardTickTimer <= 0)
				{
					MoveGuards();

					GuardTickTimer = GuardWaitTime;

					guardsMoved = true;

                }
				else
				{
					GuardTickTimer -= _deltaTime;
				}

				// we dont do coin collision here.

				// we need guard on player collision detection. We moved all the guards.

				foreach (Guard guard in AllGuards.Values)
				{
					if (guard.Position == _player.Position)
					{

						GameLose();
					}

				}

				if (guardsMoved || moving)
				{

					foreach (Coin coin in AllCoins.Values)
					{

						bool isGuardInCoin = false;

						foreach (Guard guard in AllGuards.Values)
						{
							if (guard.Position == coin.Position)
							{
								isGuardInCoin = true;

                            }
						}

						if (isGuardInCoin)
						{
							ScreenDraw.DrawAt(coin.Position.X * 2, coin.Position.Y, ScreenDraw.Pixel, ConsoleColor.Red);
						}
						else
						{
                            ScreenDraw.DrawAt(coin.Position.X * 2, coin.Position.Y, ScreenDraw.Pixel, ConsoleColor.Yellow);
                        }


					}
				}

				Console.SetCursorPosition(0, _currentGame.GetLength(0));
				Console.Write("Remaining Coins: " + CoinsRemaing.ToString());

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
			return collidables.Contains<int>(_currentGame[checkSqure.Y, checkSqure.X]);
		}

		private void CalcDeltaTime()
		{
            _time2 = DateTime.Now;
            _deltaTime = (_time2.Ticks - _time1.Ticks) / 10000000f;
            _time1 = _time2;
        }

		private void InitGame(int[][,] GameData)
		{
			// clear just in case. does it get removed from memory?
            AllGuards.Clear();
			AllCoins.Clear();

            CoinsRemaing = 0;

            _time1 = DateTime.Now;
			_time2 = DateTime.Now;

            for (int i = 0; i < GameData.Length; i++)
			{
				if (i == 0)
				{ 
					// put in fucntion

					for (int y = 0; y < GameData[0].GetLength(0); y++)
					{
						for (int x = 0; x < GameData[0].GetLength(1); x++)
						{
							switch (GameData[0][y,x])
							{
								case 0:
									break;
								case 1:
									break;
								case 2:
									_player = new Player(new Vector2Int(x, y), Vector2.Zero, GameData[0]);
                                    ScreenDraw.DrawAt(x * 2, y, ScreenDraw.Pixel, ConsoleColor.Blue);
                                    break;
								case 3:
									AddCoin(new Coin(CoinsRemaing + 1, new Vector2Int(x,y), Vector2.Zero));
                                    ScreenDraw.DrawAt(x * 2, y, ScreenDraw.Pixel, ConsoleColor.Yellow);
                                    break;
								case 4:
									// guard init - no, its done.
									break;
							}
						}
					}
				}
				else
				{
					Dictionary<int, Vector2Int> cords = new Dictionary<int, Vector2Int>();

					Guard guard = new Guard(Vector2Int.Zero, Vector2.Zero, GameData[0]);

                    for (int y = 0; y < GameData[i].GetLength(0); y++)
                    {
                        for (int x = 0; x < GameData[i].GetLength(1); x++)
                        {
                            if (GameData[i][y,x] == 1)
							{
                                guard.Position = new Vector2Int(x, y);
                                _currentGame[y, x] = 4;
								ScreenDraw.DrawAt(x * 2, y, ScreenDraw.Pixel, ConsoleColor.Red);

								// we do cord num - 1 so we can save on organising the data.
                                cords.Add(GameData[i][y, x] - 1, new Vector2Int(x, y));
                            }
							else if (GameData[i][y, x] > 1)
							{
								// we do cord num - 1 so we can save on organising the data.
                                cords.Add(GameData[i][y, x] - 1, new Vector2Int(x, y));
                            }
                        }
                    }

					for (int w = 0; w < cords.Count; w++)
					{
						guard.AddCord(cords[w]);
					}
                    
					AddGuard(guard);

                }
			}
		}
	}
}
