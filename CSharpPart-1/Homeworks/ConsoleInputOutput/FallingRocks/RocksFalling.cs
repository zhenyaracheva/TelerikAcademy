//Problem 12.** Falling Rocks

//Implement the "Falling Rocks" game in the text console.
//A small dwarf stays at the bottom of the screen and can move left and right (by the arrows keys).
//A number of rocks of different sizes and forms constantly fall down and you need to avoid a crash.
//Rocks are the symbols ^, @, *, &, +, %, $, #, !, ., ;, - distributed with appropriate density. The dwarf is (O).
//Ensure a constant game speed by Thread.Sleep(150).
//Implement collision detection and scoring system.


using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

public class Dwarf
{
    public int Row { get; set; }

    public int Col { get; set; }

    public char Face { get; set; }

    public ConsoleColor Color { get; set; }

    public Dwarf(int row, int col)
    {
        this.Row = row;
        this.Col = col;
        this.Face = 'O';
        this.Color = ConsoleColor.Green;
    }
}

public class Rock
{
    public int Row { get; set; }

    public int Col { get; set; }

    public char Symbol { get; set; }

    public ConsoleColor Color { get; set; }

    public Rock(int row, int col, char symbol, ConsoleColor color)
    {
        this.Row = row;
        this.Col = col;
        this.Symbol = symbol;
        this.Color = color;
    }
}

class RocksFalling
{
    const char Dwarf = 'O';
    const int WindowWidth = 30;
    const int WindowHeight = 20;
    const int GameFieldWidth = WindowWidth / 2;
    const int InfoPanelWidth = WindowWidth - GameFieldWidth - 3;
    const char BorderCharacter = (char)219;
    static int score = 0;
    static int lives = 9;


    static Random rand = new Random();
    static List<char> symbols = new List<char> { '^', '@', '+', '*', '&', '%', '$', '#', '!', '.', ';', '-' };
    static List<ConsoleColor> colors = new List<ConsoleColor> { ConsoleColor.Yellow, ConsoleColor.Magenta, ConsoleColor.DarkRed,
        ConsoleColor.Blue, ConsoleColor.DarkGray, ConsoleColor.DarkMagenta };
    static List<Rock> rocks = new List<Rock>();

    static void Main()
    {
        Console.OutputEncoding = Encoding.GetEncoding(1252);
        Console.Title = "Falling Rocks";
        Console.CursorVisible = false;
        Console.BufferHeight = Console.WindowHeight = 20;
        Console.BufferWidth = Console.WindowWidth = 30;
        Dwarf dwarf = new Dwarf(WindowHeight - 3, GameFieldWidth / 2);

        while (true)
        {


            while (Console.KeyAvailable)
            {
                var pressedKey = Console.ReadKey(true);

                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    if (dwarf.Col > 1)
                    {
                        dwarf.Col--;
                    }
                }
                else if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    if (dwarf.Col < GameFieldWidth + 1)
                    {
                        dwarf.Col++;
                    }
                }
            }

            int rockCol = rand.Next(1, GameFieldWidth + 2);
            int rockSymbol = rand.Next(0, symbols.Count);
            int rockColor = rand.Next(0, colors.Count);

            Rock rock = new Rock(0, rockCol, symbols[rockSymbol], colors[rockColor]);
            rocks.Add(rock);

            List<Rock> newRocks = new List<Rock>();

            for (int i = 0; i < rocks.Count; i++)
            {
                Rock oldRock = rocks[i];
                Rock newRock = new Rock(oldRock.Row + 1, oldRock.Col, oldRock.Symbol, oldRock.Color);

                if (newRock.Row < WindowHeight - 2)
                {
                    newRocks.Add(newRock);
                }

                if (newRock.Row == WindowHeight - 3)
                {
                    score++;
                }

                if (CheckForCollision(dwarf, newRock))
                {
                    lives--;
                    newRocks.Clear();
                    rocks.Clear();

                    if (lives < 0)
                    {
                        Console.Clear();
                        PrintStringOnPosition(WindowHeight / 2, (WindowWidth / 2) - "GAME OVER!".Length / 2, "GAME OVER!", ConsoleColor.Red);
                        PrintStringOnPosition(WindowHeight / 2 + 1, (WindowWidth / 2) - ("Score:" + score.ToString()).Length / 2, "Score: " + score.ToString(), ConsoleColor.Red);
                        return;
                    }

                }
            }

            rocks = newRocks;

            Console.Clear();
            PrintBorders();
            Print(dwarf.Row, dwarf.Col, dwarf.Face, dwarf.Color);

            foreach (Rock currentRock in rocks)
            {
                Print(currentRock.Row, currentRock.Col, currentRock.Symbol, currentRock.Color);
            }


            PrintStringOnPosition(1, GameFieldWidth + 2 + (InfoPanelWidth / 2 - "Score:".Length / 2), "Score:", ConsoleColor.Cyan);
            PrintStringOnPosition(2, GameFieldWidth + 2 + (InfoPanelWidth / 2 - score.ToString().Length / 2), score.ToString(), ConsoleColor.Yellow);
            PrintStringOnPosition(WindowHeight / 2 - 2, GameFieldWidth + 2 + (InfoPanelWidth / 2 - "Lives:".Length / 2), "Lives:", ConsoleColor.Cyan);
            PrintStringOnPosition(WindowHeight / 2 - 1, GameFieldWidth + 2 + (InfoPanelWidth / 2 - lives.ToString().Length / 2), lives.ToString(), ConsoleColor.Magenta);
            PrintStringOnPosition(WindowHeight / 2 + 3, GameFieldWidth + 2 + (InfoPanelWidth / 2 - "Controls:".Length / 2), "Controls:", ConsoleColor.Cyan);
            PrintStringOnPosition(WindowHeight - 4, GameFieldWidth + 2 + (InfoPanelWidth / 2 - "   <   >   ".Length / 2), "   <   >   ", ConsoleColor.Blue);

            Thread.Sleep(150);
        }
    }

    private static bool CheckForCollision(global::Dwarf dwarf, Rock newRock)
    {
        if (dwarf.Row == newRock.Row && newRock.Col == dwarf.Col)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    static void PrintBorders()
    {
        for (int col = 0; col < WindowWidth; col++)
        {
            Print(0, col, BorderCharacter, ConsoleColor.Yellow);
            Print(WindowHeight - 2, col, BorderCharacter, ConsoleColor.Yellow);
        }

        for (int row = 0; row < WindowHeight - 1; row++)
        {
            Print(row, 0, BorderCharacter, ConsoleColor.Yellow);
            Print(row, WindowWidth - 1, BorderCharacter, ConsoleColor.Yellow);
            Print(row, GameFieldWidth + 2, BorderCharacter, ConsoleColor.Yellow);
        }
    }

    static void PrintStringOnPosition(int row, int col, string str, ConsoleColor color = ConsoleColor.Gray)
    {
        Console.SetCursorPosition(col, row);
        Console.ForegroundColor = color;
        Console.Write(str);
    }

    private static void Print(int row, int col, char symbol, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.SetCursorPosition(col, row);
        Console.Write(symbol);
    }
}


