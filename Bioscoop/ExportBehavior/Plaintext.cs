namespace Bioscoop.ExportBehavior
{
    public class Plaintext : IOrderExportBehavior
    {
        public void Export(Order order)
        {
            Console.WriteLine("In PLAINTEXT case");

                    List<String> lines = new List<String>();

                    bool isStudentOrder = (string.Equals(order.getCalculatePriceBehavior().GetOrderType(), "Student Order"));

                    lines.Add("OrderNr: " + order.getOrderNr());
                    lines.Add("Movie: " + order.getMovieTicketList()[0].getMovie().toString());
                    lines.Add("Date: " + order.getMovieTicketList()[0].getDateAndTime());
                    lines.Add("--------");
                    lines.Add("");

                    foreach (MovieTicket movieTicket in order.getMovieTicketList())
                    {
                        lines.Add("Premium: " + movieTicket.IsPremiumTicket() + " - Normal Price: " + movieTicket.getPrice(isStudentOrder));
                        lines.Add("");
                    }

                    lines.Add("");
                    lines.Add("--------");
                    lines.Add("Total Price: " + order.performCalculatePrice());

                   
                    File.WriteAllLines("ticket.txt", lines);
        }
    }
}
