
//todo: Create helper class to render redundant functionality

using System;

namespace _2048
{
    public class Model
    {
        //Map instance
        Map map;
        //Randomizer
        private static readonly Random _rand = new Random();
        //Game state variable 
        bool isGameOver;

        //Map size property
        public int size => map.size;

        public Model(int size)
        {
            map = new Map(size);
            isGameOver = false;
        }

        //Game start initialization method
        public void Start()
        {
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                {
                    map.Set(x, y, 0);
                }

            AddRandomNumber();
            AddRandomNumber();
        }

        //todo: 42:40 - need optimization
        //Method for for adding a random number to an empty field
        private void AddRandomNumber()
        {
            if (IsGameOver()) return;
            for (int i = 0; i < 100; i++)
            {
                int x = _rand.Next(0, map.size);
                int y = _rand.Next(0, map.size);
                if (map.Get(x, y) != 0) continue;
                map.Set(x, y, _rand.NextDouble() > 0.8 ? 4 : 2);
                return;
            }
            //random generator
            //int tmp = _rand.NextDouble() > 0.8 ? 4 : 2;
        }

        //Game state change method
        public bool IsGameOver()
        {
            return isGameOver;
        }

        //Getting value to display
        public int GetMap(int x, int y)
        {
            return map.Get(x, y);
        }

        #region Control reading methods

        //Number offset before summing
        //  x,  y  - from position
        //  sx, sy - to position
        private void Offset(int x, int y, int sx, int sy)
        {
            if (map.Get(x, y) == 0) return;
            while (map.Get(x + sx, y + sy) == 0)
            {
                map.Set(x + sx, y + sy, map.Get(x, y));
                map.Set(x, y, 0);
                x += sx;
                y += sy;
            }
        }

        //Summation of identical adjacent numbers
        //  x,  y  - from position
        //  sx, sy - to position
        private void Summ(int x, int y, int sx, int sy)
        {
            if (map.Get(x, y) == 0 || map.Get(x + sx, y + sy) != map.Get(x, y))
                return;

            map.Set(x + sx, y + sy, map.Get(x, y) * 2);

            while (map.Get(x - sx, y - sy) > 0)
            {
                map.Set(x, y, map.Get(x - sx, y - sy));
                x -= sx;
                y -= sy;
            }

            map.Set(x, y, 0);
        }

        //(x, y, -1, 0)
        public void Left()
        {
            for (int y = 0; y < map.size; y++)
            {
                for (int x = 1; x < map.size; x++)
                    Offset(x, y, -1, 0);
                for (int x = 1; x < map.size; x++)
                    Summ(x, y, -1, 0);
            }

            AddRandomNumber();
            AddRandomNumber();
        }

        //(x, y, +1, 0)
        public void Right()
        {
            for (int y = 0; y < map.size; y++)
            {
                for (int x = map.size - 2; x >= 0; x--)
                    Offset(x, y, +1, 0);
                for (int x = map.size - 2; x >= 0; x--)
                    Summ(x, y, +1, 0);
            }
            AddRandomNumber();
            AddRandomNumber();
        }

        //(x, y, 0, -1)
        public void Up()
        {
            for (int x = 0; x < map.size; x++)
            {
                for (int y = 1; y < map.size; y++)
                    Offset(x, y, 0, -1);
                for (int y = 1; y < map.size; y++)
                    Summ(x, y, 0, -1);
            }
            AddRandomNumber();
            AddRandomNumber();
        }

        //(x, y, 0, +1)
        public void Down()
        {
            for (int x = 0; x < map.size; x++)
            {
                for (int y = map.size - 2; y >= 0; y--)
                    Offset(x, y, 0, +1);
                for (int y = map.size - 2; y >= 0; y--)
                    Summ(x, y, 0, +1);
            }
            AddRandomNumber();
            AddRandomNumber();
        }

        #endregion
    }
}
