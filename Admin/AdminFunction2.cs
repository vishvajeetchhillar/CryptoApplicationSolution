using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Admin
{
    public partial class AdminFunction
    {
        
        public void UpdateCrypto()
        {
            crypto crypto2 = new crypto();
            try
            {
                string old_username = "";
                Console.WriteLine("Enter the old name of the crypto currency: ");
                old_username = Console.ReadLine();
                Console.WriteLine("Enter the new id for the crypto currency: ");
                crypto2.id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the new Name of the CryptoCurrency: ");
                crypto2.name = Console.ReadLine();
                Console.WriteLine("Enter the new Launch Price of the CryptoCurrency: ");
                crypto2.launch_price = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter the new Quantity of the CryptoCurrency: ");
                crypto2.quantity = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter the new Buy Price of the CryptoCurrency: ");
                crypto2.buyprice = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter the new Sell Price of the CryptoCurrency: ");
                crypto2.sellprice = Convert.ToDouble(Console.ReadLine());
                cryptocon.Open();
                SqlCommand cmdupdate = new SqlCommand(
                    $"update crypto set id="+crypto2.id+" crypto_name='" + crypto2.name + "',quantity=" + crypto2.quantity + ",launch_price="+crypto2.launch_price+",buy_price=" + crypto2.buyprice + ",sell_price=" +
                    crypto2.sellprice + " where crypto_name='" + old_username + "'", cryptocon);
                cmdupdate.ExecuteNonQuery();
                cryptocon.Close();
                Console.WriteLine("Crypto Currency Updated Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("Update Unsuccessful due to some error");
                Console.WriteLine("Error is : {0}", e);
            }
        }
    }
}
