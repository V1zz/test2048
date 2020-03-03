using System;

namespace _2048
{
    //Game matrix instance 
    class Map
    {
        int size;
        int[,] map;

        public Map(int size)
        {
            this.size = size;
            map = new int[size, size];
        }

        //Getting the value in array at the coordinates "x" and "y"
        public int Get(int x, int y)
        {
            if (OnMap(x, y))
                return map[x, y];
            return -1;
        }
        //Setting the value of the variable "number" in array at the coordinates "x" and "y" 
        public void Set(int x, int y, int number)
        {
            if (OnMap(x, y))
                map[x, y] = number;
        }

        //Checking empty value in array 
        private bool OnMap(int x, int y)
        {
            return  x >= 0 && x < size &&
                    y >= 0 && y < size;
        }
    }
}