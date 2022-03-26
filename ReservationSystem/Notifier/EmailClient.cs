using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Notifier
{
    public class EmailClient : ISubscriber
    {
        private Order _order;

        public EmailClient(Order order)
        {
            _order = order;
        }

        public void Update()
        {
            Console.WriteLine(_order.GetOrderCreateAt());
        }
    }
}
