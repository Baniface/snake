using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Walls
    {
        List<Figure> wallList;
        char sym = '+';

        public Walls (int mapWidth, int mapHeight)
        {
            wallList = new List<Figure>();

            HorizontalLine lineTop = new HorizontalLine(0, mapWidth - 2, 0, sym);
            HorizontalLine lineBottom = new HorizontalLine(0, mapWidth - 2, mapHeight - 1, sym);
            VerticalLine lineLeft = new VerticalLine(0, 0, mapHeight - 1, sym);
            VerticalLine lineRight = new VerticalLine(mapWidth - 2, 0, mapHeight - 1, sym);

            wallList.Add(lineTop);
            wallList.Add(lineBottom);
            wallList.Add(lineLeft);
            wallList.Add(lineRight);
        }

        internal bool IsHit(Figure figure)
        {
            foreach (var wall in wallList)
            {
                if(wall.IsHit(figure))
                {
                    return true;
                }
            }

            return false;
        }

        public void Draw()
        {
            foreach (var wall in wallList)
            {
                wall.Draw();
            }
        }
    }
}
