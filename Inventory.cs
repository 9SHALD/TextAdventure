using System;
using System.Collections.Generic;
using System.Text;

namespace ZuulCS
{
    class Inventory {
        public List<Item> Items;

        public Inventory() {
            Items = new List<Item>();
        }

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