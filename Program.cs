using System;

namespace ConsoleNavigation
{
    class Program
    {
        public static ScreenNavigator sampleApp = new ScreenNavigator();

        static void Main(string[] args)
        {

            Menu initialMenu = new Menu(new string[3] {"option1", "option2", "quit"} );
            Screen initialScreen = new Screen(initialMenu);
            sampleApp.Screens.Add(initialScreen);
            initialScreen.Controller();

        }
    }
}
