using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus.Delegates;

namespace Ex04.Menus.Test
{
    public class DelegatesMenusTest
    {
        public void DelegateMenus()
        {
            MainMenu mainMenu = new Menus.Delegates.MainMenu("Delegates Menus");
            MenuItem versionAndCapitalsMenuItem = mainMenu.AddItemMenu(1, "Version and Capitals", false);
            MenuItem version = mainMenu.CreateSubMenuItem(1, "Version", versionAndCapitalsMenuItem, true);
            MenuItem capitals = mainMenu.CreateSubMenuItem(2, "Capitals", versionAndCapitalsMenuItem, true);
            MenuItem dateTimeMenuItem = mainMenu.AddItemMenu(2, "Show Date/Time", false);
            MenuItem date = mainMenu.CreateSubMenuItem(1, "Show Date", dateTimeMenuItem, true);
            MenuItem time = mainMenu.CreateSubMenuItem(2, "Show Time", dateTimeMenuItem, true);

            time.MenuSelected += showTime;
            date.MenuSelected += showDate;
            version.MenuSelected += showVersion;
            capitals.MenuSelected += countCapital;
            mainMenu.Run();
        }

        private void countCapital(MenuItem i_MenuItem)
        {
            Console.WriteLine("Please write any sentence: ");
            string answer = Console.ReadLine();

            if (answer == string.Empty)
            {
                Console.WriteLine("Please write any sentence: ");
                answer = Console.ReadLine();
            }

            string result = string.Concat(answer.Where(c => c >= 'A' && c <= 'Z'));
            int size = result.Count();

            Console.WriteLine("The number of Capitals Letter in this sentence is: {0}", size);
        }

        private void showVersion(MenuItem i_MenuItem)
        {
            Console.WriteLine("Version: 22.1.4.8930");
        }

        private void showDate(MenuItem i_MenuItem)
        {
            string date = DateTime.Now.ToString("dd / MM / yyyy");

            Console.WriteLine("The date now is: {0}", date);
        }

        private void showTime(MenuItem i_MenuItem)
        {
            string time = DateTime.Now.ToString("HH:mm:ss").ToString();

            Console.WriteLine("The time now is: {0}", time);
        }
    }
}
