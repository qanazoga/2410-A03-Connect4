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
            Evaluator eval = Evaluator.GetInstance();

            //Delete next line
            Random rand = new Random();

            while (!gsm.GameOver)
            {
                ui.Refresh();

                if (controller.Move())
                {
                    ui.Place(controller.SelectedLocation);
                    eval.CheckForWins();
                }

            }
            gsm.NextTurn();

            // I love this line so much <3
            Console.BackgroundColor = (ConsoleColor)(gsm.TurnCycle == PlayerTurn.Player1 ? Color.Red : Color.Blue);
            Console.WriteLine($"{gsm.TurnCycle} wins!");
            Thread.Sleep(1500);

        }

    }
}
