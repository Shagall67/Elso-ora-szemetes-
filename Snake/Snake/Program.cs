using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static string name;
        static readonly int gridW = 30;
        static readonly int gridH = 25;
        static Cell[,] grid = new Cell[gridH, gridW];
        static Cell currentCell;
        static int direction; //0=Up 1=Right 2=Down 3=Left
        static readonly int speed = 1;
        static bool Lost = false;
        static int snakeLength;
        static string bestPlayer;

        static void Main(string[] args)
        {
            getBestPlayer();
            Console.Clear();
            Console.Write("Gimme me ur name pls: ");
            name = Console.ReadLine();
            snakeLength = 5;
            populateGrid();
            currentCell = grid[(int)Math.Ceiling((double)gridH / 2), (int)Math.Ceiling((double)gridW / 2)];
            updatePos();
            addFood();

            while (!Lost)
            {
                Restart();
            }
        }

        static void Restart()
        {
            updateScreen();
            getInput();
        }

        static void updateScreen()
        {
            Console.SetCursorPosition(0, 0);
            printGrid();
            Console.WriteLine("Your points: {0}", snakeLength - 5);
        }

        static void getBestPlayer()
        {
            int bestScore = 0;
            foreach (var item in File.ReadAllText("Highscore.txt").Trim().Split("\n"))
            {
                string name = item.Split("|")[0];
                int points = int.Parse(item.Split("|")[1]);
                if (points > bestScore) bestPlayer = name + ": " + points + " point(s)";
            }
        }

        static void getInput()
        {
            ConsoleKeyInfo input;
            while (!Console.KeyAvailable)
            {
                Move();
                updateScreen();
            }
            input = Console.ReadKey();
            doInput(input.Key);
        }

        static void checkCell(Cell cell)
        {
            if (cell.value == "%")
            {
                eatFood();
            }
            if (cell.visited)
            {
                Lose();
            }
        }

        static void Lose()
        {
            File.AppendAllText("Highscore.txt", name + "|" + (snakeLength - 5).ToString() + "\n");
            Console.WriteLine("We just got another Loooser!");
            Thread.Sleep(1000);
            Process.Start("Snake.exe");
            Environment.Exit(-1); 
        }

        static void doInput(ConsoleKey inp)
        {
            switch (inp)
            {
                case ConsoleKey.UpArrow:
                    goUp();
                    break;
                case ConsoleKey.DownArrow:
                    goDown();
                    break;
                case ConsoleKey.LeftArrow:
                    goRight();
                    break;
                case ConsoleKey.RightArrow:
                    goLeft();
                    break;
            }
        }

        static void addFood()
        {
            Random r = new Random();
            Cell cell;
            while (true)
            {
                cell = grid[r.Next(1,grid.GetLength(0) - 1), r.Next(1,grid.GetLength(1) - 1)];
                if (cell.value == " ")
                    cell.value = "%";
                    break;
            }
        }

        static void eatFood()
        {
            snakeLength += 1;
            addFood();
        }

        static void goUp()
        {
            if (direction != 2) direction = 0;
        }

        static void goRight()
        {
            if (direction != 3) direction = 1;
        }

        static void goDown()
        {
            if (direction != 0) direction = 2;
        }

        static void goLeft()
        {
            if (direction != 1) direction = 3;
        }

        static void Move()
        {
            if (direction == 0)
            {
                if (grid[currentCell.y - 1, currentCell.x].value == "*")
                {
                    Lose();
                    return;
                }
                visitCell(grid[currentCell.y - 1, currentCell.x]);
            }
            else if (direction == 1)
            {
                if (grid[currentCell.y, currentCell.x - 1].value == "*")
                {
                    Lose();
                    return;
                }
                visitCell(grid[currentCell.y, currentCell.x - 1]);
            }
            else if (direction == 2)
            {
                if (grid[currentCell.y + 1, currentCell.x].value == "*")
                {
                    Lose();
                    return;
                }
                visitCell(grid[currentCell.y + 1, currentCell.x]);
            }
            else if (direction == 3)
            {
                if (grid[currentCell.y, currentCell.x + 1].value == "*")
                {
                    Lose();
                    return;
                }
                visitCell(grid[currentCell.y, currentCell.x + 1]);
            }

            Thread.Sleep(speed * 100);
        }

        static void visitCell(Cell cell)
        {
            currentCell.value = "*";
            currentCell.visited = true;
            currentCell.decay = snakeLength;
            checkCell(cell);
            currentCell = cell;
            updatePos();
        }

        static void updatePos()
        {
            currentCell.value = "@";
            currentCell.visited = false;
        }

        static void populateGrid()
        {
            for (int col = 0; col < gridH; col++)
            {
                for (int row = 0; row < gridW; row++)
                {
                    Cell cell = new Cell();
                    cell.x = row;
                    cell.y = col;
                    cell.visited = false;
                    if (row == 0 || row > gridW - 2 || col == 0 || col > gridH - 2)
                        cell.value = "*";
                    else
                        cell.Clear();
                    grid[col, row] = cell;
                }
            }
        }

        static void printGrid()
        {
            string toPrint = "";
            for (int col = 0; col < gridH; col++)
            {
                for (int row = 0; row < gridW; row++)
                {
                    grid[col, row].decaySnake();
                    toPrint += grid[col, row].value;

                }
                toPrint += "\n";
            }
            Console.WriteLine(toPrint);
            Console.WriteLine(bestPlayer);
        }
    }
}