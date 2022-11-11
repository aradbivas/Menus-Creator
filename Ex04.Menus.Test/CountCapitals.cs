using Ex04.Menus.Interface;

namespace Ex04.Menus.Test
{
    public class CountCapitals : IMenuItemListener
    {
        public void Report(MenuItem i_MenuItem)
        {
            InterfaceMenusTest interfaceMenusTest = new InterfaceMenusTest();
            interfaceMenusTest.CountCapitals();
        }
    }
}