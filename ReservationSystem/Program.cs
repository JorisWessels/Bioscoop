using ReservationSystem;
using ReservationSystem.Notifier;

MovieScreening movieScreening = new MovieScreening(DateTime.Today.AddDays(1), 5.50);

Order order = new Order(DateTime.Now, movieScreening);

//// Verschillende acties
//order.CreateOrder(5, true);
//order.CreateOrder(6, true);
//order.SubmitOrder();
//order.ProvisionalOrder();
//order.CreateOrder(1, false);
//order.EditOrder(6, true);
//order.SubmitOrder();
//order.PayOrder();
//Console.WriteLine(order.ToString());

EmailClient emailClient = new EmailClient(order);
order.Subscribe(emailClient);
order.Notify();