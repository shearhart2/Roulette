using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette
{
    class DetermineWinners
    {

        public (string, string)[] bins = new (string, string)[38]
        {
            ("0", "green"), ("1", "red"), ("2", "black"), ("3", "red"), ("4", "black"),
            ("5", "red"), ("6", "black"), ("7", "red"), ("8", "black"), ("9", "red"),
            ("10", "black"), ("11", "black"), ("12", "red"), ("13", "black"), ("14", "red"),
            ("15", "black"), ("16", "red"), ("17", "black"), ("18", "red"), ("19", "red"),
            ("20", "black"), ("21", "red"), ("22", "black"), ("23", "red"), ("24", "black"),
            ("25", "red"), ("26", "black"), ("27", "red"), ("28", "black"), ("29", "black"),
            ("30", "red"), ("31", "black"), ("32", "red"), ("33", "black"), ("34", "red"),
            ("35", "black"), ("36", "red"), ("00", "green")
        };

        public (string, string) winningSet { get; set; }

        public int theNumber { get; set; }
        
        public void LetsGamble(Random thisRandom)
        {
            bool play = true;

            while(play)
            {
                Console.WriteLine("Press any key to spin the wheel...");
                Console.ReadLine();

                winningSet = bins.ElementAt(thisRandom.Next(38));

                if (winningSet.Item2 == "green")
                {
                    Console.WriteLine($"The lucky number is {winningSet.Item1}! The house wins!");
                }
                else
                {
                    theNumber = Convert.ToInt32(winningSet.Item1);

                    Console.WriteLine("You win if you bet on: \n");
                    ActivateWinners();
                }

                while(true)
                {
                    Console.WriteLine("Would you like to play again? \n1. Yes \n2. No");

                    string playAgain = Console.ReadLine();
                    if (playAgain == "1")
                    {
                        break;
                    }
                    else if (playAgain == "2")
                    {
                        play = false;
                        break;
                    }
                    else
                    {
                        continue; 
                    }
                }
                
            }

        }

        public void ActivateWinners()
        {
            SingleNumber();
            Even_Odd();
            Red_Black();
            High_Low();
            Dozens();
            Console.WriteLine($"Column {Columns()}\n");
            Streets();
            GroupOf6(Columns());
            Split(Columns());
            Corner(Columns());

        }

        public void SingleNumber()
        {
            Console.WriteLine($"The number {theNumber}\n");
        }

        public void Even_Odd()
        {
            string verdict;

            if (theNumber % 2 == 0)
            {
                verdict = "Even";
            }
            else
            {
                verdict = "Odd";
            }

            Console.WriteLine($"{verdict}\n");
        }

        public void Red_Black()
        {
            Console.WriteLine($"The color {winningSet.Item2}\n");
        }

        public void High_Low()
        {
            string verdict;

            if (theNumber <19 )
            {
                verdict = "1 to 18";
            }
            else
            {
                verdict = "19 to 36";
            }

            Console.WriteLine($"{verdict}\n");
        }
        public void Dozens()
        {
            string verdict;

            if (theNumber < 13)
            {
                verdict = "1st 12";
            }
            else if(theNumber < 25)
            {
                verdict = "2nd 12";
            }
            else
            {
                verdict = "3rd 12";
            }

            Console.WriteLine($"{verdict}\n");
        }
        public int Columns()
        {
            int verdict;
            
            if (theNumber % 3 == 1)
            {
                verdict = 1;
            }
            else if (theNumber % 3 == 2)
            {
                verdict = 2;
            }
            else
            {
                verdict = 3;
            }

            return verdict;
        }
        public void Streets()
        {

            double street = Math.Ceiling(theNumber/3.0);
            
            Console.WriteLine($"Street {street}\n");
            
        }
        public void GroupOf6(int columnsReturn)
        {
            string groupIncludes;

            if (theNumber < 3)
            {
                groupIncludes = "1 through 6";
            }
            else if (theNumber >= 34)
            {
                groupIncludes = " 31 through 36";
            }
            else
            {
                if(columnsReturn == 1)
                {
                    groupIncludes = $"{theNumber-3} through {theNumber+2}" +
                                      $"\nor \nThe group of 6 numbers: {theNumber} through {theNumber+5}";
                }

                else if (columnsReturn == 2)
                {
                    groupIncludes = $"{theNumber - 4} through {theNumber + 1}" +
                                      $"\nor \nThe group of 6 numbers: {theNumber-1} through {theNumber + 4}";
                }

                else
                {
                    groupIncludes = $"{theNumber - 5} through {theNumber}" +
                                      $"\nor \nThe group of 6 numbers: {theNumber-2} through {theNumber + 3}";
                }
            }

            Console.WriteLine($"The group of 6 numbers: {groupIncludes}\n");
            
        }
        public void Split(int columnsReturn)
        {
            string splitIncludes;

            int addOne = theNumber + 1;
            int addThree = theNumber + 3;
            int subtractOne = theNumber - 1;
            int subtractThree = theNumber - 3;


            if (columnsReturn == 1)
            {
                if (theNumber < 3)
                {
                    splitIncludes = $"{addOne}, {addThree}";
                }
                else if (theNumber >= 34)
                {
                    splitIncludes = $"{subtractThree}, {addOne}";
                }
                else
                {
                    splitIncludes = $"{subtractThree}, {addOne}, {addThree}";
                }
            }

            else if (columnsReturn == 2)
            {
                if (theNumber < 3)
                {
                    splitIncludes = $"{subtractOne}, {addOne}, {addThree}";
                }
                else if (theNumber >= 34)
                {
                    splitIncludes = $"{subtractThree}, {subtractOne}, {addOne}";
                }
                else
                {
                    splitIncludes = $"{subtractThree}, {subtractOne}, {addOne}, {addThree}";

                }
            }

            else
            {
                if (theNumber < 3)
                {
                    splitIncludes = $"{subtractOne}, {addThree}";
                }
                else if (theNumber >= 34)
                {
                    splitIncludes = $"{subtractThree}, {subtractOne}";
                }
                else
                {
                    splitIncludes = $"{subtractThree}, {subtractOne}, {addThree}";
                }
            }
            Console.WriteLine($"The splits between {theNumber} and: {splitIncludes}\n");
        }

        public void Corner(int columnsReturn)
        {
            string cornerIncludes;

            int addOne = theNumber + 1;
            int addThree = theNumber + 3;
            int subtractOne = theNumber - 1;
            int subtractThree = theNumber - 3;



            string a = $"{addOne}, {addThree}, {theNumber + 4}";

            string b = $"{subtractThree}, {theNumber - 2}, {addOne}";

            string c = $"{subtractOne}, {theNumber + 2}, {addThree}";

            string d = $"{theNumber - 4}, {subtractThree}, {subtractOne}";

            if (columnsReturn == 1)
            {
                if (theNumber <= 3)
                {
                    cornerIncludes = $"{a}";
                }
                else if (theNumber >= 34)
                {
                    cornerIncludes = $"{b}";
                }
                else
                {
                    cornerIncludes = $"{b}" +
                        $"\nand \nThe corner between {theNumber}, {a}";
                }
            }

            else if (columnsReturn == 2)
            {
                if (theNumber <= 3)
                {
                    cornerIncludes = $"{c}" +
                        $"\nand \nThe corner between {theNumber}, {a}";
                }
                else if (theNumber >= 34)
                {
                    cornerIncludes = $"{d}" +
                        $"\nand \nThe corner between {theNumber}, {b}";
                }
                else
                {
                    cornerIncludes = $"{d}" +
                        $"\nand \nThe corner between {theNumber}, {b}" +
                        $"\nand \nThe corner between {theNumber}, {c}" +
                        $"\nand \nThe corner between {theNumber}, {a}";

                }
            }

            else
            {
                if (theNumber <= 3)
                {
                    cornerIncludes = $"{c}";
                }
                else if (theNumber >= 34)
                {
                    cornerIncludes = $"{d}";
                }
                else
                {
                    cornerIncludes = $"{c}" +
                        $"\nand \nThe corner between {theNumber}, {d}";
                }
            }
            Console.WriteLine($"The corner between {theNumber}, {cornerIncludes}\n");
        }
    }
}
