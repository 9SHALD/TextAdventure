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

        public bool Add(Item item) {
            Items.Add(item);
            return true;
        }

        public void Remove(Item item) {
            Items.Remove(item);
        }

        public Item GetItem(int index) {
            return Items[index];
        }

        public Item transferItem(Inventory other, string key) {

            if (other == null) {
                Console.WriteLine("What Item?");
                return null;
            }

            for (int i = Items.Count - 1; i >= 0; i--) {
                if (Items[i].getName == key) {
                    if (other.Add(Items[i])) {
                        Item item = Items[i];
                        Items.Remove(Items[i]);
                        return item;
                    }
                }

            }
            return null;
        }

        public Item transferItem(Inventory other, int i) {
            if (other.Add(Items[i])) {
                Item item = Items[i];
                Items.Remove(Items[i]);
                return item;
            }
            return null;
        }
    }
}