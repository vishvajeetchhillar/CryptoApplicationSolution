using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User
{
    public class UserLogin
    {
        
        
        SqlConnection usercon = new SqlConnection("server=DEL1-LHP-N70336; database=CryptoCurrency; integrated security=true");
        public void UserValidation()
        {
            NewUser user2 = new NewUser();
            UserOperations userOp = new UserOperations();
            try
            {
                Console.WriteLine("\nEnter User Id :");
                user2.id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter User Name :  ");
                user2.username = Console.ReadLine();
                Console.WriteLine("Enter User Password:  ");
                user2.password = Console.ReadLine();
                SqlDataAdapter da = new SqlDataAdapter("select * from UserLogin", usercon);
                DataSet ds = new DataSet();
                da.Fill(ds, "UserLogin");
                int count = ds.Tables[0].Rows.Count;
                int flag = 0;
                for (int i = 0; i < count; i++)
                {
                    if ((user2.username == (ds.Tables[0].Rows[i][1].ToString())) &&
                        (user2.password == ds.Tables[0].Rows[i][2].ToString()))
                    {
                        flag = 1;
                        Console.WriteLine("\nWelcome back " + user2.username + " in a Stock User Portal");
                        userOp.MenuList(user2.username);
                    }
                }
                if (flag == 0)
                {
                    Console.WriteLine("\nInvalid Credentials");
                    Console.WriteLine("Please Try Again\n");
                    UserValidation();
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
