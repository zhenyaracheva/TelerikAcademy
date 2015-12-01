namespace Labyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static List<char[,]> labirynth;
        private static List<bool[,]> visited;
        private static int minCount = int.MaxValue;

        public static void Main()
        {
            var startPosition = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                                   .Select(int.Parse)
                                                   .ToArray();

            var position = new Position
            {
                Row = startPosition[1],
                Col = startPosition[2],
                Floor = startPosition[0],
                Path = 0
            };

            var matrixSize = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                                   .Select(int.Parse)
                                                   .ToArray();
            var floors = matrixSize[0];
            labirynth = new List<char[,]>(floors);
            visited = new List<bool[,]>(floors);

            for (int m = 0; m < matrixSize[0]; m++)
            {
                var matrix = new char[matrixSize[1], matrixSize[2]];
                visited.Add(new bool[matrixSize[1], matrixSize[2]]);

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    var line = Console.ReadLine();
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = line[col];
                    }
                }

                labirynth.Add(matrix);

            }

            Bfs(position);
            Console.WriteLine(minCount);
        }

        private static void Bfs(Position position)
        {
            var queue = new Queue<Position>();
            queue.Enqueue(position);

            while (queue.Count > 0)
            {
                var currentPosition = queue.Dequeue();

                if (currentPosition.Floor < 0 || currentPosition.Floor >= labirynth.Count)
                {
                    if (currentPosition.Path < minCount)
                    {
                        minCount = currentPosition.Path;
                    }

                    continue;
                }

                var used = visited[currentPosition.Floor];
                var isUsedStep = used[currentPosition.Row, currentPosition.Col];

                if (isUsedStep)
                {
                    continue;
                }

                var floor = labirynth[currentPosition.Floor];
                var step = floor[currentPosition.Row, currentPosition.Col];

                if (step == '#')
                {
                    continue;
                }

                used[currentPosition.Row, currentPosition.Col] = true;

                if (step == 'U')
                {
                    queue.Enqueue(new Position
                    {
                        Row = currentPosition.Row,
                        Col = currentPosition.Col,
                        Floor = currentPosition.Floor + 1,
                        Path = currentPosition.Path + 1
                    });
                }
                else if (step == 'D')
                {
                    queue.Enqueue(new Position
                    {
                        Row = currentPosition.Row,
                        Col = currentPosition.Col,
                        Floor = currentPosition.Floor - 1,
                        Path = currentPosition.Path + 1
                    });
                }
                else
                {
                    if (currentPosition.Row + 1 < floor.GetLength(0) && !used[currentPosition.Row + 1, currentPosition.Col] &&
                        labirynth[currentPosition.Floor][currentPosition.Row + 1, currentPosition.Col] != '#')
                    {
                        queue.Enqueue(new Position
                        {
                            Row = currentPosition.Row + 1,
                            Col = currentPosition.Col,
                            Floor = currentPosition.Floor,
                            Path = currentPosition.Path + 1
                        });
                    }

                    if (currentPosition.Row - 1 >= 0 && !used[currentPosition.Row - 1, currentPosition.Col] &&
                        labirynth[currentPosition.Floor][currentPosition.Row - 1, currentPosition.Col] != '#')
                    {
                        queue.Enqueue(new Position
                        {
                            Row = currentPosition.Row - 1,
                            Col = currentPosition.Col,
                            Floor = currentPosition.Floor,
                            Path = currentPosition.Path + 1
                        });
                    }

                    if (currentPosition.Col + 1 < floor.GetLength(1) && !used[currentPosition.Row, currentPosition.Col + 1] &&
                        labirynth[currentPosition.Floor][currentPosition.Row, currentPosition.Col + 1] != '#')
                    {
                        queue.Enqueue(new Position
                        {
                            Row = currentPosition.Row,
                            Col = currentPosition.Col + 1,
                            Floor = currentPosition.Floor,
                            Path = currentPosition.Path + 1
                        });
                    }

                    if (currentPosition.Col - 1 >= 0 && !used[currentPosition.Row, currentPosition.Col - 1] &&
                        labirynth[currentPosition.Floor][currentPosition.Row, currentPosition.Col - 1] != '#')
                    {
                        queue.Enqueue(new Position
                        {
                            Row = currentPosition.Row,
                            Col = currentPosition.Col - 1,
                            Floor = currentPosition.Floor,
                            Path = currentPosition.Path + 1
                        });
                    }
                }
            }
        }

        private static void WalkMatrixRecursive(Position position, int steps)
        {
            if (position.Floor < 0 || position.Floor >= labirynth.Count)
            {
                if (steps < minCount)
                {
                    minCount = steps;
                }

                return;
            }

            if (position.Row < 0 || position.Row >= labirynth[0].GetLength(0))
            {
                return;
            }

            if (position.Col < 0 || position.Col >= labirynth[0].GetLength(1))
            {
                return;
            }


            var floor = labirynth[position.Floor];
            var step = floor[position.Row, position.Col];

            var used = visited[position.Floor];
            var isUsedStep = used[position.Row, position.Col];

            if (step == '#')
            {
                return;
            }

            if (isUsedStep)
            {
                return;
            }

            if (step == 'U')
            {
                used[position.Row, position.Col] = true;
                steps++;
                position.Floor++;
                WalkMatrixRecursive(position, steps);
                position.Floor--;
                steps--;
                used[position.Row, position.Col] = false;
            }
            else if (step == 'D')
            {
                used[position.Row, position.Col] = true;
                steps++;
                position.Floor--;
                WalkMatrixRecursive(position, steps);
                position.Floor++;
                steps--;
                used[position.Row, position.Col] = false;
            }
            else
            {
                if (position.Row + 1 < floor.GetLength(0) && !used[position.Row + 1, position.Col] && step != '#')
                {
                    used[position.Row, position.Col] = true;
                    steps++;
                    position.Row++;
                    WalkMatrixRecursive(position, steps);
                    position.Row--;
                    steps--;
                    used[position.Row, position.Col] = false;
                }

                if (position.Row - 1 >= 0 && !used[position.Row - 1, position.Col] && step != '#')
                {
                    used[position.Row, position.Col] = true;
                    steps++;
                    position.Row--;
                    WalkMatrixRecursive(position, steps);
                    position.Row++;
                    steps--;
                    used[position.Row, position.Col] = false;
                }

                if (position.Col + 1 < floor.GetLength(1) && !used[position.Row, position.Col + 1] && step != '#')
                {
                    used[position.Row, position.Col] = true;
                    steps++;
                    position.Col++;
                    WalkMatrixRecursive(position, steps);
                    position.Col--;
                    steps--;
                    used[position.Row, position.Col] = false;
                }

                if (position.Col - 1 >= 0 && !used[position.Row, position.Col - 1] && step != '#')
                {
                    used[position.Row, position.Col] = true;
                    steps++;
                    position.Col--;
                    WalkMatrixRecursive(position, steps);
                    position.Col++;
                    steps--;
                    used[position.Row, position.Col] = false;
                }
            }
        }
    }

    public class Position
    {
        public int Row { get; set; }

        public int Col { get; set; }

        public int Floor { get; set; }

        public int Path { get; set; }
    }
}
