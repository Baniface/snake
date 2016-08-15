using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class TheEnd
    {
        char sym = '=';
        public TheEnd(Snake snake, Point food)
        {
            food.Clear();
            snake.Clear();
            DrawText();
        }

        public bool isExit()
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Enter)
                return false;

            return true;
        }

        public void DrawText()
        {
            HorizontalLine h1 = new HorizontalLine(20, 40, 6, sym);
            HorizontalLine h2 = new HorizontalLine(20, 40, 14, sym);

            h1.Draw();
            h2.Draw();

            Console.SetCursorPosition(33, 8);
            Console.WriteLine("Игра окончена!");

            Console.SetCursorPosition(28, 10);
            Console.WriteLine("Продолжить? (Enter = да)");

        }
    }
}
