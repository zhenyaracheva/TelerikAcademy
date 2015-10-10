namespace Minesweeper
{
    using System;
    using System.Collections.Generic;

    public class MinesweeperGameLogic
    {
        private const int MaxCountEmptyCells = 35;
      
        public static void Start()
        {
            string command = string.Empty;
            char[,] gameField = CreateGameField();
            char[,] bombsPositions = CreateBombPositions();
            int points = 0;
            bool isGameOver = false;
            List<PlayerScore> bestScores = new List<PlayerScore>(6);
            int row = 0;
            int col = 0;
            bool printStartText = true;
            bool isPlayerWins = false;

            do
            {
                if (printStartText)
                {
                    Console.WriteLine("Let's play “Minesweeper”");
                    Console.WriteLine("Commands:");
                    Console.WriteLine("'top'--> shows best scores");
                    Console.WriteLine("'restart' starts new game");
                    Console.WriteLine("'exit' ends game");
                    PrintGameField(gameField);
                    printStartText = false;
                }

                Console.Write("Please enter row and column: ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                    int.TryParse(command[2].ToString(), out col) &&
                        row <= gameField.GetLength(0) && col <= gameField.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        PrintBestScores(bestScores);
                        break;
                    case "restart":
                        gameField = CreateGameField();
                        bombsPositions = CreateBombPositions();
                        PrintGameField(gameField);
                        isGameOver = false;
                        printStartText = false;
                        break;
                    case "exit":
                        Console.WriteLine("Bye!");
                        break;
                    case "turn":
                        if (bombsPositions[row, col] != '*')
                        {
                            if (bombsPositions[row, col] == '-')
                            {
                                OpenGameFieldPosition(gameField, bombsPositions, row, col);
                                points++;
                            }

                            if (MinesweeperGameLogic.MaxCountEmptyCells == points)
                            {
                                isPlayerWins = true;
                            }
                            else
                            {
                                PrintGameField(gameField);
                            }
                        }
                        else
                        {
                            isGameOver = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nInvalid position!\n");
                        break;
                }

                if (isGameOver)
                {
                    PrintGameField(bombsPositions);
                    Console.Write("\nHrrrrrr! You lose {0} points. " + "Please enter your name: ", points);
                    string playerName = Console.ReadLine();
                    PlayerScore playerScore = new PlayerScore(playerName, points);
                    if (bestScores.Count < 5)
                    {
                        bestScores.Add(playerScore);
                    }
                    else
                    {
                        for (int i = 0; i < bestScores.Count; i++)
                        {
                            if (bestScores[i].Points < playerScore.Points)
                            {
                                bestScores.Insert(i, playerScore);
                                bestScores.RemoveAt(bestScores.Count - 1);
                                break;
                            }
                        }
                    }

                    bestScores.Sort((PlayerScore r1, PlayerScore r2) => r2.Player.CompareTo(r1.Player));
                    bestScores.Sort((PlayerScore r1, PlayerScore r2) => r2.Points.CompareTo(r1.Points));
                    PrintBestScores(bestScores);
                    gameField = CreateGameField();
                    bombsPositions = CreateBombPositions();
                    points = 0;
                    isGameOver = false;
                    printStartText = true;
                }

                if (isPlayerWins)
                {
                    Console.WriteLine("\nCongrats! You Win!");
                    PrintGameField(bombsPositions);
                    Console.WriteLine("Please enter you name: ");
                    string playerName = Console.ReadLine();
                    PlayerScore playerResult = new PlayerScore(playerName, points);
                    bestScores.Add(playerResult);
                    PrintBestScores(bestScores);
                    gameField = CreateGameField();
                    bombsPositions = CreateBombPositions();
                    points = 0;
                    isPlayerWins = false;
                    printStartText = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria");
            Console.WriteLine("Have a nice day!");
            Console.Read();
        }

        private static void PrintBestScores(List<PlayerScore> scoreList)
        {
            Console.WriteLine("\nPoints:");
            if (scoreList.Count > 0)
            {
                for (int i = 0; i < scoreList.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} boxes", i + 1, scoreList[i].Player, scoreList[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty list!\n");
            }
        }

        private static void OpenGameFieldPosition(char[,] gameField, char[,] bombs, int row, int col)
        {
            char bombsCount = GetBombsCountAsChar(bombs, row, col);
            bombs[row, col] = bombsCount;
            gameField[row, col] = bombsCount;
        }

        private static void PrintGameField(char[,] gameField)
        {
            int rowsCount = gameField.GetLength(0);
            int colsCount = gameField.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int row = 0; row < rowsCount; row++)
            {
                Console.Write("{0} | ", row);
                for (int col = 0; col < colsCount; col++)
                {
                    Console.Write(string.Format("{0} ", gameField[row, col]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateGameField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] CreateBombPositions()
        {
            int rows = 5;
            int cols = 10;
            char[,] gameField = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    gameField[row, col] = '-';
                }
            }

            List<int> bombsPositions = new List<int>();
            while (bombsPositions.Count < 15)
            {
                Random random = new Random();
                int position = random.Next(50);
                if (!bombsPositions.Contains(position))
                {
                    bombsPositions.Add(position);
                }
            }

            foreach (int position in bombsPositions)
            {
                int bombColPosition = position / cols;
                int bombRowPosition = position % cols;
                if (bombRowPosition == 0 && position != 0)
                {
                    bombColPosition--;
                    bombRowPosition = cols;
                }
                else
                {
                    bombRowPosition++;
                }

                gameField[bombColPosition, bombRowPosition - 1] = '*';
            }

            return gameField;
        }

        private static char GetBombsCountAsChar(char[,] gameField, int row, int col)
        {
            int count = 0;
            int rows = gameField.GetLength(0);
            int cols = gameField.GetLength(1);

            if (row - 1 >= 0)
            {
                if (gameField[row - 1, col] == '*')
                {
                    count++;
                }
            }

            if (row + 1 < rows)
            {
                if (gameField[row + 1, col] == '*')
                {
                    count++;
                }
            }

            if (col - 1 >= 0)
            {
                if (gameField[row, col - 1] == '*')
                {
                    count++;
                }
            }

            if (col + 1 < cols)
            {
                if (gameField[row, col + 1] == '*')
                {
                    count++;
                }
            }

            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (gameField[row - 1, col - 1] == '*')
                {
                    count++;
                }
            }

            if ((row - 1 >= 0) && (col + 1 < cols))
            {
                if (gameField[row - 1, col + 1] == '*')
                {
                    count++;
                }
            }

            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                if (gameField[row + 1, col - 1] == '*')
                {
                    count++;
                }
            }

            if ((row + 1 < rows) && (col + 1 < cols))
            {
                if (gameField[row + 1, col + 1] == '*')
                {
                    count++;
                }
            }

            return char.Parse(count.ToString());
        }
    }
}