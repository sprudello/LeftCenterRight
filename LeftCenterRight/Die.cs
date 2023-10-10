using System;

namespace LeftCenterRight
{
    class Die
    {
        const int MAX_NUMBER = 6;
        Random random = new Random();
        int _lastValue;
        public int LastValue
        {
            get { return _lastValue; }
            private set { _lastValue = value; }
        }

        public void Roll()
        {
            LastValue = random.Next(1, MAX_NUMBER + 1);
        }
    }
}
