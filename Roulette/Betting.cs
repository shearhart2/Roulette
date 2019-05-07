using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette
{
    class Betting
    {
        public int userFunds;
        //TODO: Provide user with starting amount of money for betting

        public Betting()
        {
            Console.WriteLine("Welcome to the Roulette Table, here is $1,000 to get you started.");
            userFunds += 1000;
        }

        //TODO:Take userInput for placing a bet

        public void TakingBetPrompt()
        {
            //TODO: Make this if-else a ternary operator, otherwise add a bool variable that the else if statement can set to false, or maybe try this with a wo-while loop instead.
            while (true)
            {
                Console.WriteLine("Would you like to place a bet? \n1. Yes \n2. No");

                string play = Console.ReadLine();

                if (play == "1")
                {
                    break;
                }
                else if (play == "2")
                {
                    break;
                }
                else
                {
                    continue;
                }
            }
        }

        ////TODO: Present option for type of bet, ex. group of six, single number, split...etc

        //////TODO: Allow the user to select how much to bet on a single bet placement

        //////TODO: Present the option to make multiple bets


    }
}
