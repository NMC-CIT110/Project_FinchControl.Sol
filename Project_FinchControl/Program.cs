using System;
using System.Collections.Generic;
using FinchAPI;

namespace Project_FinchControl
{

    // **************************************************
    //
    // Title: Finch Control
    // Description: Application to control the Finch robot with four modules;
    //              Talent Show, Data Recorder, Alarm System, User Programming
    // Application Type: Console
    // Author: Velis, John
    // Dated Created: 10/1/2019
    // Last Modified: 
    //
    // **************************************************

    class Program
    {
        static void Main(string[] args)
        {
            DisplayWelcomeScreen();
            DisplayMenu();
            DisplayClosingScreen();
        }

        /// <summary>
        /// module: Talent Show
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void TalentShow(Finch finchRobot)
        {
            DisplayScreenHeader("Talent Show");

            Console.WriteLine("The Finch robot will now show its talent.");
            DisplayContinuePrompt();

            for (int i = 0; i < 255; i++)
            {
                finchRobot.setLED(i, i, i);
                finchRobot.noteOn(i * 100);
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// module: User Programming
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void UserProgramming(Finch finchRobot)
        {
            DisplayScreenHeader("User Programming");

            Console.WriteLine("Method Not Implemented");

            DisplayContinuePrompt();
        }

        /// <summary>
        /// module: Alarm System
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void AlarmSystem(Finch finchRobot)
        {
            DisplayScreenHeader("Alarm System");

            Console.WriteLine("Method Not Implemented");

            DisplayContinuePrompt();
        }

        /// <summary>
        /// module: Data Recorder
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void DataRecorder(Finch finchRobot)
        {
            DisplayScreenHeader("Data Recorder");

            Console.WriteLine("Method Not Implemented");

            DisplayContinuePrompt();
        }

        static void DisplayMenu()
        {
            //
            // instantiate a Finch object
            //
            Finch finchRobot = new Finch();

            bool finchRobotConnected = false;
            bool quitApplication = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Main Menu");

                Console.WriteLine("a) Connect Finch Robot");
                Console.WriteLine("b) Talent Show");
                Console.WriteLine("c) Data Recorder");
                Console.WriteLine("d) Alarm System");
                Console.WriteLine("e) User Programming");
                Console.WriteLine("f) Disconnect Finch Robot");
                Console.WriteLine("q) Quit");
                Console.Write("Enter Choice:");
                menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "a":
                    case "A":
                        finchRobotConnected = DisplayConnectFinchRobot(finchRobot);
                        break;
                    case "b":
                    case "B":
                        if (finchRobotConnected) TalentShow(finchRobot);
                        else DisplayConnectionIssueInformation();
                        break;
                    case "c":
                    case "C":
                        if (finchRobotConnected) DataRecorder(finchRobot);
                        else DisplayConnectionIssueInformation();
                        break;
                    case "d":
                    case "D":
                        if (finchRobotConnected) AlarmSystem(finchRobot);
                        else DisplayConnectionIssueInformation();
                        break;
                    case "e":
                    case "E":
                        if (finchRobotConnected) UserProgramming(finchRobot);
                        else DisplayConnectionIssueInformation();
                        break;
                    case "f":
                    case "F":
                        DisplayDisconnectFinchRobot(finchRobot);
                        break;
                    case "q":
                    case "Q":
                        quitApplication = true;
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Please provide a proper menu choice.");
                        DisplayContinuePrompt();
                        break;
                }
            } while (!quitApplication);

        }

        /// <summary>
        /// display disconnecting from the Finch robot
        /// </summary>
        /// <param name="finchRobot"></param>
        static void DisplayDisconnectFinchRobot(Finch finchRobot)
        {
            DisplayScreenHeader("Disconnect the Finch Robot");

            Console.WriteLine("The Finch robot is about to be disconnected.");
            DisplayContinuePrompt();

            finchRobot.disConnect();
            Console.WriteLine();
            Console.WriteLine("The Finch robot is now disconnected.");

            DisplayContinuePrompt();
        }

        /// <summary>
        /// displayed when a module is called and the Finch robot is not connected
        /// </summary>
        static void DisplayConnectionIssueInformation()
        {
            DisplayScreenHeader("Connection Information");
            Console.WriteLine("The Finch robot is not connected. Please confirm that the USB cables are fully connected and choose \"a\" from the menu to connect the Finch robot.");
            DisplayContinuePrompt();
        }


        /// <summary>
        /// connect the Finch robot to the application
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static bool DisplayConnectFinchRobot(Finch finchRobot)
        {
            const int MAX_ATTEMPTS = 3;
            int attempts = 0;
            bool finchRobotConnected;

            DisplayScreenHeader("Connect Finch Robot");

            Console.WriteLine("\tConnecting to the Finch robot. Be sure the USB cord is plugged into both the robot and the computer.");
            Console.WriteLine();
            DisplayContinuePrompt();

            //
            // loop until the Finch robot is connected or the maximum number of attempts is exceeded
            //
            do
            {
                //
                // increment attempt counter
                //
                attempts++;

                finchRobotConnected = finchRobot.connect();

                if (!finchRobotConnected)
                {
                    Console.WriteLine();
                    Console.WriteLine("\tUnable to connect to the Finch robot. Please confirm all USB cords are plugged in.");
                    Console.WriteLine();
                    DisplayContinuePrompt();
                }
            } while (!finchRobot.connect() && attempts < MAX_ATTEMPTS);

            //
            // notify the user if the maximum attempts is exceeded
            //
            if (finchRobotConnected)
            {
                Console.WriteLine();
                Console.WriteLine("\tFinch robot is now connected.");
                Console.WriteLine();
                finchRobot.setLED(0, 255, 0); // set nose to green
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("\tUnable to connect to the Finch robot. Please check the Finch robot or try a different one.");
                Console.WriteLine();
            }

            DisplayContinuePrompt();

            return finchRobotConnected;
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
            Console.WriteLine("\t\tPress any key to continue.");
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
