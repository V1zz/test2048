using System;
using _2048;

namespace test2048
{
    /// <summary>
    /// The goal is to repeat the lesson at the specified address to create a game 2048
    /// </summary>
    /// <param valuetype="ref" type="https://www.youtube.com/watch?v=643VxMIS7Q0"></param> 
    class Program
    {
        static void Main(string[] args)
        {
            //get rid of static
            var program = new Program();
            program.Start();
        }

        //Game instance
        private Model model;

        //Controller
        //Keyboard polling and screen display call
        void Start()
        {
            //Input parameter - game size
            var model = new Model(4);
            //Initialise game
            model.Start();
            while (true)
            {
                Show(model);
                switch (Console.ReadKey(false).Key)
                {
                    case ConsoleKey.LeftArrow:  model.Left(); break;
                    case ConsoleKey.RightArrow: model.Right(); break;
                    case ConsoleKey.UpArrow:    model.Up(); break;
                    case ConsoleKey.DownArrow:  model.Down(); break;
                    case ConsoleKey.Escape:     return;
                }
            }
        }

        //View
        //Model displaying
        //From the MODEL parameter we can get all the necessary information
        void Show(Model model)
        {
            //get info and show
            for (int y = 0; y < model.size; y++)
                for (int x = 0; x < model.size; x++)
                {
                    Console.SetCursorPosition(x * 5 + 5, y * 2 + 2);
                    var number = model.GetMap(x, y);
                    //Two extra spaces so that numbers do not overlap
                    Console.Write(number == 0 ? ".  " : number.ToString() + "  ");
                }
            Console.WriteLine();
            //Game over checking
            if (model.IsGameOver())
            {
                Console.WriteLine("====Game Over====");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("____Still Play____");
            }
        }
    }
}
