using System.Collections.Generic;
using System.Linq;
using TripServiceKata.Entity;
using TripServiceKata.Exception;
using TripServiceKata.Service;

namespace TripServiceKata
{
    public class TripService
    {
        public List<Trip> GetTripsByUser(User user, User loggedUser)
        {
            if (loggedUser == null) throw new UserNotLoggedInException();
         
            var tripList = new List<Trip>();
            var isFriend = Enumerable.Contains(user.GetFriends(), loggedUser);
            if (isFriend) tripList = FindTripsByUser(user);

            return tripList;
        }

        protected virtual List<Trip> FindTripsByUser(User user) {
            return TripDAO.FindTripsByUser(user);
        }
    }
}