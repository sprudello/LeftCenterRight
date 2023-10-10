using System;

namespace LeftCenterRight
{
    class Die
    {
        private const int MAX_NUMBER = 6;
        private Random _random;
        private int _lastValue;
        public int LastValue
        {
            get { return _lastValue; }
            private set { _lastValue = value; }
        }

        public void Roll()
        {
            _random = new Random();
            LastValue = _random.Next(1, MAX_NUMBER + 1);
            Console.WriteLine(LastValue);
        }
    }
}
