using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Connect4
{
    class Program
    {
        static void Main(string[] args)
        {
            GameStateManager gsm = GameStateManager.GetInstance();
            UI ui = UI.GetInstance();

            //Delete next line
            Random rand = new Random();

            while (!gsm.GameOver)
            {
                ui.Refresh();
                ui.Place(rand.Next(6));
                Thread.Sleep(1000);
            }
            
        }

    }
}
