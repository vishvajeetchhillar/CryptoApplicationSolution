using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ViewCrypto:IViewCrypto
    {
        SqlConnection cryptocon = new SqlConnection("server=DEL1-LHP-N70336; database=CryptoCurrency; integrated security=true");
        public void ViewCrypto1()
        {
            TableFormat table = new TableFormat();
            try
            {
                SqlCommand cmd = new SqlCommand("select * from crypto", cryptocon);
                cryptocon.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                Console.WriteLine("\n****** Total Crypto Currency ********\n");

                table.PrintLine();
                table.PrintRow("id","crypto_name", "quantity","launch_price", "buy_Price", "sell_Price","date_of_launch");
                table.PrintLine();
                while (dr.Read())
                {
                    table.PrintRow(dr["id"].ToString(), dr["crypto_name"].ToString(), 
                        dr["quantity"].ToString(), dr["launch_price"].ToString(), dr["buy_price"].ToString(), dr["sell_price"].ToString(),dr["date_of_launch"].ToString());
                }
                table.PrintLine();
                cryptocon.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Crypto Currency List cannot be viewed");
                Console.WriteLine("Error Occured :{0} ",e);
            }
            
            
            
        }
    }
}
