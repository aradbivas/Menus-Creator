using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus.Interface;

namespace Ex04.Menus.Test
{
    public class InterfaceMenusTest
    {
        public void InterFaceMenus()
        {
            MainMenu mainMenu = new MainMenu("InterFace MainMenus");
            MenuItem versionAndCapitalsMenuItem = mainMenu.AddItemMenu(1, "Version and Capitals", false);
            MenuItem version = mainMenu.CreateSubMenuItem(1, "Version", versionAndCapitalsMenuItem, true);
            MenuItem capitals = mainMenu.CreateSubMenuItem(2, "Capitals", versionAndCapitalsMenuItem, true);
            MenuItem dateTimeMenuItem = mainMenu.AddItemMenu(2, "Show Date/Time", false);
            MenuItem date = mainMenu.CreateSubMenuItem(1, "Show Date", dateTimeMenuItem, true);
            MenuItem time = mainMenu.CreateSubMenuItem(2, "Show Time", dateTimeMenuItem, true);
            CountCapitals countCapitals = new CountCapitals();
            ShowVersion showVersion = new ShowVersion();
            ShowDate showDate = new ShowDate();
            ShowTime showTime = new ShowTime();

            capitals.AttachObserver(countCapitals);
            version.AttachObserver(showVersion);
            date.AttachObserver(showDate);
            time.AttachObserver(showTime);

            mainMenu.Run();
        }

        public void CountCapitals()
        {
            Console.WriteLine("Please write any sentence: ");
            string answer = Console.ReadLine();

            while(answer == string.Empty)
            {
                Console.WriteLine("Please write any sentence: ");
                answer = Console.ReadLine();
            }

            string result = string.Concat(answer.Where(c => c >= 'A' && c <= 'Z'));
            int size = result.Count();

            Console.WriteLine("The number of Capitals Letter in this sentence is: {0}", size);
        }

        public void ShowVersion()
        {
            Console.WriteLine("Version: 22.1.4.8930");
        }

        public void ShowDate()
        {
            string date = DateTime.Now.ToString("dd / MM / yyyy");

            Console.WriteLine("The date now is: {0}", date);
        }

        public void ShowTime()
        {
            string time = DateTime.Now.ToString("HH:mm:ss");

            Console.WriteLine("The time now is: {0}", time);
        }
    }
}
