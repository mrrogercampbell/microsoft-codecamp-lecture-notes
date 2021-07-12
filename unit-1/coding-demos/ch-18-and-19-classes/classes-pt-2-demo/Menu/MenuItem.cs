using System;
using System.Collections.Generic;
namespace Menu
{
    public class MenuItem
    {
        public List<string> ingredients = new List<string>();

        public string Name { get; set; }
        public double Price { get; set; }
        public double Calories { get; set; }
        public string Description { get; set; }

        public MenuItem(string name, double price, double calories)
        {
            this.Name = name;
            this.Price = price;
            this.Calories = calories;
        }

        public void PrintDetails()
        {
            Console.WriteLine($" {this.Name}\n ${this.Price} | {this.Calories} Cal");
            Console.WriteLine("-----------------------");
        }

        public void AddIngredient(string ingredient)
        {
            ingredients.Add(ingredient);
        }
    }
}
