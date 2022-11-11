using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex02.ConsoleUtils;

namespace Ex04.Menus.Interface
{
        public class MainMenu : IMenuItemListener
        {
            private static int s_MenuCount = 0;
            private readonly Stack r_BackMenuItemIndex = new Stack();
            private readonly Stack r_LastTitle = new Stack();
            private Dictionary<int, MenuItem> m_MenuItems = new Dictionary<int, MenuItem>();
            private string m_FrameTitle;
            private bool m_KeepRunning = true;

            public MainMenu(string i_FrameTitle)
            {
                this.m_FrameTitle = i_FrameTitle;
            }

            private void buildExitPoint()
            {
                StringBuilder exitString = new StringBuilder();

                exitString.Append(s_MenuCount++);
                exitString.Append(" -> ");
                exitString.Append("Exit");
                MenuItem menuitem = new MenuItem(exitString.ToString(), false);

                menuitem.FinalMenuItem = true;
                menuitem.AttachObserver(this);
                m_MenuItems.Add(0, menuitem);
            }

            public string Title
            {
                get
                {
                    return m_FrameTitle;
                }

                set
                {
                    m_FrameTitle = value;
                }
            }

            private int getValueFromUser()
            {
                string askValueFromUser = string.Format(@"Enter your request: (1 to {0} or '0' to go back).", m_MenuItems.Count - 1);
                Console.WriteLine(askValueFromUser);
                string userChoice = Console.ReadLine();
                int userChoiceInInt;

                while (!int.TryParse(userChoice, out userChoiceInInt) || !checkIfInRange(userChoice, 0, m_MenuItems.Count - 1))
                {
                    Console.WriteLine("Please enter numbers in range.");
                    userChoice = Console.ReadLine();
                }

                return userChoiceInInt;
            }

            private bool checkIfInRange(string i_ValueToCheck, int i_MinRange, int i_MaxRange)
            {
                int numberToCheck = int.Parse(i_ValueToCheck);

                return numberToCheck >= i_MinRange && numberToCheck <= i_MaxRange;
            }

            private void buildBackPoint(MenuItem i_MemItem)
            {
                StringBuilder exitString = new StringBuilder();

                exitString.Append(i_MemItem.Counter++);
                exitString.Append(" -> ");
                exitString.Append("Back");
                MenuItem menuitem = new MenuItem(exitString.ToString(), false);

                menuitem.FinalMenuItem = true;
                menuitem.AttachObserver(this);
                i_MemItem.AddToDictionary(menuitem, 0);
            }

            public MenuItem CreateSubMenuItem(int i_IndexNumber, string i_Title, MenuItem i_MenuItem, bool i_IsLeaf)
            {
                if (i_MenuItem.Counter == 0)
                {
                    buildBackPoint(i_MenuItem);
                }

                StringBuilder titleWithIndex = new StringBuilder();

                titleWithIndex.Append(i_MenuItem.Counter++.ToString());
                titleWithIndex.Append(" -> ");
                titleWithIndex.Append(i_Title);

                MenuItem menuItem = new MenuItem(titleWithIndex.ToString(), i_IsLeaf);

                menuItem.ClearTitle = i_Title;
                if (!menuItem.IsLeaf)
                {
                   menuItem.AttachObserver(this);
                }

                i_MenuItem.AddToDictionary(menuItem, i_IndexNumber);

                return menuItem;
            }

            public void Run()
            {
                while (m_KeepRunning)
                {
                    draw();
                    int userChoice = getValueFromUser();
                    Screen.Clear();
                    m_MenuItems[userChoice].OnSelected();
                }
            }

            public MenuItem AddItemMenu(int i_IndexNumber, string i_Title, bool i_IsLeaf)
            {
                if (m_MenuItems.Count() == 0)
                {
                    buildExitPoint();
                }

                StringBuilder titleWithIndex = new StringBuilder();

                titleWithIndex.Append(s_MenuCount++.ToString());
                titleWithIndex.Append(" -> ");
                titleWithIndex.Append(i_Title);
                MenuItem menuItem = new MenuItem(titleWithIndex.ToString(), i_IsLeaf);

                menuItem.ClearTitle = i_Title;
                m_MenuItems.Add(i_IndexNumber, menuItem);
                menuItem.AttachObserver(this);

                return menuItem;
            }

            public void Report(MenuItem i_MenuItem)
            {
                if (i_MenuItem.FinalMenuItem)
                {
                    GoBackOrExit();
                }
                else
                {
                    r_BackMenuItemIndex.Push(m_MenuItems);
                    r_LastTitle.Push(Title);
                    Title = i_MenuItem.ClearTitle;
                    m_MenuItems = i_MenuItem.MenuItems;
                }
            }

            public void GoBackOrExit()
            {
                if (r_LastTitle.Count == 0)
                {
                    exit();
                }
                else
                {
                    goBack();
                }
            }

            private void goBack()
            {
                m_MenuItems = (Dictionary<int, MenuItem>)r_BackMenuItemIndex.Pop();
                Title = (string)r_LastTitle.Pop();
            }

            private void exit()
            {
                m_KeepRunning = false;
            }

            private void draw()
            {
                StringBuilder titleWithStarts = new StringBuilder();

                titleWithStarts.Append('*', 2);
                titleWithStarts.Append(Title);
                titleWithStarts.Append('*', 2);
                Console.WriteLine();
                Console.WriteLine(titleWithStarts);
                StringBuilder lineOfSpace = new StringBuilder();

                lineOfSpace.Append('-', 23);
                Console.WriteLine(lineOfSpace);
                foreach (KeyValuePair<int, MenuItem> menuItem in m_MenuItems)
                {
                    if (menuItem.Key != 0)
                    {
                        menuItem.Value.Draw();
                    }
                }

                m_MenuItems[0].Draw();
                Console.WriteLine(lineOfSpace);
            }
    }
}
