using System;
using System.Threading;

namespace LeftCenterRight
{
    class Die
    {
        private const int MAX_NUMBER = 7; //+1 beacuse random generation is always < MAX_NUMBER
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
            Thread.Sleep(1); /*To fix a bug because numbers weren't random because of
            standard seeding. Example output of the random was: 6,6,6; 4,4,4; 1,1,1;*/
            LastValue = _random.Next(1, MAX_NUMBER);
        }
    }
}
