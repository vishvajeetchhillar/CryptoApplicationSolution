using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Admin
{
    public partial class AdminFunction
    {
        
        SqlConnection cryptocon = new SqlConnection("server=DEL1-LHP-N70336;database=CryptoCurrency;integrated security=true");
        public void RegisterCrypto()
        {
            crypto crypto1 = new crypto();
            try
            {
                Console.WriteLine("Enter the id for the crypto currency: ");
                crypto1.id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the Name of the crypto currency: ");
                crypto1.name = Console.ReadLine();
                Console.WriteLine("Enter the Quantity of the crypto currency: ");
                crypto1.quantity = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter the launch price of the crypto currency: ");
                crypto1.launch_price = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter the Buy Price of the crypto currency: ");
                crypto1.buyprice = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter the Sell Price of the crypto currency: ");
                crypto1.sellprice = Convert.ToDouble(Console.ReadLine());
                DateTime today = DateTime.Today;
                crypto1.date_of_launch = today.ToString("dd/MM/yyyy");
                 cryptocon.Open();
                SqlCommand cmd = new SqlCommand($"insert into crypto values("+crypto1.id+",'" + crypto1.name + "'," + crypto1.quantity + "," +
                                                crypto1.launch_price + "," +
                                                crypto1.buyprice + "," + crypto1.sellprice + ",'"+crypto1.date_of_launch+"')", cryptocon);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Registration of New CryptoCurrency Successful");
                cryptocon.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Registration of New Crypto Currency Unsuccessful due to some error");
                Console.WriteLine("Error is :{0} ", e);
            }
        }
    }
}
