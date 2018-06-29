using System;
using System.Collections.Generic;
using System.Text;

namespace ZuulCS
{
    class Item
    {
        protected string name;
        protected string description;
        private int weight;

        public Item(string name, int weight, string description) {
            this.name = name;
            this.weight = weight;
            this.description = description;
        }

        public string getName {
            get { return name; }
        }

        public string getDescription {
            get { return description; }
        }

        public int getWeight {
            get { return weight; }
        }

        public int setWeight {
            set { weight = value; }
        }
    }
}
