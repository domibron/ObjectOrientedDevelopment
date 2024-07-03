using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RobGame.Core.Characters
{
	/// <summary>
	/// The player class stores the player's position and relevent information.
	/// </summary>
	public class Player : BaseCharacter, Collision
	{
		// the list of items we will collide with. (this will stop the player).
		public static int[] Collidables = [1];

		// the current loaded level.
		public int[,] CurrentLevel;

		/// <summary>
		/// Creates a new player with empty and defult values.
		/// </summary>
		public Player() : base(Vector2Int.Zero, Vector2.Zero)
		{
			CurrentLevel = new int[,] { };
		}

		/// <summary>
		/// Creates a new player at the current postion, rotation and current level.
		/// </summary>
		/// <param name="position">The position on the gird the player is</param>
		/// <param name="rotation">The current rotation of the player</param>
		/// <param name="currentLevel"> The level we have loaded</param>
		public Player(Vector2Int position, Vector2 rotation, int[,] currentLevel) : base(position, rotation)
		{
			// ! WILL PASS REF AND NOT DATA. yep. o7
			CurrentLevel = currentLevel;
		}

		/// <summary>
		/// Moves the player using the direction vetor.
		/// </summary>
		/// <param name="direction">The vetor to move the player</param>
		/// <param name="level">The current level for collision checks</param>
		public void Move(Vector2Int direction, int[,] level)
		{
			// if we dont collide with anything, then we can set the new position.
			if (!CheckCollision(direction.X, direction.Y, level, Collidables))
			{
				Position = new Vector2Int(direction.X, direction.Y);
			}
		}

        /// <summary>
        /// Checks the collistion on a squre on a grid and compares the value with the collidable array. Returns True, if it detects a collision.
        /// </summary>
        /// <param name="x">The x on the level grid</param>
        /// <param name="y">The y on the level grid</param>
        /// <param name="level">The current loaded level</param>
        /// <param name="collidables">The array to items to check against</param>
        /// <returns></returns>
        public bool CheckCollision(int x, int y, int[,] level, int[] collidables)
		{
			// cycle through the array and compares it to the squre on the loaded level.
			foreach (var item in collidables)
			{
				if (level[y, x] == item)
				{
					return true;
				}
			}

			return false;
		}

		/// <summary>
		/// A funtion that would be called with a collision with another object. Dont use.
		/// </summary>
		/// <exception cref="NotImplementedException">Not implemented</exception>
		[Obsolete]
		void Collision.OnCollision()
		{
			throw new NotImplementedException();
		}
	}
}
