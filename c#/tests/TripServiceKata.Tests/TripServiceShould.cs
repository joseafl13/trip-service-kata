using FluentAssertions;
using NUnit.Framework;
using System;
using TripServiceKata.Entity;
using TripServiceKata.Exception;

namespace TripServiceKata.Tests
{
    [TestFixture]
    public class TripServiceShould
    {
        private static User loggedUser;

        [Test]
        public void throw_exception_when_user_is_not_logged_in() {
            loggedUser = null;
            var tripService = new TripServiceMock();

            Action action = () => tripService.GetTripsByUser(null);

            action.Should().Throw<UserNotLoggedInException>();
        }

        [Test]
        public void trip_list_is_empty_when_users_are_not_friends() {
            loggedUser = new User();
            var tripService = new TripServiceMock();

            var aGivenUser = new User();
            var friendTrips = tripService.GetTripsByUser(aGivenUser);

            friendTrips.Should().BeEmpty();
        }


        private class TripServiceMock : TripService
        {
            protected override User GetLoggedUser() {
                return loggedUser;
            }
        }
    }
}
