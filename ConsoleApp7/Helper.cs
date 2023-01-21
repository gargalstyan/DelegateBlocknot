using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
   public class Helper
    {
        public static void ShowMenu()
        {
            MenuItems[] menuItems = Enum.GetValues<MenuItems>();

            for (int i = 0; i < menuItems.Length; i++)
            {
                System.Console.WriteLine($"{(int)menuItems[i]} - {menuItems[i].ToString().AddSpaceBetween()}");
            }
        }
    }
}
