using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette
{
    
    public class Program
    {
        

        static void Main(string[] args)
        {
            Random SpinTheWheel = new Random();
            DetermineWinners RollTheDice = new DetermineWinners();

            RollTheDice.LetsGamble(SpinTheWheel);
        }


    }
}
