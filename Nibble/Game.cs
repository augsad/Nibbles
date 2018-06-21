using System;
using System.Threading;
namespace Nibble
{
    class Game
    {
        private GameStates state;
        private Directions direction;
        private Snake snake;
        private Board board;
        private Food food;
        private int level;
        public Game()
        {
            state = GameStates.Menu;
            board = new Board(Constants.BOARD_WIDTH, Constants.BOARD_HEIGHT);
            food = new Food();
            level = 0;
        }

        public void start()
        {
            while(true)
            {
                if (state == GameStates.Menu)
                {
                    Console.Clear();
                    openMenu();
                }
                else if(state == GameStates.Starting)
                {
                    Console.Clear();
                    board.draw(level);
                    direction = Directions.RIGHT;
                    snake = new Snake(board.width / 2, board.height / 2, Constants.SNAKE_SIZE);
                    state = GameStates.Started;
                    food.level = 0;
                    food.createAtRandomPos(board, snake);
                    Console.CursorVisible = false;
                }
                else // game started
                {
                    int x = snake.getX();
                    int y = snake.getY();
                    checkKeyInput();
                    switch (direction)
                    {
                        case Directions.UP:
                            y--;
                            break;
                        case Directions.RIGHT:
                            x++;
                            break;
                        case Directions.DOWN:
                            y++;
                            break;
                        case Directions.LEFT:
                            x--;
                            break;
                    }
                    int foodCollected = 0;
                    if(snake.hitItself(x,y) || board.checkWallHit(x,y))
                    {
                        over();
                    }
                    else if (x == food.x && y == food.y)
                    {
                        foodCollected = food.level;
                        food.createAtRandomPos(board, snake);
                        if(food.level == Constants.FOOD_COUNT_FOR_LVLUP && level < Constants.MAX_LVL)
                        {
                            level++;
                            snake = new Snake(board.width/2, board.height/2, Constants.SNAKE_SIZE);
                            state = GameStates.Starting;
                        }
                        
                    }
                    snake.expandSnake(x, y);
                    x = snake.body[0].x;
                    y = snake.body[0].y;
                    if (foodCollected == 0)
                    {
                        snake.removeLastPart();
                        Console.SetCursorPosition(x, y);
                        Console.Write(" ");
                    }
                    else
                        foodCollected--;
                   
                    snake.draw();
                    int speed = 100 - level * Constants.SPEED;
                    if(speed > 0)
                        Thread.Sleep(speed);
                }
            }
        }
        
        public void openMenu()
        {
            Console.WriteLine("\tNibbles game\n\n\n 1 - Start game\n 2 - Exit");
            string choice = Console.ReadLine();
            {
                if (choice == "1")
                {
                    level = 1;
                    state = GameStates.Starting;
                }
                else if (choice == "2")
                {
                    System.Environment.Exit(1);
                }
            }
        }
        public void checkKeyInput()
        {
            if (state == GameStates.Started && Console.KeyAvailable)
            {
                var key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if (direction != Directions.DOWN)
                            direction = Directions.UP;
                        break;
                    case ConsoleKey.DownArrow:
                        if (direction != Directions.UP)
                            direction = Directions.DOWN;
                        break;
                    case ConsoleKey.RightArrow:
                        if (direction != Directions.LEFT && direction != Directions.RIGHT)
                            direction = Directions.RIGHT;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (direction != Directions.RIGHT)
                            direction = Directions.LEFT;
                        break;
                }
            }
        }
        public void over()
        {
            Console.Clear();
            Console.WriteLine("GAME OVER\nPress any key to continue...");
            Console.CursorVisible = true;
            Console.ReadKey();
            state = GameStates.Menu;
        }
    }
}
