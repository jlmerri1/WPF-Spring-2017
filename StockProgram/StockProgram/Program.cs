using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProgram
{
    public class StockEventArgs : EventArgs  //sending data to the subscribers
    {
        public float googleStock;
        public float amazonStock;
        public float telsaStock;

        public StockEventArgs(float g, float a, float t)
        {
            this.googleStock = g;
            this.amazonStock = a;
            this.telsaStock = t;
        }
    }


    public class Stock
    {
        private float googleStock;
        private float amazonStock;
        private float teslaStock;

        public delegate void StocksChangedHandler(object stock, StockEventArgs s);
        public StocksChangedHandler StockChanged;

        public void ReceiveStock()
        {
            Random rand = new Random();
            //randomlly generate stock price
            //subscribers are modified
            googleStock = (float) rand.Next(1000);
            amazonStock = (float)rand.Next(1000);
            teslaStock = (float)rand.Next(1000);

            Console.WriteLine("Stocks Received: ");
            Console.WriteLine("Google: " + googleStock + " Amazon: " + amazonStock + " Tesla: " + teslaStock);

            StockEventArgs stock = new StockEventArgs(googleStock, amazonStock, teslaStock);

            if(StockChanged != null)
            {
                StockChanged(this, stock);
            }
        }
    }

    public class ItStockBuyer
    {
        private float gStock;
        private float aStock;

        public void Subscribe(Stock stock)
        {
            stock.StockChanged += new Stock.StocksChangedHandler(BuyStock); //+= means we add a method to the delegates list
        }

        public void BuyStock(object stock, StockEventArgs s)
        {
            Console.WriteLine("Buyer: New Stock List.");
            Console.WriteLine("Google: " + s.googleStock + " Amazon: " + s.amazonStock);

            if (s.googleStock > 500)
            {
                Console.WriteLine("Buying google stock.");
            }
            else
                Console.WriteLine("Not buying google stock.");
            if(s.amazonStock > 300)
            {
                Console.WriteLine("Buying amazon stock.");
            }
            else
                Console.WriteLine("Not buying amazon stock.");
        }
    }

    public class ItStockSeller
    {
        private float tStock;

        public void SellStock()
        {

        }
    }




    class Program
    {
        static void Main(string[] args)
        {
            Stock stock = new Stock();
            ItStockBuyer buyer = new ItStockBuyer();

            buyer.Subscribe(stock);

            stock.ReceiveStock();

            Console.Read();
        }
    }
}
