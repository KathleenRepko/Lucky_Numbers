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

            Console.WriteLine("Welcome to Richie's Loopy Lottery! Is this your lucky day?");
            string playAgain;
            do
            {
                //User decides range of lucky numbers, then picks 6 numbers within the range which will be stored in array.

                double wholeJackpot = 7000000;
                string jackpotString = wholeJackpot.ToString("###,###,###.##");

                
                Console.WriteLine("\nPick six numbers from a range of your choosing.\nYou could win up to $" + jackpotString + "!");

                Console.WriteLine("\nWhat number is the lower end of your range?");
                int lowEnd = int.Parse(Console.ReadLine());

                int upperEnd;
                do
                {
                    Console.WriteLine("\nWhat is the upper end of your range?");
                    upperEnd = int.Parse(Console.ReadLine());
                    if ((upperEnd - lowEnd) < 6)
                    {
                        Console.WriteLine("Your range is too small. Enter a larger number for the upper end of your range.");
                    }
                }
                while ((upperEnd - lowEnd) < 6);

                //Range is inclusive of low end input, but not inclusive of upper end input, so add one to that upper end figure.

                int adjustedUpperEnd = upperEnd + 1;
                Console.WriteLine("\nExcellent! Let's give it a whirl!");

                int[] userPicks = new int[6];
                //int userPick = new int();
                for (int i = 0; i < 6; i++)
                {
                    Console.WriteLine("\nEnter a number:");
                    int userPick = int.Parse(Console.ReadLine());

                    if (userPick < lowEnd || userPick > adjustedUpperEnd)
                    {
                        Console.WriteLine("\nThat number is not within the range that you established.");
                        i -= 1;
                    }
                    else if (userPicks.Contains(userPick))
                    {
                        Console.WriteLine("You already picked that number.");
                        i -= 1;
                    }
                    else
                    {
                        userPicks[i] = userPick;
                    }
                }


                //Generate six random numbers and store in array.
                //Stretch Task:
                //Make your program ensure none of the generated numbers is repeated.
                //If there is a repeated number, replace it with a new number.Do this until there are no repeated numbers.


                int[] randPicks = new int[6];
                Random rand = new Random();

                for (int j = 0; j < 6; j++)
                {
                    int firstRand = rand.Next(lowEnd, adjustedUpperEnd);
                    randPicks[j] = firstRand;

                    int secondRand = rand.Next(lowEnd, adjustedUpperEnd);
                    while (randPicks.Contains(secondRand))
                    {
                        secondRand = rand.Next(lowEnd, adjustedUpperEnd);
                    }
                    randPicks[j] = secondRand;   
                }

                //Create method for console to print the lucky numbers.
                Console.WriteLine("\nLet's see what the winning numbers are!\n");
                PrintLuckyNumbers(randPicks);

                //Determine how many of user's picks match the lucky numbers.

                int correctPicks = 0;
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (userPicks[i] == randPicks[j])
                        {
                            correctPicks = correctPicks + 1;
                        }
                    }
                }

                if (correctPicks == 1)
                {
                    Console.WriteLine("\nYou guessed " + correctPicks + " number correctly!");
                }
                else
                {
                    Console.WriteLine("\nYou guessed " + correctPicks + " numbers correctly!");
                }


                double winnings = new double();

                switch (correctPicks)
                {
                    case 6:
                        winnings = wholeJackpot;
                        break;
                    case 5:
                        winnings = wholeJackpot * 0.87;
                        break;
                    case 4:
                        winnings = wholeJackpot * 0.67;
                        break;
                    case 3:
                        winnings = wholeJackpot * 0.50;
                        break;
                    case 2:
                        winnings = wholeJackpot * 0.34;
                        break;
                    case 1:
                        winnings = wholeJackpot * 0.17;
                        break;
                    default:
                        winnings = wholeJackpot * 0.00;
                        break;
                }
                if (correctPicks == 0)
                {
                    Console.WriteLine("\nYou won $0. Better luck next time!");
                }
                else
                {
                string winningsString = winnings.ToString("###,###,###.##");
                Console.WriteLine("\nYou won $" + winningsString + "!");
                }
                

               
                //If user wishes to play again, program runs from beginning; else game ends.

                Console.WriteLine("\nWould you like to play again? (yes/no)");
                playAgain = Console.ReadLine().ToLower();
            } while (playAgain == "yes");

            Console.WriteLine("\nThanks for playing!\n");
        }

        

        public static void PrintLuckyNumbers(int[] randPicks)
        {
            for (int j = 0; j < 6; j++)
            {
                Console.WriteLine("Lucky Number: " + randPicks[j]);
            }


        }
    }
}

    
    
