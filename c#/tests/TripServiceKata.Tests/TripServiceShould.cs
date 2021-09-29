using FluentAssertions;
using NUnit.Framework;
using System;
using TripServiceKata.Exception;

namespace TripServiceKata.Tests
{
    [TestFixture]
    public partial class TripServiceShould
    {
        [Test]
        public void throw_exception_when_user_is_not_logged_in() {
            var tripService = new TripServiceMock();

            Action action = () => tripService.GetTripsByUser(null);

            action.Should().Throw<UserNotLoggedInException>();
        }
    }
}
