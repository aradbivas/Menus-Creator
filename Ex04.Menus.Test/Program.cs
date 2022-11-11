using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus.Interface;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            Run();
        }

        public static void Run()
        {
            DelegatesMenusTest delegatesMenusTest = new DelegatesMenusTest();
            InterfaceMenusTest interfaceMenusTest = new InterfaceMenusTest();

            delegatesMenusTest.DelegateMenus();
            interfaceMenusTest.InterFaceMenus();
        }
    }
}
