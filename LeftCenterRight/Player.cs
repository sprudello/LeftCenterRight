using System.Collections.Generic;

namespace LeftCenterRight
{
    class Player
    {
        int _chips = 3;
        string _name;
        public string Name { get { return _name; } private set { _name = value; } }
        public bool HasChipsLeft { get { return _chips < 1; } }
        public int NumberOfDice { get { return _chips; } }

        public Player(string name)
        {
            _name = name;
        }
        public void RecieveChip()
        {
            _chips++;
            
        }
        public void PassOnChip()
        {
            _chips--;
        }
        public List<int> DiceRoll(DiceCup diceCup)
        {
            return diceCup.GetValues(NumberOfDice);
        }
        public string PrintNameAndChips()
        {
            return $"{_name} has {_chips} chips.";
        }
        public string PrintDice(List<Die> dice)
        {
            List<string> diceStrings = new List<string>();
            foreach (var die in dice)
            {
                diceStrings.Add(die.LastValue.ToString());
            }
            return $"{_name} rolled a {string.Join(", ", diceStrings)}";
        }
    }
}
