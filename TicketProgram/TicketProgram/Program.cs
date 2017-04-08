using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketProgram
{
    public class TicketInfoArgs : EventArgs
    {
        public DateTime movieDate;
        public string movieName;

        public TicketInfoArgs(DateTime d, string m)
        {
            this.movieDate = d;
            this.movieName = m;
        }
    }

    public class MovieTickets
    {
        public delegate void MovieChangedHandler(object movie, TicketInfoArgs t);
        public MovieChangedHandler MovieChanged;

        public void PurchaseTickets(DateTime movieDate, string movieName)
        {
            TicketInfoArgs ticket = new TicketInfoArgs(movieDate, movieName);

            if(MovieChanged != null)
            {
                MovieChanged(this, ticket);
            }
        }
    }

    public class TicketSales
    {
        public void Subscribe(MovieTickets tickets)
        {
            tickets.MovieChanged +=  new MovieTickets.MovieChangedHandler(NewPurchase);
        }

        public void NewPurchase(object movie, TicketInfoArgs t)
        {
            Console.WriteLine("Movie date: " + t.movieDate);
            Console.WriteLine("Movie name: " + t.movieName);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MovieTickets mt = new MovieTickets();
            TicketSales ts = new TicketSales();
            ts.Subscribe(mt);
            mt.PurchaseTickets(new DateTime(2016, 3, 25), "Split");
            Console.Read();

        }
    }
}
