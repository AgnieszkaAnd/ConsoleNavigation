using System;
using System.Threading;

namespace ConsoleNavigation {
    public class Screen {
        public string logoPart1;
        public Menu ScreenMenu { get; set; }
        public string logoPart2;
        public bool isActive;


        public Screen(Menu menu)
        {
            isActive = true;
            ScreenMenu = menu;
        }

        public void Controller() {
            
            while (this.ScreenMenu.isDisplayed) {

                this.ScreenMenu.current = this.ScreenMenu.menuItems[this.ScreenMenu.currentItemIndex];
                
                // TODO: think about List<Menu> change to HashMap<Menu><bool>
                //       to store info about current menu item
                this.ScreenMenu.current.isChecked = true;
                this.ScreenMenu.PrintMenuList();
                this.ScreenMenu.current.isChecked = false;

                var pressedKey = Console.ReadKey().Key;

                if (pressedKey == ConsoleKey.Enter) {

                    // Parse current menu item content (string) to defined enum
                    Enum.TryParse(this.ScreenMenu.current.Content, out MainMenuOptions temp);
                    
                    switch ((int) temp) {
                        case 0: 
                            System.Console.WriteLine("option1 clicked");
                            Menu opt1nestedMenu = new Menu(new string[3] {"one", "two", "back"});
                            Screen option1Screen = new Screen(opt1nestedMenu);
                            Program.sampleApp.Screens.Add(option1Screen);
                            option1Screen.Controller();
                            // Thread.Sleep(1000);

                            break;
                        case 1: 
                            System.Console.WriteLine("option1 clicked");
                            Thread.Sleep(1000);
                            break;
                        case 2: 
                            this.ScreenMenu.isDisplayed = false;
                            break;
                    }
                }
                if (pressedKey == ConsoleKey.Escape) {
                    this.ScreenMenu.isDisplayed = false;
                    int previousScreenIndex = Program.sampleApp.Screens.Count - 2; 
                    Program.sampleApp.Screens[previousScreenIndex].Controller();
                }
                
                this.ScreenMenu.NavigateMenu(pressedKey);
            }
        }
    }
}