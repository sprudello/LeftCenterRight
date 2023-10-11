using System;
using System.Collections.Generic;

namespace LeftCenterRight
{
    class DiceCup
    {
        const int NUM_DICE = 3;
        List<Die> _dice = new List<Die>();

        public DiceCup()
        {
            for (int i = 0; i < NUM_DICE; i++)
            {
                _dice.Add(new Die());
            }
        }
        public void Shake()
        {
            foreach (Die die in _dice)
            {
                die.Roll();
            }
        }
        public List<int> GetValues(int values)
        {
            List<int> numbers = new List<int>();
            Shake();
            for (int i = 0; i < values; i++)
            {
                try
                {
                    numbers.Add(_dice[i].LastValue);
                }
                catch
                { 
                    Die catchDie = new Die();
                    _dice.Add(catchDie);
                    _dice[i].Roll();
                }
            }
            return numbers;
        }
    }
}
