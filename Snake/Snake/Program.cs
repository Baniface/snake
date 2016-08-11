using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.SetBufferSize(80, 25);
            char sym = '+';

            HorizontalLine lineTop = new HorizontalLine(Console.WindowLeft, 78, 0, sym);
            lineTop.Draw();

            HorizontalLine lineBottom = new HorizontalLine(Console.WindowLeft, 78, 24, sym);
            lineBottom.Draw();

            VerticalLine lineLeft = new VerticalLine(Console.WindowLeft, 1, 24, sym);
            lineLeft.Draw();

            VerticalLine lineRight = new VerticalLine(78, 1, 24, sym);
            lineRight.Draw();

            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            Console.ReadLine();
        }
    }
}
