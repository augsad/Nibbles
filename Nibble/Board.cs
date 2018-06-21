using System;
using System.Collections.Generic;

namespace Nibble
{
    class Board
    {
        public int width;
        public int height;
        List<BoardElement> walls;
        public Board(int width, int height)
        {
            this.width = width;
            this.height = height;
            walls = new List<BoardElement>();
        }
        public bool checkWallHit(int x, int y)
        {
            foreach(BoardElement wall in walls)
            {
                if (wall.x == x && wall.y == y)
                    return true;
            }
            return (x == 0 || y == 0 || x == width-1 || y == height-1);
        }
        public void draw(int level)
        {
            walls.Clear();
            for (int i = 0; i < width; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("*");
                Console.SetCursorPosition(i, height - 1);
                Console.Write("*");
            }
            for (int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("*");
                Console.SetCursorPosition(width - 1, i);
                Console.Write("*");

            }
            switch (level)
            {
                case 1:
                    loadTopDownWall(height / 2, width / 4);
                    loadTopDownWall(height / 2, width - width / 4);
                    break;
                case 2:
                    loadTopDownWall(height / 2, width / 4);
                    loadTopDownWall(height / 2, width - width / 4);
                    loadBotomUpWall(height / 2, width / 2);
                    break;
                case 3:
                    loadTopDownWall(height / 2, width / 4);
                    loadTopDownWall(height / 2, width - width / 4);
                    loadBotomUpWall(height / 2, width / 2);
                    loadBotomUpWall(height / 2, width / 8);
                    break;
                case 4:
                    loadTopDownWall(height / 2, width / 4);
                    loadTopDownWall(height / 4, width / 2);
                    loadTopDownWall(height / 2, width - width / 4);
                    loadBotomUpWall(height / 2, width / 2);
                    loadBotomUpWall(height / 2, width / 8);
                    break;
                case 5:
                    loadTopDownWall(height / 2, width / 4);
                    loadTopDownWall(height / 4, width / 2);
                    loadTopDownWall(height / 2, width - width / 4);
                    loadBotomUpWall(height / 2, width / 2);
                    loadBotomUpWall(height / 2, width / 8);
                    loadBotomUpWall(height / 2, width - width / 8);
                    break;
            }
        }
 
        public void loadBotomUpWall(int lenth, int pos)
        {
            for (int i = height - 1; i > height - lenth; i--)
            {
                walls.Add(new BoardElement(pos, i));
                Console.SetCursorPosition(pos, i);
                Console.Write("*");
            }
        }
        public void loadTopDownWall(int lenth, int pos)
        {
            for (int i = 0; i < lenth; i++)
            {
                walls.Add(new BoardElement(pos, i));
                Console.SetCursorPosition(pos, i);
                Console.Write("*");
            }
        }
    }
}
