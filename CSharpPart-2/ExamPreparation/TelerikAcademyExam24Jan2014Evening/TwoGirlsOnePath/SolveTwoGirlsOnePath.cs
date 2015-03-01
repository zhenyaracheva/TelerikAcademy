using System;
using System.Linq;
using System.Numerics;

class SolveTwoGirlsOnePath
{
    static void Main()
    {
        BigInteger[] path = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(BigInteger.Parse).ToArray();

        long positionMolly = 0;
        BigInteger nextStepMolly = 0;
        BigInteger flowersMolly = 0;

        long positionDolly = path.Length - 1;
        BigInteger nextStepDolly = path.Length - 1;
        BigInteger flowersDolly = 0;

        while (true)
        {
            if (path[positionMolly] == 0 || path[positionDolly] == 0)
            {
                flowersMolly += path[positionMolly];
                flowersDolly += path[positionDolly];
                break;
            }

            nextStepMolly += path[positionMolly];
            if (nextStepMolly >= path.Length)
            {
                nextStepMolly %= path.Length;
            }

            nextStepDolly -= path[positionDolly];
            if (nextStepDolly < 0)
            {
                nextStepDolly = path.Length + (nextStepDolly % path.Length);
            }

            if (positionMolly == positionDolly)
            {
                flowersMolly += (path[positionMolly] / 2);
                flowersDolly += (path[positionMolly] / 2);

                if (path[positionMolly] % 2 == 0)
                {
                    path[positionMolly] = 0;
                }
                else
                {
                    path[positionMolly] = 1;
                }
            }
            else
            {
                flowersMolly += path[positionMolly];
                path[positionMolly] = 0;
                flowersDolly += path[positionDolly];
                path[positionDolly] = 0;
            }

            positionMolly = (long)nextStepMolly;
            positionDolly = (long)nextStepDolly;
        }

        if (path[positionMolly] == 0 && path[positionDolly] == 0)
        {
            Console.WriteLine("Draw");
        }
        else
        {
            Console.WriteLine(path[positionMolly] == 0 ? "Dolly" : "Molly");
        }

        Console.WriteLine("{0} {1}", flowersMolly, flowersDolly);
    }
}

