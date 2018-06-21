using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nibble
{
    class Snake
    {
        public List<BoardElement> body; 
        public Snake(int x, int y, int size)
        {
            body = new List<BoardElement>();
            body.Add(new BoardElement(x, y));
            for (int i = 1; i < size; i++)
                body.Add(new BoardElement(x + i, y));
        }
        public void draw()
        {
            foreach (BoardElement element in body)
            {
                Console.SetCursorPosition(element.x, element.y);
                Console.Write('@');
            }
            Console.SetCursorPosition(0, 0);
        }
        public int getX()
        {
            return body[body.Count - 1].x;
        }
        public int getY()
        {
            return body[body.Count - 1].y;
        }
        public void expandSnake(int x, int y)
        {
            body.Add(new BoardElement(x, y));
        }
        public void removeLastPart()
        {
            body.RemoveAt(0);
        }
        public bool hitItself(int x, int y)
        {
            foreach(BoardElement element in body)
            {
                if (element.x == x && element.y == y)
                    return true;
            }
            return false;
        }
    }
}
