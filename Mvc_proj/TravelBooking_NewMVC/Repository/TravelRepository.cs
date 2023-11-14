using Microsoft.EntityFrameworkCore;
using TravelBooking_NewMVC.Models;

namespace TravelBooking_NewMVC.Repository
{
    public class TravelRepository:ITravelRepository
    {
        private readonly Emp_Travel_BookingContext _context;
        public TravelRepository(Emp_Travel_BookingContext context)
        {
            _context = context;
        }
        public IEnumerable<TravelRequest> GetTravelReq()
        {
            IEnumerable<TravelRequest> trequest = _context.TravelRequests.Include(x => x.Emp);

            return trequest;
        }
        public void RaiseRequest(TravelRequest tr)
        {
            if (tr != null)
            {
                tr.ApprovalStatus = "Pending";
                tr.BookingStatus = "Pending";
                tr.CurrentStatus = "Open";
                _context.TravelRequests.Add(tr);
                _context.SaveChanges();
            }
        }
        public void DeleteRequest(int id)
        {
            TravelRequest? travelRequest = _context.TravelRequests.FirstOrDefault(x => x.RequestId == id);

            if (travelRequest != null)
            {
                _context.TravelRequests.Remove(travelRequest);
                _context.SaveChanges();
            }

        }
        public TravelRequest GetRequestById(int id)
        {
            TravelRequest? travelRequest = _context.TravelRequests.FirstOrDefault(x => x.EmpId == id);
            return travelRequest;
        }
        public void UpdateRequest(TravelRequest travelrequest, int id)
        {
            TravelRequest? req_old = _context.TravelRequests.FirstOrDefault(x => x.EmpId == id);
            if (req_old != null)
            {

                req_old.LocFrom = travelrequest.LocFrom;
                req_old.LocTo = travelrequest.LocTo;
                req_old.ReqDate = travelrequest.ReqDate;
                _context.SaveChanges();
            }
        }
        public void ApproveTravelRequest(int id, string status)
        {
            TravelRequest tr = _context.TravelRequests.FirstOrDefault(x => x.RequestId == id);

            if (tr != null)
            {
                tr.ApprovalStatus = status;
                if (tr.ApprovalStatus == "NotApproved")
                {
                    tr.CurrentStatus = "Close";
                }
                _context.SaveChanges();
            }
        }

        public void BookTravelRequest(int id, string status)
        {

            TravelRequest tr = _context.TravelRequests.FirstOrDefault(x => x.RequestId == id);

            if (tr != null)
            {

                tr.BookingStatus = status;
                tr.CurrentStatus = "Close";
                _context.SaveChanges(true);

            }

        }

    }
}
