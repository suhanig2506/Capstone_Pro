using ClassLibrary_DataAceessLayer;
using Final_Pro;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_BusinessAcessLayer
{
    public class TravelBAL:ITravelBAL
    {
        private static readonly TravelDataManager Trequest = new TravelDataManager();
        public int RaiseTravelRequest_BAL(int reqid, int empId, string location_from, string location_to)
        {
            Trequest.RaiseTravelRequest_DAL(reqid,empId,location_from,location_to);
            return 1;
        }
       
        public int ViewTravelRequest_BAL()
        {
            Trequest.ViewTravelRequest_DAL();
            return 1;
        }
        public int DeleteRequest_BAL(int reqid)
        {
            Trequest.DeleteRequest_DAL(reqid);
            return 1;
        }
        public int ApproveRequest_BAL(int req_Id, Approve_Enum appstatus)
        {
            Trequest.ApproveRequest_DAL(req_Id,appstatus);
            return 1;
        }
        public TravelRequest GetTravelRequestById_BAL(int reqId)
        {
            TravelRequest travel = Trequest.GetRequestById_DAL(reqId);
            return travel;
        }
        public int ViewJionReqTable_BAL()
        {
            Trequest.ViewJionReqTable_DAL();
            return 1;
        }
        public void EditTravelRequest_BAL(TravelRequest treq_to_change)
        {
            Trequest.EditTravelRequest_DAL(treq_to_change);
         
        }

        public int ConfirmRequest_BAL(int req_Id, Booking_Enum bookstatus)
        {
            Trequest.ConfirmRequest_DAL(req_Id,(Booking_Enum )bookstatus);
            return 1;
        }
        public int ViewTravelRequestApproveOpen_BAL()
        {
            Trequest.ViewTravelRequestApproveOpen_DAL();
            return 1;
        }
        public int ViewTravelRequestPending_BAL()
        {
            Trequest.ViewTravelRequestPending_DAL();
            return 1;
        }
        public int ViewTravelByLocFrom_BAL(string loca_from)
        {
            Trequest.ViewTravelByLocFrom_DAL(loca_from);
            return 1;
        }
        public int ViewTravelByLocTo_BAL(string loca_to)
        {
            Trequest.ViewTravelByLocTo_DAL(loca_to);
            return 1;
        }
    }
}
