using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User
{
    public class UserSignUp : NewUser,IUserSignUp
    {
        
        SqlConnection usignupcon =
            new SqlConnection("server=DEL1-LHP-N70336;database=CryptoCurrency;integrated security=true");
        public void UserSignup()
        {
            NewUser user1 = new NewUser();
            try
            {
                Console.WriteLine("Enter the Id: ");
                user1.id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the User Name: ");
                user1.username = Console.ReadLine();
                Console.WriteLine("Enter the Password: ");
                user1.password = Console.ReadLine();
                Console.WriteLine("Enter the Trading Amount: ");
                user1.tradingamt = Convert.ToInt32(Console.ReadLine());
                usignupcon.Open();
                SqlCommand cmdusignup = new SqlCommand($"insert into UserLogin values(" + user1.id + ",'" +
                                                       user1.username + "','" + user1.password + "'," +
                                                       user1.tradingamt + ")", usignupcon);
                cmdusignup.ExecuteNonQuery();
                usignupcon.Close();
                Console.WriteLine("User Sign Up Successful");
            }
            catch (Exception e)
            {
                Console.WriteLine("Sign Up Unsuccessful due to some error");
                Console.WriteLine("Error is : ", e);
            }
        }
    }
}

