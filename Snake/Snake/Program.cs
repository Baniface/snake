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
        static int w = 80;
        static int h = 25;
        
        static void Main(string[] args)
        {
            Console.SetBufferSize(w, h);

            Walls walls = new Walls(w, h);
            walls.Draw();

            //отрисовка змейки
            Point p = new Point(4, 5, '8');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(w, h, '$');
            Point food;
            do
            {
                food = foodCreator.CreateFood();
            }
            while (snake.FoodInSnake(food));
            food.Draw();
            
            while(true)
            {
                if(walls.IsHit(snake) || snake.IsHitTail())
                {
                    TheEnd theEnd = new TheEnd(snake, food);
                    if (theEnd.isExit())
                        break;
                    else
                    {
                        Refresh(walls);
                        snake = new Snake(p, 4, Direction.RIGHT);
                        snake.Draw();

                        do
                        {
                            food = foodCreator.CreateFood();
                        }
                        while (snake.FoodInSnake(food));
                        food.Draw();
                    }
                }
                if(snake.Eat(food))
                {
                    do
                    {
                        food = foodCreator.CreateFood();
                    }
                    while (snake.FoodInSnake(food));
                    food.Draw();
                }
                else
                {
                    //snake.Move();
                }

                //Thread.Sleep(100);
                
                if(Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    snake.HandleKey(key.Key);
                }

                Thread.Sleep(100);
                snake.Move();
            }
        }

        static void Refresh(Walls walls)
        {
            Console.Clear();
            walls.Draw();
        }
    }
}
