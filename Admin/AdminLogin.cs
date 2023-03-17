using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Admin
{
   public class AdminLogin:IAdminLogin
   {
       SqlConnection con = new SqlConnection("server=DEL1-LHP-N70336; database=CryptoCurrency; integrated security=true");
        
        public void Validation()
        {
            NewAdmin admin1 = new NewAdmin();
            AdminOperations ao1 = new AdminOperations();
            try
            {
                Console.WriteLine("Enter Admin Name :  ");
                admin1.username = Console.ReadLine();
                Console.WriteLine("Enter Admin Password:  ");
                admin1.password = Console.ReadLine();
                SqlDataAdapter da = new SqlDataAdapter("select * from AdminLogin", con);
                DataSet ds = new DataSet();
                da.Fill(ds, "AdminLogin");
                int count = ds.Tables[0].Rows.Count;
                int flag = 0;

                for (int i = 0; i < count; i++)
                {
                    if ((admin1.username == (ds.Tables[0].Rows[i][1].ToString())) &&
                        (admin1.password == ds.Tables[0].Rows[i][2].ToString()))
                    {
                        flag = 1;
                        Console.WriteLine("\nWelcome back " + admin1.username + " in a Crypto Currency Trading Admin Portal");
                        ao1.MenuList();
                    }
                }
                if (flag == 0)
                {
                    Console.WriteLine("\nInvalid Credentials");
                    Console.WriteLine("Please Try Again\n");
                    Validation();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Login Unsuccessful due to some error");
                Console.WriteLine("Error is :{0} ",e);

            }
            
        }

        
   }
}
