namespace P10_TheHeiganDance
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var playerDamage = double.Parse(Console.ReadLine());

            var playerRow = 7;
            var playerCol = 7;
            var matrix = new int[playerRow, playerCol];

            var playerHitPoints = 18500;
            var heiganHitPoints = 3000000d;
            var eruptionDamage = 6000;
            var plagueCloudDamage = 3500;
            var isPlagueCloud = false;

            while (true)
            {
                heiganHitPoints -= playerDamage;

                if (isPlagueCloud == true)
                {
                    playerHitPoints -= plagueCloudDamage;
                    isPlagueCloud = false;
                }

                if (playerHitPoints <= 0 && heiganHitPoints <= 0)
                {
                    Console.WriteLine("Heigan: Defeated!");
                    Console.WriteLine("Player: Killed by Plague Cloud");
                    Console.WriteLine($"Final position: {playerRow}, {playerCol}");

                    Environment.Exit(0);
                }
                else if (playerHitPoints <= 0)
                {
                    Console.WriteLine($"Heigan: {heiganHitPoints:f2}");
                    Console.WriteLine("Player: Killed by Plague Cloud");
                    Console.WriteLine($"Final position: {playerRow}, {playerCol}");

                    Environment.Exit(0);
                }
                else if (heiganHitPoints <= 0)
                {
                    Console.WriteLine("Heigan: Defeated!");
                    Console.WriteLine($"Player: {playerHitPoints}");
                    Console.WriteLine($"Final position: {playerRow}, {playerCol}");

                    Environment.Exit(0);
                }

                var line = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var spell = line[0];
                var spellRow = int.Parse(line[1]);
                var spellCol = int.Parse(line[2]);

                if (spell == "Eruption")
                {
                    if (playerRow == spellRow && playerCol == spellCol)
                    {
                        playerHitPoints -= eruptionDamage;

                        if (playerHitPoints <= 0)
                        {
                            Console.WriteLine($"Heigan: {heiganHitPoints:f2}");
                            Console.WriteLine("Player: Killed by Eruption");
                            Console.WriteLine($"Final position: {playerRow}, {playerCol}");

                            Environment.Exit(0);
                        }
                    }
                    else if (InRange(spellRow, playerRow, spellCol, playerCol))
                    {
                        if (playerRow - 1 >= 0 && !InRange(spellRow, playerRow - 1, spellCol, playerCol))
                        {
                            playerRow -= 1;
                            continue;
                        }
                        else if (playerCol + 1 < 15 && !InRange(spellRow, playerRow, spellCol, playerCol + 1))
                        {
                            playerCol += 1;
                            continue;
                        }
                        else if (playerRow + 1 < 15 && !InRange(spellRow, playerRow + 1, spellCol, playerCol))
                        {
                            playerRow += 1;
                            continue;
                        }
                        else if (playerCol - 1 >= 0 && !InRange(spellRow, playerRow, spellCol, playerCol - 1))
                        {
                            playerCol -= 1;
                            continue;
                        }

                        playerHitPoints -= eruptionDamage;

                        //if (playerHitPoints <= 0)
                        //{
                        //    Console.WriteLine($"Heigan: {heiganHitPoints:f2}");
                        //    Console.WriteLine("Player: Killed by Eruption");
                        //    Console.WriteLine($"Final position: {playerRow}, {playerCol}");

                        //    Environment.Exit(0);
                        //}
                    }
                }
                else if (spell == "Cloud")
                {
                    if (playerRow == spellRow && playerCol == spellCol)
                    {
                        playerHitPoints -= plagueCloudDamage;

                        if (playerHitPoints <= 0)
                        {
                            Console.WriteLine($"Heigan: {heiganHitPoints:f2}");
                            Console.WriteLine("Player: Killed by Plague Cloud");
                            Console.WriteLine($"Final position: {playerRow}, {playerCol}");

                            Environment.Exit(0);
                        }

                        isPlagueCloud = true;
                    }
                    else if (InRange(spellRow, playerRow, spellCol, playerCol))
                    {
                        if (playerRow - 1 >= 0 && !InRange(spellRow, playerRow - 1, spellCol, playerCol))
                        {
                            playerRow -= 1;
                            continue;
                        }
                        else if (playerCol + 1 < 15 && !InRange(spellRow, playerRow, spellCol, playerCol + 1))
                        {
                            playerCol += 1;
                            continue;
                        }
                        else if (playerRow + 1 < 15 && !InRange(spellRow, playerRow + 1, spellCol, playerCol))
                        {
                            playerRow += 1;
                            continue;
                        }
                        else if (playerCol - 1 >= 0 && !InRange(spellRow, playerRow, spellCol, playerCol - 1))
                        {
                            playerCol -= 1;
                            continue;
                        }

                        playerHitPoints -= eruptionDamage;
                        isPlagueCloud = true;

                        //if (playerHitPoints <= 0)
                        //{
                        //    Console.WriteLine($"Heigan: {heiganHitPoints:f2}");
                        //    Console.WriteLine("Player: Killed by Plague Cloud");
                        //    Console.WriteLine($"Final position: {playerRow}, {playerCol}");

                        //    Environment.Exit(0);
                        //}
                    }
                }
            }
        }

        private static bool InRange(int spellRow, int playerRow, int spellCol, int playerCol)
        {
            return (spellRow - 1 == playerRow && spellCol == playerCol) ||
                   (spellRow + 1 == playerRow && spellCol == playerCol) ||
                   (spellRow - 1 == playerRow && spellCol - 1 == playerCol) ||
                   (spellRow + 1 == playerRow && spellCol - 1 == playerCol) ||
                   (spellRow == playerRow && spellCol - 1 == playerCol) ||
                   (spellRow == playerRow && spellCol + 1 == playerCol) ||
                   (spellRow - 1 == playerRow && spellCol + 1 == playerCol) ||
                   (spellRow + 1 == playerRow && spellCol + 1 == playerCol) ||
                   (playerRow == spellRow && playerCol == spellCol);
        }
    }
}
