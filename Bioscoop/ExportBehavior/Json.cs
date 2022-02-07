using System.Text.Json;

namespace Bioscoop.ExportBehavior
{
    public class Json : IOrderExportBehavior
    {
        public void Export(Order order)
        {
            Console.WriteLine("In JSON case");

                    string jsonString = JsonSerializer.Serialize(new
                    {
                        OrderNr = order.getOrderNr(),
                        TotalPrice = order.performCalculatePrice(),
                        Tickets = order.getMovieTicketList(),
                        Movie = order.getMovieTicketList()[0].getMovie().toString(),
                        DateAndTime = order.getMovieTicketList()[0].getDateAndTime(),
                    });

                    File.WriteAllText("text.json", jsonString);
        }
    }
}
