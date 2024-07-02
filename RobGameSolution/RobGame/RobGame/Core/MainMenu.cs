using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobGame.Core.Special;

namespace RobGame.Core
{
    public class MainMenu
    {
        // we want to hold the game (keep in loop)

        // display somthing.

        // play the game.

        // used so we dont have a nice crash. Love a log though.
        private bool _InMenu = true;

        private GameManager _gameManager = new GameManager();

        public int Start()
        {
            try
            {
                MainMenuLoop();
            }
            catch
            {
                return 1;
            }

            return 0;
        }

        public void MainMenuLoop()
        {
            while (_InMenu)
            {
                Console.WriteLine("1 - Level select | 2 - Quit");

                string input = Console.ReadLine();

                if (!Util.ValidateInput(input, 1, 2))
                {
                    continue;
                }

                int convertedInput = Util.ConvertInput(input);

                if (convertedInput == -1) continue;

                if (convertedInput == 2) Environment.Exit(2);

                if (convertedInput == 1)
                {
                    // this is ugly.
                    while (true)
                    {
                        Console.WriteLine("0 - Back | 1 - Level 1 | 2 - Level 2 | 3 - Level 3");

                        input = Console.ReadLine();

                        if (!Util.ValidateInput(input, 0, 3))
                        {
                            continue;
                        }

                        convertedInput = Util.ConvertInput(input);

                        if (convertedInput == -1) continue;

                        if (convertedInput == 0)
                        {
                            break;
                        }

                        if (convertedInput == 1)
                        {
                            _gameManager.LoadLevel(Data.Example);
                            break;
                        }
                    }
                }

                Console.Clear();
            }
        }
    }
}
