using Final_Pro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_DataAceessLayer
{
    public interface IReqDataManager
    {
        int RaiseTravelRequest_DAL(int reqid, int empId, string location_from, string location_to);
        //int EditRequest_DAL(TravelRequest trq_to_change);

        TravelRequest  GetRequestById_DAL(int reqId);
        int ViewTravelRequest_DAL();
        int DeleteRequest_DAL(int reqid);
        int EditTravelRequest_DAL(TravelRequest travel);
        int ApproveRequest_DAL(int req_Id, Approve_Enum appstatus);

        int ConfirmRequest_DAL(int req_Id, Booking_Enum bookstatus);

        int ViewJionReqTable_DAL();
        int ViewTravelRequestPending_DAL();
        int ViewTravelRequestApproveOpen_DAL();
        int ViewTravelByLocFrom_DAL(string loca_from);
        int ViewTravelByLocTo_DAL(string loca_to);
    }
    
}
