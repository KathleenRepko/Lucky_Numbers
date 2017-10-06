using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucky_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //// Part 1
            //// Ask the user for a starting number for the lowest number in the number range.
            //// Ask the user for an ending number for the highest number in the number range.
            //// Ask the user to guess the 6 numbers the user thinks will be the lucky numbers generated within the number range.
            //// Numbers must be stored in an array
            //// Array must be populated using a loop
            //// If the user enters a number that is outside of the range set, prompt the user to give you a valid number. 
            ////Do this until the user enters a valid number.
            int[] userPicks = new int[6];

            double wholeJackpot = 7000000;
            string jackpotString = wholeJackpot.ToString("###,###,###.##");
       
            Console.WriteLine("Welcome to the Loopy Lottery! Is this your lucky day?");
            Console.WriteLine("Pick six numbers from a range of your choosing. You could win up to $" + jackpotString + "!");

            Console.WriteLine("What number is the lower end of your range?");
            int lowEnd = int.Parse(Console.ReadLine());
            Console.WriteLine("What is the upper end of your range?");
            int upperEnd = int.Parse(Console.ReadLine());
            Console.WriteLine("Excellent! Let's give it a whirl!");

            int userPick = new int();
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine("Enter a number:");
                userPick = int.Parse(Console.ReadLine());

                if (userPick < lowEnd || userPick > upperEnd)
                {
                    Console.WriteLine("That number is not within the range that you established.");
                    i = i - 1;
                }
                else
                {
                    userPicks[i] = userPick;
                }


                //Part 2

                //// The program should randomly generate 6 numbers using a loop
                //// The randomly generated numbers should be stored in an array
                //// Numbers should be displayed to the console as such and using a loop (Numbers below are for example only. Format must be exact):
                ////Lucky Number: 12
                ////Lucky Number: 47
                ////Lucky Number: 28
                ////Lucky Number: 3
                ////Lucky Number: 19
                ////Lucky Number: 35


                int[] randomPicks = new int[5];
                Random rand = new Random();

                for (int j = 0; j < 6; j++)
                {
                    randomPicks[j] = rand.Next(lowEnd, upperEnd);
                    while (randomPicks[j] == randomPicks[j+1])
                    {
                        randomPicks[j] = rand.Next(lowEnd, upperEnd);
                    }
                }
                //{
                //    int firstRand = rand.Next(lowEnd, upperEnd);
                //    int secondRand = rand.Next(lowEnd, upperEnd);
                //    while (firstRand == secondRand)
                //    {
                //        secondRand = rand.Next(lowEnd, upperEnd);

                //        randomPicks[j] = firstRand;
                //    }
                }
                //Creating method for console to print the lucky numbers.

                PrintLuckyNumbers(randomPicks);

                //Part 3

                //// Hard - code a value for the jackpot amount and let the user know what the jackpot amount is at some point you decide in the program.
                // The program should count the number of correctly guessed numbers and output console how many were correct to notify the user.Example:
                ////You guessed 3 numbers correctly!
                //   The program should calculate the user's winnings based on the number of numbers guessed correctly. 
                //e.g If the user correctly guessed 2 out of the 6 numbers correctly the program will calculate .33 of the total jackpot the winnings.

                // The user's winnings should be output to the console. Example:
                //  You won $256, 877.23!

                int correctPicks = 0;
                foreach (int rand in randomPicks)
                {
                    for (int k = 0; k < 6; k++)
                    {
                        while (userPicks[k] == rand)
                        {
                            correctPicks = correctPicks + 1;
                        }
                    }
                }
                Console.WriteLine("You guessed " + correctPicks + " correctly!");

                double winnings = new double();
                string winningsString = winnings.ToString("###,###,###.##");

                switch (correctPicks)
                {
                    case 6:
                        winnings = wholeJackpot;
                        break;
                    case 5:
                        winnings = wholeJackpot * 0.8;
                        break;
                    case 4:
                        winnings = wholeJackpot * 0.6;
                        break;
                    case 3:
                        winnings = wholeJackpot * 0.5;
                        break;
                    case 2:
                        winnings = wholeJackpot * 0.35;
                        break;
                    case 1:
                        winnings = wholeJackpot * 0.12;
                        break;
                    case 0:
                        winnings = 0.00;
                        break;
                }
                Console.WriteLine("You won $" + winningsString + "!");




                //  Part 4

                //   Ask the user if the user would like to play again.
                // If the user says yes, then the program should run again from the beginning.
                // If the user says no, then the program should say "Thanks for playing!"(Must be exact statement).



                //Stretch Tasks:

                //Make your program ensure none of the generated numbers are repeated.For example, the following is a valid output:
                //Lucky Number: 12
                //Lucky Number: 47
                //Lucky Number: 28
                //Lucky Number: 3
                //Lucky Number: 19
                //Lucky Number: 35
                //But, the following output is invalid because 12 is generated twice.
                //Lucky Number: 12
                //Lucky Number: 47
                //Lucky Number: 28
                //Lucky Number: 3
                //Lucky Number: 19
                //Lucky Number: 12
                //If there is a repeated number, replace it with a new number.Do this until there are no repeated numbers.

            }

        }

        public static void PrintLuckyNumbers(int[] randomPicks)
        {
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine("Lucky Number: " + randomPicks[i]);
            }

        }
    }
    
