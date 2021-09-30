﻿using System.Collections.Generic;
using TripServiceKata.Entity;
using TripServiceKata.Exception;
using TripServiceKata.Service;

namespace TripServiceKata
{
    public class TripService
    {
        public List<Trip> GetTripsByUser(User user)
        {
            List<Trip> tripList = new List<Trip>();
            User loggedUser = GetLoggedUser();
            bool isFriend = false;
            if (loggedUser != null)
            {
                foreach (User friend in user.GetFriends())
                {
                    if (friend.Equals(loggedUser))
                    {
                        isFriend = true;
                        break;
                    }
                }

                if (isFriend)
                {
                    tripList = FindTripsByUser(user);
                }

                return tripList;
            }

            throw new UserNotLoggedInException();
        }

        protected virtual List<Trip> FindTripsByUser(User user) {
            return TripDAO.FindTripsByUser(user);
        }

        protected virtual User GetLoggedUser() {
            return UserSession.GetInstance().GetLoggedUser();
        }
    }
}