using TripServiceKata.Entity;

namespace TripServiceKata.Tests
{
    public partial class TripServiceShould
    {
        private class TripServiceMock : TripService
        {
            protected override User GetLoggedUser() {
                return null;
            }
        }
    }
}