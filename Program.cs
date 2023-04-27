﻿using System;

namespace AnalogClock
{
    class Program 
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Analog Clock Solver!");
            Console.WriteLine("This Project aims to compute the lesser angles between the Hour and Minutes you will input. ");
            
            /*We must keep the user input to hours and minutes integers, respectively
            1.) filter string
            2.) filter negative
            4.) hours must be 1 - 12 only
            5.) minutes must be 0 - 59 only*/

            int hours, minutes;
            string contPrompt = null;
            
                while(true)
                {
                    Console.Clear();
                    Console.Write("Enter Hours (1-12): ");
                    if(!int.TryParse(Console.ReadLine(), out hours) || hours < 1 || hours > 12)
                    {
                        Console.WriteLine("Invalid input. Please enter an integer between 1 and 12.");
                        continue;
                    }

                    Console.Write("Enter Minutes (0-59): ");
                    if(!int.TryParse(Console.ReadLine(), out minutes) || minutes < 0 || hours > 59)
                    {
                        Console.WriteLine("Invalid input. Please enter an integer between 0 and 59.");
                        continue;
                    }

                    break;
                }

            /*
            We can now use our solve method/function to solve for the Angle 
            */
            Console.WriteLine("The Angle between Hour " + hours + " and Minute " + minutes + " is: " + Solve(hours, minutes) + " degrees");

            
           
        }

        static double Solve(int hours, int minutes)
        {   
            /*
            Since an analog clock hour hand moves 0.5deg per minute (360deg/720minutes) and minutes hand moves 6deg per minute (360/60minute): 
            1.) let us convert the user-input hours to minutes and multiply it by 5deg
            2.) minutes does not need to be converted and multiply it by 6deg
            */
            double hourAngle = 0.5 * (hours * 60);
            double minuteAngle = 6 * minutes;

            /*
            The project requirement is that it should be able to compute for lesser angles between hours and minutes arrow so we should take the complementary angle.
            1.) calculate the angle between hourAngle and minuteAngle
            2.) If the computed initial angle is greater than a 180deg, then the complementary angle must be the lesser angle.
            */
            double initialAngle = Math.Abs(hourAngle - minuteAngle);

            if(initialAngle > 180)
            {
                initialAngle = 360 - initialAngle;
            }

            return initialAngle;
        }

    }
}