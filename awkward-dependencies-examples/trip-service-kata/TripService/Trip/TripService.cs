using TripService.Exception;
using TripService.User;

namespace TripService.Trip;

public class TripService
{
    public List<Trip> GetTripsByUser(User.User user)
    {
        var tripList = new List<Trip>();
        var loggedUser = UserSession.GetInstance().GetLoggedUser();
        var isFriend = false;

        if (loggedUser == null)
        {
            throw new UserNotLoggedInException();
        }

        if (Enumerable.Contains(user.GetFriends(), loggedUser))
        {
            isFriend = true;
        }

        if (isFriend)
        {
            tripList = TripDAO.FindTripsByUser(user);
        }

        return tripList;
    }
}