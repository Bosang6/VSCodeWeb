using System;
using System.Collections;

namespace jinjie
{
    class Bag
    {
        public int Money{get;private set;}
        ArrayList bag = new ArrayList();

        public Bag(int money)
        {
            Money = money;
        }

        public void BuyItem(Item item)
        {
            if(item.Price <= Money)
            {
                Money -= item.Price;
                bag.Add(item);
                Console.WriteLine("购买成功！");
            } 
            else Console.WriteLine("钱不够买！");
        }

        public void ViewItems()
        {   
            Console.Write("背包中有：");

            for(int i = 0; i < bag.Count; i++)
            {
                if(i != bag.Count - 1) Console.Write(((Item)bag[i]).Name + ",");
                else Console.Write(((Item)bag[i]).Name);
            }
            Console.WriteLine();
            
        }

        public void SellItem(int index)
        {
            if(index >= bag.Count) return;

            Money += (bag[index] as Item).Price;
            bag.RemoveAt(index);
            PrintMoney();
        }

        private void PrintMoney()
        {
            Console.WriteLine("余额：{0}", Money);
        }
    }

    class Item
    {
        public string Name{get; private set;}
        public int Price{get; private set;}

        public Item(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Bag bag = new Bag(100);

            Item[] items = {new Item("物品1", 10), new Item("物品2", 10), new Item("物品3", 30), new Item("物品4", 50), new Item("物品5", 30)};

            foreach(Item item in items)
            {
                bag.BuyItem(item);
            }

            bag.ViewItems();
            bag.SellItem(0);
            
        }
    }
}