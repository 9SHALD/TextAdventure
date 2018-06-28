using System;
using System.Collections.Generic;
using System.Text;

namespace ZuulCS
{
    class Item
    {
        protected string name;
        protected string description;
        //private string name;
        private int weight;

        public Item(string name, int weight) {
            this.name = name;
            this.weight = weight;
        }

        public int getWeight {
            get { return weight; }
        }

        public int setWeight {
            set { weight = value; }
        }
    }
}
