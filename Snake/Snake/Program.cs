using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.SetBufferSize(80, 25);
            char sym = '+';

            List<Figure> figures = new List<Figure>();

            HorizontalLine lineTop = new HorizontalLine(Console.WindowLeft, 78, 0, sym);
            HorizontalLine lineBottom = new HorizontalLine(Console.WindowLeft, 78, 24, sym);
            VerticalLine lineLeft = new VerticalLine(Console.WindowLeft, 1, 24, sym);
            VerticalLine lineRight = new VerticalLine(78, 1, 24, sym);

            figures.Add(lineTop);
            figures.Add(lineBottom);
            figures.Add(lineLeft);
            figures.Add(lineRight);

            //отрисовка змейки
            Point p = new Point(4, 5, '*');
            Figure fSnake = new Snake(p, 4, Direction.RIGHT);
            figures.Add(fSnake);
            //Draw(fSnake);
            Snake snake = (Snake)fSnake;
            //snake.Draw();

            foreach (var f in figures)
            {
                f.Draw();
            }

            FoodCreator foodCreator = new FoodCreator(80, 25, '#');
            Point food = foodCreator.CreateFood();
            food.Draw();
            
            while(true)
            {
                if(snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }

                Thread.Sleep(150);
                
                if(Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }

                Thread.Sleep(150);
                snake.Move();
            }
        }

        static void Draw(Figure figure)
        {
            figure.Draw();
        }
    }
}
