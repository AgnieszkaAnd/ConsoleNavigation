using System;
using System.Collections.Generic;

namespace ConsoleNavigation {
    public class InputMenu : Menu {
        // public List<MenuItem> menuItems = new List<MenuItem>();
        // public bool isDisplayed;
        // public new int currentItemIndex;
        // public MenuItem current;
        public InputMenu(params string[] menuItemsToAdd) : base(menuItemsToAdd)
        {
            // isDisplayed = true;
            // currentItemIndex = 0;

            // foreach (string item in menuItemsToAdd) {
            //     menuItems.Add(new MenuItem(item));
            // }
        }

        public new void NavigateMenu(ConsoleKey input) {
            
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

                case ConsoleKey.Enter:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.BackgroundColor = ConsoleColor.Black;
                    
                    Console.SetCursorPosition(this.current.Content.Length + 2, Console.CursorTop - (this.menuItems.Count - this.currentItemIndex - 1));
                    Console.ReadLine();
                    
                    break;
            }
        }
           
    }
}