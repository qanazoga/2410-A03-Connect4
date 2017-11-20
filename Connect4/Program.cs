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
            Controller controller = Controller.GetInstance();

            //Delete next line
            Random rand = new Random();

            while (!gsm.GameOver)
            {
                ui.Refresh();
                controller.Move();
                //ui.Place(rand.Next(7));
                //Thread.Sleep(1000);
            }
            
        }

    }
}
