using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus.Interface;

namespace Ex04.Menus.Test
{
    public class ShowVersion : IMenuItemListener
    {
        public void Report(MenuItem i_MenuItem)
        {
            InterfaceMenusTest interfaceMenusTest = new InterfaceMenusTest();

            interfaceMenusTest.ShowVersion();
        }
    }
}
