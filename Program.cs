using System;
using System.Collections.Generic;

namespace Pong.NET
{
    class Program
    {
        static int width = 22;
        static int height = 12;
        static bool[,] displayArray = new bool[width, height];

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine(Draw());
            }
        }

        static string Draw()
        {
            string displayString = "";
            
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
    }
}
