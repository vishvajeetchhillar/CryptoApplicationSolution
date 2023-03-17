using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User
{
    public partial class UserFunction
    {
        public void UpdateDetails(string oldusername)
        {
            NewUser user1 = new NewUser();
            try
            {
                Console.WriteLine("Enter the new id for the user: ");
                user1.id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the  new username : ");
                user1.username = Console.ReadLine();
                Console.WriteLine("Enter the new password: ");
                user1.password = Console.ReadLine();
                Console.WriteLine("Enter the new trading amount: ");
                user1.tradingamt = Convert.ToDouble(Console.ReadLine());
                cryptocon.Open();
                SqlCommand update_user_cmd = new SqlCommand($"update UserLogin set id=" + user1.id + ",username='" +
                                                            user1.username +
                                                            "',passwd='" + user1.password +
                                                            "',trading_amt=" +
                                                            user1.tradingamt + "where username='" + oldusername +
                                                            "'", cryptocon);
                update_user_cmd.ExecuteNonQuery();
                cryptocon.Close();
                Console.WriteLine("User Records Updated Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("Login Unsuccessful due to some error");
                Console.WriteLine("Error is :{0} ", e);
            }

            

        }


    }
}
