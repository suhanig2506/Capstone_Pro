using TravelBooking_NewMVC.Models;

namespace TravelBooking_NewMVC.Repository
{
    public interface ITravelRepository
    {
        IEnumerable<TravelRequest> GetTravelReq();
        void RaiseRequest(TravelRequest travelRequest);
        void DeleteRequest(int id);

        TravelRequest GetRequestById(int id);
        void UpdateRequest(TravelRequest travelRequest, int id);
        void BookTravelRequest(int RequestId, string BookingStatus);
        void ApproveTravelRequest(int RequestId, string ApprovalStatus);

    }
}
