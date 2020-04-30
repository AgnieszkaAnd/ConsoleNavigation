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
                    Enum.TryParse(this.ScreenMenu.current.Content, out MenuOptions temp);
                    
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
                            System.Console.WriteLine("option2 clicked");
                            Thread.Sleep(1000);
                            break;
                        case 2: 
                            this.ScreenMenu.isDisplayed = false;
                            break;
                        case 3: //one
                            System.Console.WriteLine("one clicked");
                            // Menu opt2nestedMenu = new Menu(new string[2] {"oneSubmenu", "twoSubmenu"});
                            InputMenu opt2nestedMenu = new InputMenu(new string[2] {"oneSubmenu", "twoSubmenu"});
                            Screen option2Screen = new Screen(opt2nestedMenu);
                            Program.sampleApp.Screens.Add(option2Screen);
                            option2Screen.Controller();
                            break;
                        case 4: //two
                            System.Console.WriteLine("two clicked");
                            Thread.Sleep(1000);
                            break;
                        case 5: //back
                            this.ScreenMenu.isDisplayed = false;
                            break;
                        case 6: //back
                            // System.Console.WriteLine("oneSubmenu");
                            // Thread.Sleep(1000);
                            this.ScreenMenu.GetInputPerMenuItem();
                            break;
                        case 7: //back
                            this.ScreenMenu.GetInputPerMenuItem();
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