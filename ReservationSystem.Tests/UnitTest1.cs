using ReservationSystem.OrderStates;
using System;
using Xunit;

namespace ReservationSystem.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void TestStartState()
        {
            // Arrange
            MovieScreening movieScreening = new MovieScreening(DateTime.Today.AddDays(1), 5.50);
            Order order = new Order(DateTime.Now, movieScreening);
            OrderStartState checkState = new OrderStartState(order);
            
            // Act


            // Assert
            Assert.Equal(order.GetState().GetType(), checkState.GetType());        
        }

        [Fact]
        public void TestStartToCreateState()
        {
            // Arrange
            MovieScreening movieScreening = new MovieScreening(DateTime.Today.AddDays(1), 5.50);
            Order order = new Order(DateTime.Now, movieScreening);
            OrderCreateState checkState = new OrderCreateState(order);

            // Act
            order.CreateOrder(6, true);

            // Assert
            Assert.Equal(order.GetState().GetType(), checkState.GetType());
            Assert.Equal(6, order.GetTicketAmount());
            Assert.True(order.GetParking());
        }

        [Fact]
        public void TestCreateToSubmitState()
        {
            // Arrange
            MovieScreening movieScreening = new MovieScreening(DateTime.Today.AddDays(1), 5.50);
            Order order = new Order(DateTime.Now, movieScreening);
            OrderSubmitState checkState = new OrderSubmitState(order);

            // Act
            order.CreateOrder(6, true);
            order.SubmitOrder();

            // Assert
            Assert.Equal(order.GetState().GetType(), checkState.GetType());
        }

        [Fact]
        public void TestSubmitToEditState()
        {
            // Arrange
            MovieScreening movieScreening = new MovieScreening(DateTime.Today.AddDays(1), 5.50);
            Order order = new Order(DateTime.Now, movieScreening);
            OrderEditState checkState = new OrderEditState(order);

            // Act
            order.CreateOrder(6, true);
            order.SubmitOrder();
            order.EditOrder(5, true);

            // Assert
            Assert.Equal(order.GetState().GetType(), checkState.GetType());
            Assert.Equal(5, order.GetTicketAmount());
            Assert.True(order.GetParking());
        }

        [Fact]
        public void TestSubmitToProvisionalState()
        {
            // Arrange
            MovieScreening movieScreening = new MovieScreening(DateTime.Today.AddDays(1), 5.50);
            Order order = new Order(DateTime.Now, movieScreening);
            OrderProvisionalState checkState = new OrderProvisionalState(order);

            // Act
            order.CreateOrder(6, true);
            order.SubmitOrder();
            order.ProvisionalOrder();

            // Assert
            Assert.Equal(order.GetState().GetType(), checkState.GetType());
        }

        [Fact]
        public void TestSubmitToCancelState()
        {
            // Arrange
            MovieScreening movieScreening = new MovieScreening(DateTime.Today.AddDays(1), 5.50);
            Order order = new Order(DateTime.Now, movieScreening);
            OrderCancelState checkState = new OrderCancelState(order);

            // Act
            order.CreateOrder(6, true);
            order.SubmitOrder();
            order.CancelOrder();

            // Assert
            Assert.Equal(order.GetState().GetType(), checkState.GetType());
        }

        [Fact]
        public void TestSubmitToPayState()
        {
            // Arrange
            MovieScreening movieScreening = new MovieScreening(DateTime.Today.AddDays(1), 5.50);
            Order order = new Order(DateTime.Now, movieScreening);
            OrderPayState checkState = new OrderPayState(order);

            // Act
            order.CreateOrder(6, true);
            order.SubmitOrder();
            order.PayOrder();

            // Assert
            Assert.Equal(order.GetState().GetType(), checkState.GetType());
        }
    }
}