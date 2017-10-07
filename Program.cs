using System;

namespace Pong.NET
{
    class Program
    {
        static int width = 22;
        static int height = 12;
        static bool[,] displayArray = new bool[width, height];

        static int[] player1Pos = new int[] {(int)Math.Floor((float)height / 2), (int)Math.Floor((float)height / 2) - 1};
        static int[] player2Pos = new int[] {(int)Math.Floor((float)height / 2), (int)Math.Floor((float)height / 2) - 1};

        static int[] ballPos = new int[] {3, player1Pos[1]};
        static bool ballDown = false;
        static bool ballLeft = false;

        static void Main(string[] args)
        {
            while (true)
            {
                GetUserInput();
                Console.WriteLine(Draw());
                System.Threading.Thread.Sleep(200);
            }
        }

        static string Draw()
        {
            string displayString = "";

            Console.Clear();
            
            // Create the blank play area in an array
            for (int iwidth = 0; iwidth < width; iwidth++)
            {
                for (int iheight = 0; iheight < height; iheight++)
                {
                    if (iwidth == 0 ||
                        iwidth == width - 1 ||
                        iheight == 0 ||
                        iheight == height - 1)
                    {
                        displayArray[iwidth, iheight] = true;
                    }
                    else
                    {
                        displayArray[iwidth, iheight] = false;
                    }
                }
            }

            // Add the players to the array
            displayArray[2, player1Pos[0]] = true;
            displayArray[2, player1Pos[1]] = true;
            displayArray[width - 3, player2Pos[0]] = true;
            displayArray[width - 3, player2Pos[1]] = true;

            // Calculate ball position
            if (displayArray[ballPos[0], ballPos[1] - 1])
            {
                ballDown = true;
            }

            if (displayArray[ballPos[0], ballPos[1] + 1])
            {
                ballDown = false;
            }

            if (displayArray[ballPos[0] - 1, ballPos[1]])
            {
                ballLeft = true;
            }

            if (displayArray[ballPos[0] + 1, ballPos[1]])
            {
                ballLeft = false;
            }

            if (ballDown)
            {
                ballPos[1]++;
            }
            else
            {
                ballPos[1]--;
            }

            if (ballLeft)
            {
                ballPos[0]++;
            }
            else
            {
                ballPos[0]--;
            }

            displayArray[ballPos[0], ballPos[1]] = true;
            
            // Create the string that will be printed to the console
            for (int iheight = 0; iheight < height; iheight++)
            {
                for (int iwidth = 0; iwidth < width; iwidth++)
                {
                    if (displayArray[iwidth, iheight])
                    {
                        displayString += "\u2588";
                    }
                    else
                    {
                        displayString += " ";
                    }
                }
                displayString += "\n";
            }

            return displayString;
        }

        static void GetUserInput()
        {
            // Exit the method if we're not pressing anything
            if (Console.KeyAvailable == false)
            {
                return;
            }

            // Store the user input and check if they're moving up or down
            var input = Console.ReadKey().Key;

            if (input == ConsoleKey.W && !displayArray[2, player1Pos[1] - 1])
            {
                player1Pos[0]--;
                player1Pos[1]--;
            }

            if (input == ConsoleKey.S && !displayArray[2, player1Pos[0] + 1])
            {
                player1Pos[0]++;
                player1Pos[1]++;
            }
            return;
        }
    }
}
