using System;
using System.Collections.Generic;

namespace LeftCenterRight
{
    class CLI
    {
        public List<Player> RetrievePlayerData()
        {
            List<Player> playerList = new List<Player>();
            do
            {
                Console.Write("Name of Player: ");
                string playerName = Console.ReadLine();
                Player newPlayer = new Player(playerName);
                playerList.Add(newPlayer);
            } while (playerList.Count < 3 || DecisionMorePlayers());
            return playerList;
        }
        public bool DecisionMorePlayers()
        {
            while (true)
            {
                Console.Write("Do you want to add another player 1 = yes / 2 = no: ");
                switch (Console.ReadLine().ToLower())
                {
                    case "1":
                        return true;
                    case "2":
                        return false;
                    default:
                        Console.WriteLine("Please type 1 for yes and 2 for no");
                        break;
                }
            }
        }
        public void PrintStatus(List<Player> players)
        {
            Console.WriteLine("Current Game Status:");
            foreach (Player player in players)
            {
                Console.WriteLine(player.PrintNameAndChips());
            }
            Console.WriteLine();
        }
        public void PrintWinner(List<Player> players)
        {
            Player winner = null;
            foreach (Player player in players)
            {
                if (!player.HasChipsLeft)
                {
                    winner = player;
                    break;
                }
            }
            if (winner != null)
            {
                Console.WriteLine($"Congratulations, {winner.Name} is the winner!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("How did we get here?"); //However this should happen
                Console.ReadKey();
            }
        }
    }
}
