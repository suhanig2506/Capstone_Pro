using Final_Pro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_BusinessAcessLayer
{
    public interface ITravelBAL
    {
        int RaiseTravelRequest_BAL(int reqid, int empId, string location_from, string location_to);
        //int EditRequest_DAL(TravelRequest TravelRequest);
        int ViewTravelRequest_BAL();
        int DeleteRequest_BAL(int reqid);
        void EditTravelRequest_BAL(TravelRequest req_to_change);
        TravelRequest GetTravelRequestById_BAL(int reqId);
        //void EditEmployee_BAL(Employee emp_to_change);
        int ApproveRequest_BAL(int req_Id, Approve_Enum appstatus);

        int ConfirmRequest_BAL(int req_Id, Booking_Enum bookstatus);
        int ViewJionReqTable_BAL();

        int ViewTravelRequestPending_BAL();
        int ViewTravelRequestApproveOpen_BAL();

        int ViewTravelByLocFrom_BAL(string loca_from);
        int ViewTravelByLocTo_BAL(string loca_to);
    }
}
