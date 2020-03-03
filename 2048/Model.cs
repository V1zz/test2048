
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

        public Model()
        {
            
        }

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

        //Method for generating a random number
        private void AddRandomNumber()
        {
            if(IsGameOver()) return;

            //random generator
            int tmp = _rand.NextDouble() > 0.8 ? 4 : 2;
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

        public void Left()
        {

        }

        public void Right()
        {

        }

        public void Up()
        {

        }

        public void Down()
        {

        }

        #endregion
    }
}
