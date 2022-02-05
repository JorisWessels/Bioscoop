using System;
using Xunit;

namespace Bioscoop.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test_Case_1()
        {
            // Arrange
            Order order = new Order(1, true);
            Movie movie = new Movie("Dune");
            MovieScreening movieScreening = new MovieScreening(movie, new DateTime(2022, 2, 7), 10.0);
            MovieTicket ticket = new MovieTicket(movieScreening, true, 1, 5);
            order.addSeatReservation(ticket);

            // Act
            var testResult = order.calculatePrice();

            // Assert
            Assert.Equal(12, testResult);
        }

        [Fact]
        public void Test_Case_2()
        {
            // Arrange
            Order order = new Order(1, false);
            Movie movie = new Movie("Dune");
            MovieScreening movieScreening = new MovieScreening(movie, new DateTime(2022, 2, 7), 10.0);
            MovieTicket ticket = new MovieTicket(movieScreening, true, 1, 5);
            order.addSeatReservation(ticket);

            // Act
            var testResult = order.calculatePrice();

            // Assert
            Assert.Equal(13, testResult);
        }

        [Fact]
        public void Test_Case_3()
        {
            // Arrange
            Order order = new Order(1, false);
            Movie movie = new Movie("Dune");
            MovieScreening movieScreening = new MovieScreening(movie, new DateTime(2022, 2, 7), 10.0);
            MovieTicket ticket = new MovieTicket(movieScreening, false, 1, 5);
            MovieTicket ticketTwo = new MovieTicket(movieScreening, false, 1, 6);
            order.addSeatReservation(ticket);
            order.addSeatReservation(ticketTwo);

            // Act
            var testResult = order.calculatePrice();

            // Assert
            Assert.Equal(10, testResult);
        }

        [Fact]
        public void Test_Case_4()
        {
            // Arrange
            Order order = new Order(1, false);
            Movie movie = new Movie("Dune");
            MovieScreening movieScreening = new MovieScreening(movie, new DateTime(2022, 2, 5), 10.0);
            MovieTicket ticket = new MovieTicket(movieScreening, false, 1, 5);
            MovieTicket ticketTwo = new MovieTicket(movieScreening, false, 1, 6);
            MovieTicket ticketThree = new MovieTicket(movieScreening, false, 2, 6);
            MovieTicket ticketFour = new MovieTicket(movieScreening, false, 2, 5);
            MovieTicket ticketFive = new MovieTicket(movieScreening, false, 3, 6);
            MovieTicket ticketSix = new MovieTicket(movieScreening, false, 1, 6);
            order.addSeatReservation(ticket);
            order.addSeatReservation(ticketTwo);
            order.addSeatReservation(ticketThree);
            order.addSeatReservation(ticketFour);
            order.addSeatReservation(ticketFive);
            order.addSeatReservation(ticketSix);

            // Act
            var testResult = order.calculatePrice();

            // Assert
            Assert.Equal(54, testResult);
        }
    }
}