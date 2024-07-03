using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RobGame.Core.Characters
{
    /// <summary>
    /// The guard class is a enemy of the player and moves around a grid using a coordiate system.
    /// </summary>
    public class Guard : BaseCharacter
    {
        // the current level loaded so we can access information.
        public int[,] CurrentLevel;
        
        // the cords for the guard to move towards.
        public Dictionary<int, Vector2Int> Cords = new Dictionary<int, Vector2Int>();
        // the current cord the guard is moving towards.
        private int CurrentCord = 0;

        /// <summary>
        /// Creates a new guard with the inputted parameters.
        /// Vector2Int Position, Vector2 Rotation, int[,] current level.
        /// </summary>
        /// <param name="position">The currect position of the guard</param>
        /// <param name="rotation">The current rotation of the guard</param>
        /// <param name="currentLevel">The current level</param>
        public Guard(Vector2Int position, Vector2 rotation, int[,] currentLevel) : base(position, rotation) {
            // WILL PASS REF AND NOT DATA. arrays are fun. yay..
            CurrentLevel = currentLevel;
        }

        /// <summary>
        /// Adds a new coordiante to the pool of coordinates.
        /// </summary>
        /// <param name="cord">The coordinate's position</param>
        public void AddCord(Vector2Int cord)
        {
            Cords.Add(Cords.Count,cord);
        }

        /// <summary>
        /// Used to select the next cord by changing the CurrentCord variable.
        /// </summary>
        public void MoveToNext()
        {
            // if there are no coordinates, we return.
            if (Cords.Count <= 0) return;

            // we check if we will go over.
            if (CurrentCord + 1 < Cords.Count)
            {
                CurrentCord++;
            }
            else // if so, we will roll over.
            {
                CurrentCord = 0;
            }
        }

        /// <summary>
        /// Used to move the guard. This function handles movement and cord selection.
        /// </summary>
        public void MoveTick()
        {
            // if we have no coordinates, then we will exit.
            if (Cords.Count <= 0) { return; }

            // if we are at a cord, then we will get the next cord.
            if (Position == Cords[CurrentCord])
            {
                MoveToNext();
            }

            // We get the differnce from the two points. (we get a vector). We will use this later.
            Vector2Int HowMuchToMove = Cords[CurrentCord] - Position;

            // Fill the current square black as we are leaving the square.           
            ScreenDraw.DrawAt(Position.X * 2, Position.Y, ScreenDraw.Pixel, ConsoleColor.Black);
            
            // Checks which axis to move in to reach the cord and will move one square towards the cord.
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

            // draw the guard at the new position.
            ScreenDraw.DrawAt(Position.X*2, Position.Y, ScreenDraw.Pixel, ConsoleColor.Red);

        }
    }
}
