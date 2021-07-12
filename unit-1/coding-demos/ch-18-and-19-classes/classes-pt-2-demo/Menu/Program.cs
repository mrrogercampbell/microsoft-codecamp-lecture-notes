using System;

namespace Menu
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu sandwhichMenu = new Menu("Sandwhiches");


            MenuItem item1 = new MenuItem("Bacon Turkey Bravo Sandwich", 4.99, 870);
            MenuItem item2 = new MenuItem("Smokehouse BBQ Chicken Sandwich", 8.49, 770);
            MenuItem item3 = new MenuItem("Chipotle Chicken Avocado Melt", 9.99, 930);
            MenuItem item4 = new MenuItem("Classic Grilled Cheese Sandwhich", 7.19, 860);

            //string name, double price, double calories, string description

            sandwhichMenu.AddMenuItem(item1);

            sandwhichMenu.AddMenuItem(item2);

            sandwhichMenu.AddMenuItem(item3);

            sandwhichMenu.AddMenuItem(item4);

            sandwhichMenu.PrintMenuItems();


        }
    }
}
