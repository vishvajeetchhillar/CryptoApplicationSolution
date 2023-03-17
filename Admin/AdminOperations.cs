using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Admin
{
    public class AdminOperations:IAdminOperations
    {
        public void MenuList()
        {
            ViewCrypto viewCrpyto1 = new ViewCrypto();
            AdminFunction adf1 = new AdminFunction();
            AdminOperations ao2 = new AdminOperations();
            try
            {
                Console.WriteLine("\nPress 1 for Register new CryptoCurrency");
                Console.WriteLine("Press 2 for Update CryptoCurrency");
                Console.WriteLine("Press 3 for View CryptoCurrency List");
                Console.WriteLine("Press 4 for View Trader List");
                int n = int.Parse(Console.ReadLine());

                switch (n)
                {
                    case 1:
                        Clear.ClearFunc();
                        adf1.RegisterCrypto();
                        break;
                    case 2:
                        Clear.ClearFunc();
                        adf1.UpdateCrypto();
                        break;
                    case 3:
                        Clear.ClearFunc();
                        viewCrpyto1.ViewCrypto1();
                        Console.WriteLine("\nDo you want to use again admin functionality then say (yes)....");
                        string newRegister = Console.ReadLine();
                        if (newRegister.ToLower() == "yes")
                        {
                            ao2.MenuList();
                        }
                        break;
                    case 4:
                        Clear.ClearFunc();
                        adf1.ViewTraderList();
                        Console.WriteLine("\nDo you want to use again User functionality then say (yes)....");
                        string newRegister2 = Console.ReadLine();
                        if (newRegister2.ToLower() == "yes")
                        {
                            ao2.MenuList();
                        }
                        break;
                        break;
                    case 5:
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Login Unsuccessful due to some error");
                Console.WriteLine("Error is :{0} ", e);
            }
        }
    }
}
