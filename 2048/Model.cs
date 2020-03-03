
//todo: Create helper class to render redundant functionality

using System;

namespace _2048
{
    public class Model
    {
        //Map instance
        private Map _map;
        //Randomizer
        private static readonly Random _rand = new Random();
        //Game state variable 
        private bool _isGameOver;
        //Block randomization if numbers did`n move
        private bool _moved;

        //Map size property
        public int size => _map.size;

        public Model(int size)
        {
            _map = new Map(size);
            _isGameOver = false;
        }

        //Game start initialization method
        public void Start()
        {
            _isGameOver = false;
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                {
                    _map.Set(x, y, 0);
                }

            AddRandomNumber();
            AddRandomNumber();
        }

        //Game state change method
        public bool IsGameOver()
        {
            //true
            if(_isGameOver) return _isGameOver;
            //false
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    if (_map.Get(x, y) == 0 ||
                        _map.Get(x, y) == _map.Get(x + 1, y) ||
                        _map.Get(x, y) == _map.Get(x, y + 1))
                        return false;
            _isGameOver = true;
            return _isGameOver;
        }

        //todo: 42:40 - need optimization
        //Method for for adding a random number to an empty field
        private void AddRandomNumber()
        {
            if (IsGameOver()) return;
            for (int i = 0; i < 100; i++)
            {
                int x = _rand.Next(0, _map.size);
                int y = _rand.Next(0, _map.size);
                if (_map.Get(x, y) != 0) continue;
                _map.Set(x, y, _rand.NextDouble() > 0.8 ? 4 : 2);
                return;
            }
            //random generator
            //int tmp = _rand.NextDouble() > 0.8 ? 4 : 2;
        }

        //Getting value to display
        public int GetMap(int x, int y)
        {
            return _map.Get(x, y);
        }

#region Control reading methods

        //Number offset before summing
        //  x,  y  - from position
        //  sx, sy - to position
        private void Offset(int x, int y, int sx, int sy)
        {
            if (_map.Get(x, y) == 0) return;
            while (_map.Get(x + sx, y + sy) == 0)
            {
                _map.Set(x + sx, y + sy, _map.Get(x, y));
                _map.Set(x, y, 0);
                x += sx;
                y += sy;
                _moved = true;
            }
        }

        //Summation of identical adjacent numbers
        //  x,  y  - from position
        //  sx, sy - to position
        private void Summ(int x, int y, int sx, int sy)
        {
            if (_map.Get(x, y) == 0 || _map.Get(x + sx, y + sy) != _map.Get(x, y))
                return;

            _map.Set(x + sx, y + sy, _map.Get(x, y) * 2);

            while (_map.Get(x - sx, y - sy) > 0)
            {
                _map.Set(x, y, _map.Get(x - sx, y - sy));
                x -= sx;
                y -= sy;
            }

            _map.Set(x, y, 0);
            _moved = true;
        }

        //(x, y, -1, 0)
        public void Left()
        {
            _moved = false;
            for (int y = 0; y < _map.size; y++)
            {
                for (int x = 1; x < _map.size; x++)
                    Offset(x, y, -1, 0);
                for (int x = 1; x < _map.size; x++)
                    Summ(x, y, -1, 0);
            }
            if(_moved) AddRandomNumber();
        }

        //(x, y, +1, 0)
        public void Right()
        {
            _moved = false;
            for (int y = 0; y < _map.size; y++)
            {
                for (int x = _map.size - 2; x >= 0; x--)
                    Offset(x, y, +1, 0);
                for (int x = _map.size - 2; x >= 0; x--)
                    Summ(x, y, +1, 0);
            }
            if(_moved) AddRandomNumber();
        }

        //(x, y, 0, -1)
        public void Up()
        {
            _moved = false;
            for (int x = 0; x < _map.size; x++)
            {
                for (int y = 1; y < _map.size; y++)
                    Offset(x, y, 0, -1);
                for (int y = 1; y < _map.size; y++)
                    Summ(x, y, 0, -1);
            }
            if(_moved) AddRandomNumber();
        }

        //(x, y, 0, +1)
        public void Down()
        {
            _moved = false;
            for (int x = 0; x < _map.size; x++)
            {
                for (int y = _map.size - 2; y >= 0; y--)
                    Offset(x, y, 0, +1);
                for (int y = _map.size - 2; y >= 0; y--)
                    Summ(x, y, 0, +1);
            }
            if(_moved) AddRandomNumber();
        }
#endregion
    }
}
