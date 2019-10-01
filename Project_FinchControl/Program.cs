using System;
using System.Collections.Generic;
using FinchAPI;

namespace Project_FinchControl
{

    // **************************************************
    //
    // Title: Finch Control
    // Description: 
    // Application Type: Console
    // Author: 
    // Dated Created: 
    // Last Modified: 
    //
    // **************************************************

    class Program
    {
        static void Main(string[] args)
        {
            DisplayWelcomeScreen();


            DisplayClosingScreen();
        }

        /// <summary>
        /// connect the Finch robot to the application
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void DisplayConnectFinchRobot(Finch finchRobot)
        {
            const int MAX_ATTEMPTS = 3;
            int attempts = 1;

            DisplayScreenHeader("Connect Finch Robot");

            Console.WriteLine("\tConnecting to the Finch robot. Be sure the USB cord is plugged into both the robot and the computer.");
            Console.WriteLine();
            DisplayContinuePrompt();

            //
            // loop until the Finch robot is connected or the maximum number of attempts is exceeded
            //
            while (!finchRobot.connect() && attempts <= MAX_ATTEMPTS)
            {
                Console.WriteLine();
                Console.WriteLine("\tUnable to connect to the Finch robot. Please confirm all USB cords are plugged in.");
                Console.WriteLine();
                DisplayContinuePrompt();
                attempts++;
            }

            //
            // notify the user if the maximum attempts is exceeded
            //
            if (attempts > MAX_ATTEMPTS)
            {
                Console.WriteLine();
                Console.WriteLine("\tUnable to connect to the Finch robot. Please check the Finch robot or try a different one.");
                Console.WriteLine();
                DisplayContinuePrompt();
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display welcome screen
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tFinch Control");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display closing screen
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using Finch Control!");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        #region HELPER METHODS

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display screen header
        /// </summary>
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }

        #endregion
    }
}
