using System.Text.Json;

namespace Bioscoop
{
    public class Order
    {
        private readonly int _orderNr;
        private readonly bool _isStudentOrder;
        private readonly IList<MovieTicket> _movieTicketList;

        public Order(int orderNr, bool isStudentOrder)
        {
            _orderNr = orderNr;
            _isStudentOrder = isStudentOrder;
            _movieTicketList = new List<MovieTicket>();
        }

        public int getOrderNr()
        {
            return _orderNr;
        }

        public void addSeatReservation(MovieTicket ticket)
        {
            _movieTicketList.Add(ticket);
        }

        private bool isCorrectStatus()
        {
            int getTicketDay = ((int)_movieTicketList[0].getDateAndTime().DayOfWeek);
            if (!_isStudentOrder && getTicketDay == 1 || getTicketDay == 2 || getTicketDay == 3 || getTicketDay == 4)
            {
                return true;
            }
            else if (_isStudentOrder)
            {
                return true;
            }

            return false;

        }
        
        public double calculatePrice()
        {
            double totalPrice = 0;

            // Kan makkelijker??
            var ticketCount = 0;

            foreach (MovieTicket movieticket in _movieTicketList)
            {
                ticketCount++;
                var priceTicket = movieticket.getPrice();
                // Prijs voor ticket uitrekenen met/zonder premium
                if (movieticket.IsPremiumTicket())
                {
                    if (_isStudentOrder)
                    {
                        priceTicket += 2.0;
                    } else
                    {
                        priceTicket += 3.0;
                    }
                }


                // Checken of ticket 2de is of niet (Met correcte voorwaarden)
                if(!isCorrectStatus() || (ticketCount % 2) != 0)
                {
                    totalPrice += priceTicket;
                }


            }

            // Eventuele korting voor niet studenten (Met correcte voorwaarden)
            if(!isCorrectStatus() && _movieTicketList.Count >= 6)
            {
                totalPrice *= 0.9;
            }


            // Return prijs met alle kortingen inzich
            return totalPrice;
        }

        public void export(TicketExportFormat exportFormat)
        {
            Console.WriteLine("In de exportAsync");
            switch (exportFormat)
            {
                case TicketExportFormat.JSON:
                    Console.WriteLine("In JSON case");

                    string jsonString = JsonSerializer.Serialize(new
                    {
                        OrderNr = _orderNr,
                        TotalPrice = calculatePrice(),
                        Tickets = _movieTicketList,
                        Movie = _movieTicketList[0].getMovie().toString(),
                        DateAndTime = _movieTicketList[0].getDateAndTime(),
                    });

                    File.WriteAllText("text.json", jsonString);

                    break;
                case TicketExportFormat.PLAINTEXT:

                    Console.WriteLine("In PLAINTEXT case");

                    List<String> lines = new List<String>();

                    lines.Add("OrderNr: " + _orderNr);
                    lines.Add("Movie: " + _movieTicketList[0].getMovie().toString());
                    lines.Add("Date: " + _movieTicketList[0].getDateAndTime());
                    lines.Add("Student Order: " + _isStudentOrder);
                    lines.Add("--------");
                    lines.Add("");

                    foreach (MovieTicket movieTicket in _movieTicketList)
                    {
                        lines.Add("Premium: " + movieTicket.IsPremiumTicket() + " - Normal Price: " + movieTicket.getPrice());
                        lines.Add("");
                    }

                    lines.Add("");
                    lines.Add("--------");
                    lines.Add("Total Price: " + calculatePrice());

                   
                    File.WriteAllLines("ticket.txt", lines);

                    break;
                default:
                    Console.WriteLine("In DEFAULT case");
                    break;
            }
        }
    }
}
