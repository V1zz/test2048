using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    public class Model
    {
        private bool isGameOver;
        public int size { get; private set; }

        public Model(int size)
        {
            this.size = size;
        }

        public void Start()
        {

        }

        public bool IsGameOver()
        {
            return isGameOver;
        }

        public int GetMap(int i, int i1)
        {
            return -1;
        }

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
    }
}
