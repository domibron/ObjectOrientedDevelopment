using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobGame.Core.Special;

namespace RobGame.Core
{
    /// <summary>
    /// The main menu class is used to interact with the game manager.
    /// </summary>
    public class MainMenu
    {
        // The game manager that we will use to load and manage the game.
        private GameManager _gameManager = new GameManager();

        /// <summary>
        /// Start function starts the application and puts it in a loop. 
        /// It returns a code that can be used to detect when the application has exited.
        /// </summary>
        /// <returns>Exit Code</returns>
        public int Start()
        {
            MainMenuLoop();
            return 1;
        }

        /// <summary>
        /// The main menu loop is the main menu.
        /// It displays the UI to load levels and also to exit the application.
        /// </summary>
        public void MainMenuLoop()
        {
            // first while loop for the main menu.
            while (true)
            {
                // display the options to the player on the console.
                Console.WriteLine("1 - Level select | 2 - Quit");

                // we get a input from the player.
                string input = Console.ReadLine();

                // we check if the input is valid. if not, we cycle back to the next loop iteration.
                if (!Util.ValidateInput(input, 1, 2))
                {
                    // we cannot use a return other wise we will exit the loop and function.
                    continue;
                }

                // we convert the input into a int, so we can see what the player entered.
                int convertedInput = Util.ConvertInput(input);

                // If the converted input is invalid (-1) we cycle back to the next loop iteration.
                if (convertedInput == -1) continue;

                // If the player enters the exit option, which is 2, and we exit the application.
                if (convertedInput == 2) Environment.Exit(2);

                // if we enter 1, then we enter the level select loop.
                if (convertedInput == 1)
                {
                    LevelSelectLoop();
                }

                // we clear the console so we dont have residual text.
                Console.Clear();
            }
        }

        /// <summary>
        /// The level select loop is used to display the levels to the player,
        /// and get a input and load the respected level from the input.
        /// </summary>
        private void LevelSelectLoop()
        {
            // Second while loop for level select.
            while (true)
            {
                // we clear any left over text.
                Console.Clear();

                // we display the options to the plauer in the console.
                Console.WriteLine("0 - Back | 1 - Level 1 | 2 - Level 2 | 3 - Level 3");

                // we get the input from the player.
                string input = Console.ReadLine();

                // if the player enters a invalid input, we cycle to the next itteration.
                if (!Util.ValidateInput(input, 0, 3))
                {
                    continue;
                }

                // we convert the input into a int so we can check with other int. (we could use strings but for now we use this)
                int convertedInput = Util.ConvertInput(input);

                // if the input is invalid we cycle back to the next itteration.
                if (convertedInput == -1) continue;

                // if the input is zero, that is the back to main menu, so we break out of this loop.
                if (convertedInput == 0)
                {
                    break;
                }


                // one is level one and level one is loaded.
                if (convertedInput == 1)
                {
                    _gameManager.LoadLevel(Data.Level1);
                    break;
                }

                // two is level two and level two is loaded.
                if (convertedInput == 2)
                {
                    _gameManager.LoadLevel(Data.Level2);
                    break;
                }

                // three is level three and level three is loaded.
                if (convertedInput == 3)
                {
                    _gameManager.LoadLevel(Data.Level3);
                    break;
                }
            }
        }
    }
}
