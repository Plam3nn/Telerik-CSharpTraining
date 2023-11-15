using System;
using System.Collections.Generic;

namespace P01_ArmyLunch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sergeants = new Queue<string>();
            var corporals = new Queue<string>();
            var privates = new Queue<string>();

            var numberOfSoldiers = int.Parse(Console.ReadLine());
            var soldiersInput = Console.ReadLine().Split();

            for (int i = 0; i < numberOfSoldiers; i++)
            {
                var currentSoldier = soldiersInput[i];

                if (currentSoldier[0] == 'S')
                {
                    sergeants.Enqueue(currentSoldier);
                }
                else if (currentSoldier[0] == 'C')
                {
                    corporals.Enqueue(currentSoldier);
                }
                else if (currentSoldier[0] == 'P')
                {
                    privates.Enqueue(currentSoldier);
                }
            }

            var correctOrder = new List<string>();

            correctOrder.AddRange(sergeants);
            correctOrder.AddRange(corporals);
            correctOrder.AddRange(privates);

            Console.WriteLine(string.Join(" ", correctOrder));
        }
    }
}
