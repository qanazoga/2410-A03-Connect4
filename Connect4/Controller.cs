using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4
{
    class Controller
    {
        private static Controller instance = null;
        public int SelectedLocation { get; set; }

        private GameStateManager gsm = GameStateManager.GetInstance();
        private UI ui = UI.GetInstance();

        private Controller()
        {
            SelectedLocation = 0;
        }

        public static Controller GetInstance()
        {
            if (instance == null)
                instance = new Controller();

            return instance;
        }
        

        public void Move()
        {
            var key = Console.ReadKey().Key;
            var len = gsm.Grid.GetLength(1);

            if (gsm.AcceptingInput)
            {
                if (key == ConsoleKey.LeftArrow)
                {
                    if (SelectedLocation == 0)
                        SelectedLocation = len;

                    SelectedLocation--;
                }

                if (key == ConsoleKey.RightArrow)
                {
                    if (SelectedLocation == len - 1)
                        SelectedLocation = 0;

                    SelectedLocation++;
                }

                if (key == ConsoleKey.Enter)
                {
                    ui.Place(SelectedLocation);
                }
            }

        }
    }
}
