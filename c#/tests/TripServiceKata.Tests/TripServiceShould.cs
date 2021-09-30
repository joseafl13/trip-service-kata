using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using TripServiceKata.Entity;
using TripServiceKata.Exception;

namespace TripServiceKata.Tests
{
    [TestFixture]
    public class TripServiceShould
    {
        private static User loggedUser;
        private static List<Trip> userTrips;

        [Test]
        public void throw_exception_when_user_is_not_logged_in() {
            loggedUser = null;
            var tripService = new TripServiceMock();

            Action action = () => tripService.GetTripsByUser(null);

            action.Should().Throw<UserNotLoggedInException>();
        }

        [Test]
        public void return_an_empty_trip_list_when_users_are_not_friends() {
            loggedUser = new User();
            var tripService = new TripServiceMock();

            var aGivenUser = new User();
            var friendTrips = tripService.GetTripsByUser(aGivenUser);

            friendTrips.Should().BeEmpty();
        }

        [Test]
        public void return_trip_list_when_users_are_friends() {
            loggedUser = new User();
            userTrips = new List<Trip>() { new Trip() };
            var tripService = new TripServiceMock();

            var aGivenUser = new User();
            aGivenUser.AddFriend(loggedUser);
            var friendTrips = tripService.GetTripsByUser(aGivenUser);

            friendTrips.Count.Should().Be(1);
        }

        private class TripServiceMock : TripService
        {
            protected override User GetLoggedUser() {
                return loggedUser;
            }

            protected override List<Trip> FindTripsByUser(User user) {
                return userTrips;
            }
        }
    }
}
