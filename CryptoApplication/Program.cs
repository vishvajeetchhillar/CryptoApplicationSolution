using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin;
using User;
namespace CryptoApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var admin1 = new AdminLogin();
                var userSignUp1 = new UserSignUp();
                var userLogin1 = new UserLogin();
                Console.WriteLine("***************************");
                Console.WriteLine("Welcome to Crypto Currency Trading");
                Console.WriteLine("***************************");
                Console.WriteLine("\nPress 1 for Admin Login ");
                Console.WriteLine("Press 2 for User Login");
                Console.WriteLine("Press 3 for User Sign Up\n");
                int n = Convert.ToInt32(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        admin1.Validation();
                        break;
                    case 2:
                        userLogin1.UserValidation();
                        break;
                    case 3:
                        userSignUp1.UserSignup();
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid");
                Console.WriteLine("Error Occured: {0}",e);
            }
                
        }
    }
}
