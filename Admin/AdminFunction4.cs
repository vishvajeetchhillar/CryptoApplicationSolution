using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Admin
{
    public partial class AdminFunction
    {
        public void ViewTraderList()
        {
            try
            {
                TableFormat table = new TableFormat();
                string cmp = "";
                Console.WriteLine("Do you want to view the complete trader list?");
                cmp = Console.ReadLine();
                if (cmp.ToLower() == "yes")
                {
                    SqlCommand cmd = new SqlCommand("select * from trader_list", cryptocon);
                    cryptocon.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    Console.WriteLine("\n****** Total Trader List ********\n");
                    table.PrintLine();
                    table.PrintRow("username", "crypto_name", "quantity", "buy_price", "sell_price", "total_price", "t_date", "t_time");
                    table.PrintLine();
                    while (sdr.Read())
                    {
                        table.PrintRow(sdr["username"].ToString(), sdr["crypto_name"].ToString(), sdr["quantity"].ToString(), sdr["buy_price"].ToString(), sdr["sell_price"].ToString(), sdr["total_price"].ToString(), sdr["t_date"].ToString(), sdr["t_time"].ToString());
                    }
                    table.PrintLine();
                    cryptocon.Close();
                    Console.WriteLine("Trader List Viewed Successfully");

                }
                else
                {
                    cryptocon.Open();
                    Console.WriteLine("Enter the crypto name: ");
                    string cryp_name = Console.ReadLine();
                    SqlCommand uniq_view = new SqlCommand($"Select * from trader_list where crypto_name='"+cryp_name+"'" ,
                        cryptocon);
                    SqlDataReader sdr2 = uniq_view.ExecuteReader();
                    Console.WriteLine("\n****** Total Trader List ********\n");
                    table.PrintLine();
                    table.PrintRow("username", "crypto_name", "quantity", "buy_price", "sell_price", "total_price", "t_date", "t_time");
                    table.PrintLine();
                    while (sdr2.Read())
                    {
                        table.PrintRow(sdr2["username"].ToString(), sdr2["crypto_name"].ToString(), sdr2["quantity"].ToString(), sdr2["buy_price"].ToString(), sdr2["sell_price"].ToString(), sdr2["total_price"].ToString(), sdr2["t_date"].ToString(), sdr2["t_time"].ToString());
                    }
                    table.PrintLine();
                    cryptocon.Close();
                    Console.WriteLine("Trader List Viewed Successfully");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Trader List View Unsuccessful due to some error");
                Console.WriteLine("Error is :{0} ", e);
            }

        }
    }
}
