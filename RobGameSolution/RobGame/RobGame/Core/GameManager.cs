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
	/// <summary>
	/// The core of the game, the game manager manages and runs the game with the current level.
	/// </summary>
	public class GameManager
	{
		/// <summary>
		/// The current level.
		/// </summary>
		private int[,] _currentGame = new int[,] { };

		/// <summary>
		/// The player.
		/// </summary>
		private Player _player = new Player();

		/// <summary>
		/// Guard wait time before they are allowed to move.
		/// </summary>
		private float GuardWaitTime = .7f;

		/// <summary>
		/// Contains all the guards on the level.
		/// </summary>
        private Dictionary<int, Guard> AllGuards = new Dictionary<int, Guard>();

		/// <summary>
		/// Contains all the collectable coins on the level.
		/// </summary>
		private Dictionary<int, Coin> AllCoins = new Dictionary<int, Coin>();

		/// <summary>
		/// The remaining coins left for the player to collect.
		/// </summary>
		private int CoinsRemaing = 0;

		/// <summary>
		/// A bool for the game loop so we can control when we exit.
		/// </summary>
		private bool _inGame = false;

		/// <summary>
		/// current time for delta time.
		/// </summary>
        private DateTime _time1 = DateTime.Now;

		/// <summary>
		/// previous time for delta time.
		/// </summary>
        private DateTime _time2 = DateTime.Now;

		/// <summary>
		/// delta time for used for math and time.
		/// </summary>
		private float _deltaTime = 0f;

		/// <summary>
		/// Arry of all the items the player can collide with.
		/// </summary>
		private int[] _collidableObjects = [1];

		/// <summary>
		/// Loads and plays the level passed into this function.
		/// </summary>
		/// <param name="levelData">The level data</param>
		public void LoadLevel(int[][,] levelData)
		{
			// we set the in game variable to true so we can stay in the loop.
			_inGame = true;
			
			// we pass in a referance to the array (this array sould be copied not passed to prevent editing the original).
			_currentGame = levelData[0];

			// we clear the console from the text and any previous games.
			Console.Clear();

			// we draw the current level (once).
			ScreenDraw.Draw(_currentGame, Data.ColourKeys);
			
			// call init function.
			InitGame(levelData);

			// This starts the game loop.
			GameLoop();
			
		}

		/// <summary>
		/// Used to add a coin into the coin collection.
		/// </summary>
		/// <param name="coin">The coin to be added</param>
		public void AddCoin(Coin coin)
		{
			CoinsRemaing++;
			AllCoins.Add(CoinsRemaing, coin);
		}

		/// <summary>
		/// Used to add a guard into the guard collection.
		/// </summary>
		/// <param name="guard">The guard to be added</param>
		public void AddGuard(Guard guard)
		{
			AllGuards.Add(AllGuards.Count, guard);
		}

		/// <summary>
		/// Used to collect the coin in the game and remove it to prevent multiple pickups.
		/// </summary>
		/// <param name="id">The ID from the coin being collected</param>
		public void CollectCoin(int id)
		{
			AllCoins[id].Collect();
			AllCoins.Remove(id);

			// we also decrease the coins remaining count.
			CoinsRemaing--;

        }

		/// <summary>
		/// Used to display a lose screen for 2 seconds before returning to the main menu.
		/// </summary>
		private void GameLose()
		{
			Console.Clear();

			ScreenDraw.Draw(Data.LoseScreen, new Dictionary<int, ConsoleColor> { { 0, ConsoleColor.Black }, { 1, ConsoleColor.Red } });

			Thread.Sleep(2000);

			_inGame = false;

        }

        /// <summary>
        /// Used to display a win screen for 2 seconds before returning to the main menu.
        /// </summary>
        private void GameWin()
		{
            Console.Clear();

            ScreenDraw.Draw(Data.WinScreen, new Dictionary<int, ConsoleColor> { { 0, ConsoleColor.Black }, { 1, ConsoleColor.DarkYellow } });

            Thread.Sleep(2000);

            _inGame = false;

        }

		/// <summary>
		/// The game loop, this is the core of the game and is what is being played.
		/// </summary>
		private void GameLoop()
		{
			// guard move timer.
			float GuardTickTimer = 0;


			// This should be called per frame.
			// Keep in mind that drawing per frame is not good and we must update each cell.
			while (_inGame)
			{
				// we update the delta time for counting for ticks.
				CalcDeltaTime();

				// we create a key variable for input detection.
				ConsoleKey key = ConsoleKey.None;

                // if the player enters a key then we record it, otherwise we continue.
                // If we don't do this check, then the application will be paused until a key is pressed because of Input.GetControlInput().
                if (Console.KeyAvailable)
				{
                    key = Input.GetControlInput();
				}

				// we create a new variable for the move direction.
				Vector2Int direction = Vector2Int.Zero;

				// we create a boolean to check if the player has moved.
				bool moving = false;

				// switch statement that will compare the key that was presed and will get the respeced direction.
				// or if the key is escape, then the application will return to the main menu.
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

				// if the player entered a movement key we can move the player.
				if (moving)
				{
					// we check if we collide with a collidable object.
					if (CheckCollision(_player.Position, direction, _collidableObjects))
					{
						// if so, we dont move...
					}
					// we then check if we collide with a coin. if so, we move over the coin and get the coin's id and collect it.
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
					// otherwise, we just move the player.
					else
					{
                        ScreenDraw.DrawAt(_player.Position.X*2, _player.Position.Y, ScreenDraw.Pixel, ConsoleColor.Black);

                        _player.Position += direction;
                        // we draw the new player position and remove the old player.

                        ScreenDraw.DrawAt(_player.Position.X*2, _player.Position.Y, ScreenDraw.Pixel, ConsoleColor.Blue);

                    }
                }

				// a guards moved bool to checked if the guards moved.
				bool guardsMoved = false;

				// move all the guards in the collection after the timer reaches zero.
				if (GuardTickTimer <= 0)
				{
					MoveGuards();

					// we reset the timer.
					GuardTickTimer = GuardWaitTime;
					
					// we set the bool to true as the guards did move.
					guardsMoved = true;

                }
				else
				{
					// we decrease the timer with delta time (time between frames).
					GuardTickTimer -= _deltaTime;
				}

				// we cycle through all the guards and check if the player and any of the guards have the same positions.
				// if so, we game end.
				foreach (Guard guard in AllGuards.Values)
				{
					if (guard.Position == _player.Position)
					{

						GameLose();
					}

				}

				// if either the player moved or guards, we redraw the coins.
				if (guardsMoved || moving)
				{
					// we cycle through the coins.
					foreach (Coin coin in AllCoins.Values)
					{
						// use a bool to keep track if a guard is occupying a coin space.
						bool isGuardInCoin = false;

						// we cycle through all the guards and if the guards occupy the same place as the coin,
						// the guard in coin bool is set to true.
						foreach (Guard guard in AllGuards.Values)
						{
							if (guard.Position == coin.Position)
							{
								isGuardInCoin = true;

                            }
						}

						// we check if the guard in coin bool is true, we draw the guard and not the coin.
						if (isGuardInCoin)
						{
							ScreenDraw.DrawAt(coin.Position.X * 2, coin.Position.Y, ScreenDraw.Pixel, ConsoleColor.Red);
						}
						// else, we draw the coin.
						else
						{
                            ScreenDraw.DrawAt(coin.Position.X * 2, coin.Position.Y, ScreenDraw.Pixel, ConsoleColor.Yellow);
                        }


					}
				}

				// displays the remaining coins at the bottom of the grid.
				Console.SetCursorPosition(0, _currentGame.GetLength(0));
				Console.Write("Remaining Coins: " + CoinsRemaing.ToString());

				// if the player collects all the coins, then they win.
				if (CoinsRemaing <= 0) GameWin();

			}
		}

		/// <summary>
		/// Used to call all the guard move functions.
		/// </summary>
		private void MoveGuards()
		{
			foreach (Guard guard in AllGuards.Values)
			{
                // do goblidy gap
				guard.MoveTick();

            }
		}

		/// <summary>
		/// Used to get the coin id with the position on the game grid.
		/// </summary>
		/// <param name="posOnGrid">The position on the grid</param>
		/// <returns>(int?) Coin ID</returns>
		private int? GetCoinID(Vector2Int posOnGrid)
		{
			// we cycle through all the coins in the collection and check if they have the same position as the given position.
			// if so we return the ID of the coin.
			foreach (Coin coin in AllCoins.Values)
			{
				if (coin.Position == posOnGrid)
				{
					return coin.ID;
				}
			}

			return null;
		}

		/// <summary>
		/// Used to check if there would be a collision.
		/// </summary>
		/// <param name="pos">The current pos.</param>
		/// <param name="direction">The direct / how much to move.</param>
		/// <param name="collidables">The array of all collidable items to check with.</param>
		/// <returns></returns>
		/// <exception cref="NullReferenceException"></exception>
		private bool CheckCollision(Vector2Int pos, Vector2Int direction, int[] collidables)
		{
			// if we are not in a game, we dont have any data, so it will be null. Return a null error.
			if (!_inGame) throw new NullReferenceException("Cannot access level data when not in a game!");

			// Get the squre the player will land on.
			Vector2Int checkSqure = pos + direction;

			// checks if we have the collision int and returns the result.
			return collidables.Contains<int>(_currentGame[checkSqure.Y, checkSqure.X]);
		}

		/// <summary>
		/// Used to keep track of time between frames and updates the delta time variable.
		/// </summary>
		private void CalcDeltaTime()
		{
            _time2 = DateTime.Now;
            _deltaTime = (_time2.Ticks - _time1.Ticks) / 10000000f;
            _time1 = _time2;
        }

		/// <summary>
		/// Initilises the game and data.
		/// </summary>
		/// <param name="GameData">The level data.</param>
		private void InitGame(int[][,] GameData)
		{
			// clears all the collections.
            AllGuards.Clear();
			AllCoins.Clear();

			// reset the coins remaining.
            CoinsRemaing = 0;

			// reset the delta time times.
            _time1 = DateTime.Now;
			_time2 = DateTime.Now;

			// we go through the first array (the level data array) and scrape for coins and the player start point.
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
									// we create the new player at that location and draw the player.
									_player = new Player(new Vector2Int(x, y), Vector2.Zero, GameData[0]);
                                    ScreenDraw.DrawAt(x * 2, y, ScreenDraw.Pixel, ConsoleColor.Blue);
                                    break;
								case 3:
									// we create a new coin at the current location and add the coin to the collection. we then draw the coin.
									AddCoin(new Coin(CoinsRemaing + 1, new Vector2Int(x,y), Vector2.Zero));
                                    ScreenDraw.DrawAt(x * 2, y, ScreenDraw.Pixel, ConsoleColor.Yellow);
                                    break;
								case 4:
									// guard init - they are seperate.
									break;
							}
						}
					}
				}
				else // if the array is not the level data, the its a guard.
				{
					// create a new collection of coordinates for the current guard.
					Dictionary<int, Vector2Int> cords = new Dictionary<int, Vector2Int>();

					// create a new guard.
					Guard guard = new Guard(Vector2Int.Zero, Vector2.Zero, GameData[0]);

					// cycle through the grid.
                    for (int y = 0; y < GameData[i].GetLength(0); y++)
                    {
                        for (int x = 0; x < GameData[i].GetLength(1); x++)
                        {
							// if the squre is one, then set the guards position there and create a cord as well.
                            if (GameData[i][y,x] == 1)
							{
                                guard.Position = new Vector2Int(x, y);
                                _currentGame[y, x] = 4;
								ScreenDraw.DrawAt(x * 2, y, ScreenDraw.Pixel, ConsoleColor.Red);

								// we do cord num - 1 so we can save on organising the data.
                                cords.Add(GameData[i][y, x] - 1, new Vector2Int(x, y));
                            }
							// else, we create a cord at that position.
							else if (GameData[i][y, x] > 1)
							{
								// we do cord num - 1 so we can save on organising the data.
                                cords.Add(GameData[i][y, x] - 1, new Vector2Int(x, y));
                            }
                        }
                    }

					// we itterate through the cords in the collection we made, and pass it to the guard.
					for (int w = 0; w < cords.Count; w++)
					{
						guard.AddCord(cords[w]);
					}
                    
					// we then add the guard to the collection.
					AddGuard(guard);

                }
			}
		}
	}
}
