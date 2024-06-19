using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RobGame.Core.Characters
{
	public class Player : BaseCharacter, Collision
	{
		public static int[] Collidables = Array.Empty<int>();

		public int[,] CurrentLevel;


		public Player() : base(Vector2Int.Zero, Vector2.Zero)
		{
			CurrentLevel = new int[,] { };
		}

		public Player(Vector2Int position, Vector2 rotation, int[,] currentLevel) : base(position, rotation)
		{
			// ! WILL PASS REF AND NOT DATA. 
			CurrentLevel = currentLevel;
		}


		public void Move(Vector2Int direction, int[,] level)
		{
			if (!CheckCollision(direction.X, direction.Y, level, Collidables))
			{
				Position = new Vector2Int(direction.X, direction.Y);
			}
		}

		public bool CheckCollision(int x, int y, int[,] level, int[] collidables)
		{
			foreach (var item in collidables)
			{
				if (level[y, x] == item)
				{
					return true;
				}
			}

			return false;
		}

		void Collision.OnCollision()
		{
			throw new NotImplementedException();
		}
	}
}
