using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interface
{
    public class MenuItem
    {
        private readonly List<IMenuItemListener> r_MenuItemListener = new List<IMenuItemListener>();
        private Dictionary<int, MenuItem> m_MenuItem = new Dictionary<int, MenuItem>();
        private string m_ItemTitle;
        private bool m_IsFinalMenuItem = false;
        private int m_MenuCount = 0;
        private string m_ClearTitle;
        private bool m_IsLeaf;

        public void AttachObserver(IMenuItemListener i_MenuItemObserver)
        {
            r_MenuItemListener.Add(i_MenuItemObserver);
        }

        public void DetachObserver(IMenuItemListener i_MenuItemObserver)
        {
            r_MenuItemListener.Remove(i_MenuItemObserver);
        }

        public bool FinalMenuItem
        {
            get
            {
                return m_IsFinalMenuItem;
            }

            set
            {
                m_IsFinalMenuItem = value;
            }
        }

        public bool IsLeaf
        {
            get
            {
                return m_IsLeaf;
            }

            set
            {
                m_IsLeaf = value;
            }
        }

        public string ClearTitle
        {
            get
            {
                return m_ClearTitle;
            }

            set
            {
                m_ClearTitle = value;
            }
        }

        public void AddToDictionary(MenuItem i_MenuItem, int i_Index)
        {
            m_MenuItem.Add(i_Index, i_MenuItem);
        }

        public int Counter
        {
            get
            {
                return m_MenuCount;
            }

            set
            {
                m_MenuCount = value;
            }
        }

        public MenuItem(string i_ItemTitle, bool i_IsLeaf)
        {
            m_IsLeaf = i_IsLeaf;
            m_ItemTitle = i_ItemTitle;
        }

        public Dictionary<int, MenuItem> MenuItems
        {
            get
            {
                return m_MenuItem;
            }

            set
            {
                m_MenuItem = value;
            }
        }

        public string TitleText
        {
            get
            {
                return m_ItemTitle;
            }

            set
            {
                m_ItemTitle = value;
            }
        }

        public void Draw()
        {
            Console.WriteLine("{0}", TitleText);
        }

        public void OnSelected()
        {
            notifySickObservers();
        }

        private void notifySickObservers()
        {
            foreach(IMenuItemListener observer in r_MenuItemListener)
            {
                observer.Report(this);
            }
        }
    }
}
