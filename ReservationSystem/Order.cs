using ReservationSystem.OrderStates;
using ReservationSystem.Notifier;

namespace ReservationSystem
{
    public class Order : INotifier
    {
        private DateTime _orderCreateAt;
        private readonly MovieScreening _movieScreening;
        private int _ticketAmount;
        private bool _parking;
        private IState _state;

        private IList<ISubscriber> _subscribers = new List<ISubscriber>();

        public Order(DateTime orderCreateAt, MovieScreening movieScreening) {
            _orderCreateAt = orderCreateAt;
            _movieScreening = movieScreening;
            _state = new OrderStartState(this);
        }

        public void ResetOrder() {
            _ticketAmount = 0;
            _parking = false;
        }

        public IState GetState()
        {
            return _state;
        } 

        public DateTime GetOrderCreateAt() {
             return _orderCreateAt; 
        }

        public void SetParking(bool parking)
        {
            _parking = parking;
        }

        public bool GetParking()
        {
            return _parking;
        }

        public MovieScreening GetMovieScreening()
        {
            return _movieScreening;
        }

        public void SetTicketAmount(int ticketAmount)
        {
            _ticketAmount = ticketAmount;
        }
        
        public void SetOrderCreateAt(DateTime orderCreateAt) {
            _orderCreateAt = orderCreateAt;
        }

        public int GetTicketAmount()
        {
            return _ticketAmount;
        }

        public void SubmitOrder()
        {
            _state = _state.OrderConfirm();
        }

        public void CreateOrder(int ticketAmount, bool parking)
        {
            _state = _state.OrderCreate(ticketAmount, parking);
        }

        public void PayOrder()
        {
            _state = _state.OrderPay();
        }

        public void ProvisionalOrder()
        {
            _state = _state.OrderProvisional();
        }
        
        public void EditOrder(int ticketAmount, bool parking)
        {
            _state = _state.OrderEdit(ticketAmount, parking);
        }

        public void CancelOrder()
        {
            _state =_state.OrderCancel();
        }

        public override string ToString()
        {
            return string.Format("Ticket amount: {0}, Parking: {1}, Order created at {2}", GetTicketAmount(), GetParking(), GetOrderCreateAt().Date);
        }

        public void Subscribe(ISubscriber subscriber)
        {
            _subscribers.Add(subscriber);
        }

        public void Unsubscribe(ISubscriber subscriber)
        {
            _subscribers.Remove(subscriber);
        }

        public void Notify()
        {
            foreach (var subscriber in _subscribers)
            {
                subscriber.Update();
            }
        }
    }
}
