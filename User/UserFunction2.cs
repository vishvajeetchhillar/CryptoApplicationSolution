using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace User
{
    public partial class UserFunction
    {
        public void SellCrypto(string username)
        {
            try
            {
                crypto crypto1 = new crypto();
                Console.WriteLine("Enter the crypto currency name you want to sell: ");
                crypto1.name = Console.ReadLine();
                Console.WriteLine("Enter the quantity of stock that you want to sell: ");
                crypto1.quantity = Convert.ToDouble(Console.ReadLine());
                double local_quantity = 0;
                cryptocon.Open();
                SqlCommand cmd_qty =
                    new SqlCommand("Select quantity from crypto where crypto_name='" + crypto1.name + "'", cryptocon);
               
                SqlDataReader sdr_user_sell_crypto = cmd_qty.ExecuteReader();
                while (sdr_user_sell_crypto.Read())
                {
                    local_quantity = Convert.ToDouble(sdr_user_sell_crypto["quantity"].ToString());
                }
                cryptocon.Close();

                double local_sell_price = 0;
                SqlCommand cmd_sell_price =
                    new SqlCommand("Select sell_price from crypto where crypto_name='" + crypto1.name + "'", cryptocon);
                cryptocon.Open();
                SqlDataReader sdr_user_sell_price = cmd_sell_price.ExecuteReader();
                while (sdr_user_sell_price.Read())
                {
                    local_sell_price = Convert.ToDouble(sdr_user_sell_price["sell_price"].ToString());
                }

                Console.WriteLine("Sell Price of the choosen stock avaiable for trading is : {0}", local_sell_price);
                cryptocon.Close();

                double total_price = 0;
                total_price = crypto1.quantity * local_sell_price;
                Console.WriteLine("Hence the final price that is earned  is {0}",
                    total_price);
                double stk_trading_amount = 0;
                cryptocon.Open();
                SqlCommand cmd_trading_amt =
                    new SqlCommand("Select trading_amt from UserLogin where username='" + username + "'",
                        cryptocon);
                SqlDataReader sdr_user_buy_stock_3 = cmd_trading_amt.ExecuteReader();
                while (sdr_user_buy_stock_3.Read())
                {
                    stk_trading_amount = Convert.ToDouble(sdr_user_buy_stock_3["trading_amt"].ToString());
                }

                cryptocon.Close();

                Console.WriteLine("The trading amount available for the user is : {0}", stk_trading_amount);
                var final_trading_amount = stk_trading_amount + total_price;

                double final_qty = 0;
                final_qty = crypto1.quantity + local_quantity;
                double local_buy_price2 = 0;
                cryptocon.Open();
                SqlCommand cmd_price3 =
                    new SqlCommand("Select buy_price from crypto where crypto_name='" + crypto1.name + "'", cryptocon);
                SqlDataReader sdr_user_sell_crypto2 = cmd_price3.ExecuteReader();
                while (sdr_user_sell_crypto2.Read())
                {
                    local_buy_price2 = Convert.ToDouble(sdr_user_sell_crypto2["buy_price"].ToString());
                }
                cryptocon.Close();
                DateTime today = DateTime.Today;
                cryptocon.Open();
                SqlCommand cmdinsert2 = new SqlCommand(
                    $"insert into trader_list values('" + username + "','" + crypto1.name +
                    "'," + crypto1.quantity + ","+local_buy_price2+"," + local_sell_price + "," + total_price + ",'" + today.ToString("dd/MM/yyyy") + "','" + DateTime.Now.ToString("HH:mm:ss") +
                    "')", cryptocon);
                cmdinsert2.ExecuteNonQuery();

                SqlCommand cmdupdate2 = new SqlCommand(
                    $"update UserLogin set trading_amt=" + final_trading_amount + "where username='" +
                    username + "'", cryptocon);
                cmdupdate2.ExecuteNonQuery();

                SqlCommand cryptoupdate2 = new SqlCommand(
                    $"update crypto set quantity=" + final_qty + "where crypto_name='" + crypto1.name + "'", cryptocon);
                cryptoupdate2.ExecuteNonQuery();

                var amount_new2 = (local_buy_price2 * 10) / 100;
                var new_buy_price = local_buy_price2 -amount_new2;

                SqlCommand cryptoupdate_sp = new SqlCommand(
                    $"update crypto set buy_price=" + new_buy_price + "where crypto_name='" + crypto1.name + "'",
                    cryptocon);
                cryptoupdate_sp.ExecuteNonQuery();
                cryptocon.Close();

                Console.WriteLine("Crypto Currency Sold Successfully");
                Console.WriteLine("Records updated Successfully");

            }
            catch (Exception e)
            {
                Console.WriteLine("Login Unsuccessful due to some error");
                Console.WriteLine("Error is : {0}", e);
            }
            
        }
    }
}
