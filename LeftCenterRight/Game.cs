using System;
using System.Collections.Generic;
using System.Threading;

namespace LeftCenterRight
{
    class Game
    {
        Player _currentPlayer;
        List<Player> _playerList = new List<Player>();
        CLI _cli = new CLI();
        DiceCup _diceCup = new DiceCup();

        public Game() 
        {
            _playerList = _cli.RetrievePlayerData();
        }
        public void Play()
        {
            SetStartPlayer();
            Console.WriteLine($"Current Player: {_currentPlayer.Name}");
            while (MoreThanOnePlayerHasChips())
            {
                if (!_currentPlayer.HasChipsLeft)
                {
                    Console.WriteLine($"Current Player: {_currentPlayer.Name}");
                    ProcessDiceRoll(_currentPlayer.DiceRoll(_diceCup));
                    _cli.PrintStatus(_playerList);
                    _currentPlayer = PlayerToTheRight();
                }
                else
                {
                    Console.WriteLine
                    ($"{_currentPlayer.Name} skipped due to insufficient amount of chips.\n");
                    _currentPlayer = PlayerToTheRight();
                }
            }
            _cli.PrintWinner(_playerList);
        }
        public void ProcessDiceRoll(List<int> values)
        {
            Console.WriteLine(_currentPlayer.PrintDice(values));
            foreach (int value in values)
            {
                switch (value)
                {
                    case 4:
                        PassChipToTheLeft();
                        break;
                    case 5:  
                        PlaceChipInPot();
                        break;
                    case 6:  
                        PassChipToTheRight();
                        break;
                    default: 
                        break;
                }
            }
        }
        public void SetStartPlayer()
        {
            Random randomPlayer = new Random();
            int startingPlayer = randomPlayer.Next(0, _playerList.Count);
            _currentPlayer = _playerList[startingPlayer];
        }
        public Player PlayerToTheRight()
        {
            int currentPlayerIndex = _playerList.IndexOf(_currentPlayer);
            return _playerList[(currentPlayerIndex - 1 + _playerList.Count) % _playerList.Count]; 
            // Add the count to the subtracted to not get negaitve numbers
        }
        public Player PlayerToTheLeft()
        {
            int currentPlayerIndex = _playerList.IndexOf(_currentPlayer);
            return _playerList[(currentPlayerIndex + 1) % _playerList.Count]; 
            // Modulo, to make like a circle to not exceed the max.
        }
        public bool MoreThanOnePlayerHasChips()
        {
            int amountOfPlayersWithChips = 0;
            foreach (Player player in _playerList)
            {
                if (!player.HasChipsLeft)
                {
                    amountOfPlayersWithChips++;
                }
            }
            if (amountOfPlayersWithChips > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void PassChipToTheLeft()
        {
            _currentPlayer.PassOnChip();
            PlayerToTheLeft().RecieveChip();
        }
        public void PassChipToTheRight()
        {
            _currentPlayer.PassOnChip();
            PlayerToTheRight().RecieveChip();
        }   
        public void PlaceChipInPot()
        {
            _currentPlayer.PassOnChip(); //Chip just goes away.
        }
    }
}
