using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace User
{
    public partial class UserFunction
    {
        double zero = 0;
        SqlConnection cryptocon = new SqlConnection("server=DEL1-LHP-N70336; database=CryptoCurrency; integrated security=true");
        public void BuyCrypto(string username)
        {
            crypto crypto1 = new crypto();
            try
            {
                Console.WriteLine("Enter the name of the crypto currency: ");
                crypto1.name = Console.ReadLine();

                double local_quantity = 0;
                cryptocon.Open();
                SqlCommand cmd_qty =
                    new SqlCommand("Select quantity from crypto where crypto_name='" + crypto1.name + "'", cryptocon);
                SqlDataReader sdr_user_buy_crypto = cmd_qty.ExecuteReader();
                while (sdr_user_buy_crypto.Read())
                {
                    local_quantity = Convert.ToDouble(sdr_user_buy_crypto["quantity"].ToString());
                }

                Console.WriteLine("Quantity of the choosen crypto currency available for trading is : {0}", local_quantity);
                cryptocon.Close();
                Console.WriteLine("Enter the Quantity: ");
                crypto1.quantity = Convert.ToDouble(Console.ReadLine());
                double local_buy_price = 0;
                double local_sell_price2 = 0;
                if (local_quantity < crypto1.quantity)
                {
                    Console.WriteLine("Insufficient Invalid Quantity");
                }
                else
                {
                    cryptocon.Open();
                    SqlCommand cmd_price =
                        new SqlCommand("Select buy_price from crypto where crypto_name='" + crypto1.name + "'", cryptocon);
                    SqlDataReader sdr_user_buy_crypto2 = cmd_price.ExecuteReader();
                    while (sdr_user_buy_crypto2.Read())
                    {
                        local_buy_price = Convert.ToDouble(sdr_user_buy_crypto2["buy_price"].ToString());
                    }

                    cryptocon.Close();

                    cryptocon.Open();
                    SqlCommand cmd_price2 =
                        new SqlCommand("Select sell_price from crypto where crypto_name='" + crypto1.name + "'", cryptocon);
                    SqlDataReader sdr_user_buy_crypto_3 = cmd_price2.ExecuteReader();
                    while (sdr_user_buy_crypto_3.Read())
                    {
                        local_sell_price2 = Convert.ToDouble(sdr_user_buy_crypto_3["sell_price"].ToString());
                    }

                    cryptocon.Close();

                    Console.WriteLine("The buy price of the above choosen cryptocurrency is : {0}", local_buy_price);
                    var stk_user_price = local_buy_price * crypto1.quantity;
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
                    
                    Console.WriteLine("The total Price to be paid to buy stock is : {0}", stk_user_price);
                    if (stk_trading_amount < stk_user_price)
                    {
                        Console.WriteLine("Insufficient trading amount");
                    }
                    else
                    {
                        int buy = 0;
                        Console.WriteLine("Do you want to buy the crypto currency? ");
                        Console.WriteLine("Press Any Digit from 1 to 9 for Yes");
                        Console.WriteLine("Press 0 for No");
                        buy = Convert.ToInt32(Console.ReadLine());
                        if (buy == 0)
                        {
                            Console.WriteLine("You cancelled the transaction to buy the stock");

                        }
                        else
                        {
                            var left_trading_amount = stk_trading_amount - stk_user_price;
                            DateTime today = DateTime.Today;
                            cryptocon.Open();
                            SqlCommand cmdinsert = new SqlCommand(
                                $"insert into trader_list values('" + username + "','" + crypto1.name +
                                "'," + crypto1.quantity + ","+local_buy_price+","+local_sell_price2+"," +stk_user_price + ",'" + today.ToString("dd/MM/yyyy") + "','" + DateTime.Now.ToString("HH:mm:ss") +
                                "')", cryptocon);
                            cmdinsert.ExecuteNonQuery();
                            SqlCommand cmdupdate = new SqlCommand(
                                $"update UserLogin set trading_amt=" + left_trading_amount +
                                "where username='" + username + "'", cryptocon);
                            cmdupdate.ExecuteNonQuery();

                            double left_qty = local_quantity - crypto1.quantity;
                            SqlCommand cryptoupdate = new SqlCommand(
                                $"update crypto set quantity=" + left_qty + "where crypto_name='" + crypto1.name + "'",
                                cryptocon);
                            cryptoupdate.ExecuteNonQuery();

                            var amount_new = (local_buy_price * 10) / 100;
                            var new_buy_price = local_buy_price + amount_new;

                            SqlCommand cryptoupdate_bp = new SqlCommand(
                                $"update crypto set buy_price=" + new_buy_price + "where crypto_name='" + crypto1.name + "'",
                                cryptocon);
                            cryptoupdate_bp.ExecuteNonQuery();

                            cryptocon.Close();
                            Console.WriteLine("Record Updated in Trader List and Crypto List Successfully");
                        }
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Buying Operation Unsuccessful");
                Console.WriteLine("Error Occured : {0}",e);

            }
            
        }
    }
}
