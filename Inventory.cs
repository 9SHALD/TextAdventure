using System;
using System.Collections.Generic;
using System.Text;

namespace ZuulCS
{
    class Inventory {
        private List<Item> Items = new List<Item>();

        public void Add(Item item) {
            Items.Add(item);
        }

        public void Remove(Item item) {
            Items.Remove(item);
        }

        public Item GetItem(int index) {
            return Items[index];
        }
    }
}
