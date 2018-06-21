using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nibble
{
    class Food
    {
        public int x;
        public int y;
        public int level;
        public Food()
        {
            level = 0;
        }

        public void createAtRandomPos(Board board, Snake snake)
        {
            Random random = new Random();
            List<BoardElement> emptyPlaces = new List<BoardElement>();
            for (int i = 1; i < board.width-1; i++)
            {
                for (int j = 1; j < board.height-1; j++)
                    if (!snake.hitItself(i, j) && !board.checkWallHit(i,j))
                        emptyPlaces.Add(new BoardElement(i, j));
            }
            int index = random.Next(emptyPlaces.Count);
            x = emptyPlaces[index].x;
            y = emptyPlaces[index].y;
            if(level < Constants.MAX_FOOD_LVL)
                level++;
            Console.SetCursorPosition(x, y);   
            Console.Write(level);
        }
    }
}
