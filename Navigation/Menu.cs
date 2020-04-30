using System;
using System.Collections.Generic;

namespace ConsoleNavigation {
    public class Menu {
        public List<MenuItem> menuItems = new List<MenuItem>();
        public bool isDisplayed;
        public int currentItemIndex;
        public MenuItem current;

        public Menu(params string[] menuItemsToAdd)
        {
            isDisplayed = true;
            currentItemIndex = 0;

            foreach (string item in menuItemsToAdd) {
                menuItems.Add(new MenuItem(item));
            }
        }

        public void PrintMenuList() {
            Console.Clear();
            foreach (MenuItem item in this.menuItems) {
                Console.WriteLine(item);
            }
        }

        ///
        // NavigateMenu method moves up-down through menu list
        ///
        public void NavigateMenu(ConsoleKey input) {

            switch (input) {
                
                case ConsoleKey.UpArrow:
                    Console.BackgroundColor = ConsoleColor.Black;
                    if (this.currentItemIndex != 0 ) this.current = this.menuItems[this.currentItemIndex--];
                    else this.current = this.menuItems[0];
                    break;

                case ConsoleKey.DownArrow:
                    Console.BackgroundColor = ConsoleColor.Black;
                    if (this.currentItemIndex != this.menuItems.Count-1 ) this.current = this.menuItems[this.currentItemIndex++];
                    else this.current = this.menuItems[this.menuItems.Count-1];
                    break;
            } 
        }
    }
}