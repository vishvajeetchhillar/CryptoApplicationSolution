using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
namespace User
{
    public class UserOperations:IUserOperations
    {
        public void MenuList( string username)
         {
             ViewCrypto viewCrpyto1 = new ViewCrypto();
             UserFunction uf1 = new UserFunction();
             UserOperations uo1 = new UserOperations();
            try
             {
                 Console.WriteLine("\nPress 1 for Buy Crypto Currency");
                 Console.WriteLine("Press 2 for Sell Crypto Currency");
                 Console.WriteLine("Press 3 for View CryptoCurrency List");
                 Console.WriteLine("Press 4 to Update User Details");
                 int n = Convert.ToInt32(Console.ReadLine());
                 switch (n)
                 {
                     case 1:
                         Clear.ClearFunc();
                         uf1.BuyCrypto(username);
                         break;
                     case 2:
                         Clear.ClearFunc();
                         uf1.SellCrypto(username);
                         break;
                     case 3:
                         Clear.ClearFunc();
                         viewCrpyto1.ViewCrypto1();
                         Console.WriteLine("\nDo you want to use again User functionality then say (yes)....");
                         string newRegister = Console.ReadLine();
                         if (newRegister.ToLower() == "yes")
                         { 
                             uo1.MenuList(username);
                         }
                         break;
                     case 4:
                         Clear.ClearFunc();
                         uf1.UpdateDetails(username);
                         break;
                     default:
                         Console.WriteLine("Invalid Option");
                         break;
                 }
             }
             catch (Exception e)
             {
                 Console.WriteLine("Login Unsuccessful due to some error");
                 Console.WriteLine("Error is : ", e);
             }
         }
    }
}
