using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RobGame.Core.Characters
{
    /// <summary>
    /// The base character class that all characters inherit from.
    /// </summary>
    public abstract class BaseCharacter : GameObject
    {
        /// <summary>
        /// Used to set the position of the character. Takes in a Vector2Int for the new position.
        /// </summary>
        /// <param name="newPosition">Vector2Int new position to set</param>
        public virtual void SetPos(Vector2Int newPosition)
        {
            Position = newPosition;
        }

        /// <summary>
        /// Used to set rotation of the character. Takes a Vector2 for the new direction.
        /// </summary>
        /// <param name="newRotation">Vector2 new rotation to set</param>
        public virtual void SetRot(Vector2 newRotation)
        {
            Direction = newRotation;
        }

        /// <summary>
        /// Used to remove the object.
        /// </summary>
        public virtual void Destroy()
        {
            
        }

        /// <summary>
        /// Creates a new character.
        /// </summary>
        /// <param name="position">The current position which is a Vector2Int</param>
        /// <param name="rotation">The current rotation which is a Vector2</param>
        public BaseCharacter(Vector2Int position, Vector2 rotation) : base(position, rotation)
        {

        }

        /// <summary>
        /// Creates a new character with zero for position and rotation.
        /// </summary>
        public BaseCharacter()
        {
            Position = Vector2Int.Zero;
            Direction = Vector2.Zero;
        }

    }
}
