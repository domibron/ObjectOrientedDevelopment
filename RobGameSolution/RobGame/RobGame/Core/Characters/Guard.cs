using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RobGame.Core.Characters
{
    public class Guard : BaseCharacter
    {
        public static int[] Collidables = Array.Empty<int>();

        public int[,] CurrentLevel;

        private Dictionary<int, Vector2Int> Cords = new Dictionary<int, Vector2Int>();
        private int CurrentCord = -1;

        public Guard(Vector2Int pos, Vector2 rotation, int[,] currentLevel) : base(pos, rotation) {
            // WILL PASS REF AND NOT DATA. 
            CurrentLevel = currentLevel;
        }

        public void AddCord(Vector2Int cord)
        {
            Cords.Add(Cords.Count,cord);
        }

        public void MoveToNext()
        {
            if (Cords.Count <= 0) return;

            if (CurrentCord + 1 < Cords.Count)
            {
                CurrentCord++;
            }
            else
            {
                CurrentCord = 0;
            }
        }

        public void MoveTick()
        {
            if (Position == Cords[CurrentCord])
            {
                MoveToNext();
            }

            Vector2Int HowMuchToMove = Position - Cords[CurrentCord];

            if (CurrentLevel[Position.Y, Position.X] == 3) ScreenDraw.DrawAt(Position.X, Position.Y, ScreenDraw.Pixel, ConsoleColor.Yellow);
            else ScreenDraw.DrawAt(Position.X, Position.Y, ScreenDraw.Pixel, ConsoleColor.Black);

            if (HowMuchToMove.X > 0)
            {
                Position.X++;
            }
            else if (HowMuchToMove.X < 0)
            {
                Position.X--;
            }
            else if (HowMuchToMove.Y > 0)
            {
                Position.Y++;
            }
            else if (HowMuchToMove.Y < 0)
            {
                Position.Y--;
            }

            ScreenDraw.DrawAt(Position.X, Position.Y, ScreenDraw.Pixel, ConsoleColor.Red);
        }
    }
}
