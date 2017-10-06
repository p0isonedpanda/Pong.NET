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

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine(Draw());
                GetUserInput();
                System.Threading.Thread.Sleep(10);
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
