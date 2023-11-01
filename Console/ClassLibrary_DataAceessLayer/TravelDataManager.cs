using Final_Pro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibrary_DataAceessLayer
{
    
    public class TravelDataManager:IReqDataManager
    {
        EmpDataManager empDataManager = new EmpDataManager();
        public List<TravelRequest> Requests = new List<TravelRequest>()
        {
            new TravelRequest() {reqid = 1,empid=2,location_from="Pune",location_to="mumbai", Approved_Status= Approve_Enum.Pending,Booking_Status= Booking_Enum.Pending,Current_Status=Current_Enum.open},
             new TravelRequest() {reqid = 3,empid=4,location_from="Delhi",location_to="Pune",Approved_Status= Approve_Enum.Pending,Booking_Status= Booking_Enum.Pending,Current_Status=Current_Enum.open}
        };

        public int RaiseTravelRequest_DAL(int reqid, int empId, string location_from, string location_to)
        {
            Requests.Add(new TravelRequest() { reqid = reqid, empid = empId, location_from = location_from, location_to = location_to, Approved_Status = Approve_Enum.Pending, Booking_Status = Booking_Enum.Pending, Current_Status = Current_Enum.open });
            //Console.WriteLine(Treq.ToString());
            return 1;
            //
        }
        public int  ViewTravelRequest_DAL()
        {
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                          View Travel Request");
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,-12} {1,-10} {2,-10} {3,-12} {4,-20} {5,-20} {6,-20}", "Req Id", "Emp Id", "location_from","location_to" ,"Approved_Status","Booking_Status","Current_Status");
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            foreach (TravelRequest req in Requests)
            {
                Console.WriteLine(req.ToString());
                //Console.WriteLine(req.reqid);
            }
            return 1;
        }
        public int EditRequest_DAL(TravelRequest treq)
        {
            Console.WriteLine("In-Edit DAL");
            return 1;
        }
        public int DeleteRequest_DAL(int reqid)
        {
            ViewTravelRequest_DAL();
            var reqDel=Requests.Remove(Requests.FirstOrDefault(travel=>travel.reqid == reqid));
            Console.WriteLine("Request With ReqID Deleted ="+ reqid);
            ViewTravelRequest_DAL();
            //Console.WriteLine("IN- delete");
            return 1;
        }
         public TravelRequest GetRequestById_DAL(int reqId)
        {
            TravelRequest travel=Requests.FirstOrDefault(t=>t.reqid == reqId);
            if (travel != null)
            {
                return travel;
            }
            return null;
        }
        public int EditTravelRequest_DAL(TravelRequest travel)
        {
            ViewTravelRequest_DAL();
            TravelRequest trav_main=Requests.FirstOrDefault(X => X.reqid == travel.reqid);
            int index = Requests.IndexOf(trav_main);
            Requests[index].empid= travel.empid;
            Requests[index].location_from = travel.location_from;
            Requests[index].location_to= travel.location_to;
            return 1;
        }
        public int ApproveRequest_DAL(int req_Id, Approve_Enum appstatus)
        {
            Console.WriteLine("Employee with  reqId {0} Booking Confirmed!!!", req_Id);
            TravelRequest approveR = Requests.FirstOrDefault(x => x.reqid == req_Id);
            int index = Requests.IndexOf(approveR);
            if (approveR != null)
            {
                
                Requests[index].Approved_Status = appstatus;
                Requests[index].Current_Status = Current_Enum.open;
                //ViewTravelRequest_DAL();
            }
            return 1;
            
        }
        public int ViewJionReqTable_DAL()
        {
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                                                                          View All Travel Request                                                                                                     ");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-10} {4,-10} {5,-10} {6,-10} {7,-14} ", "| Req Id |", "| Emp Id |", "| Emp Name |", "| locaton_From |", "| location_to |", "| Approved_Status |", "| Booking_Status |", "| Current Status |");
            var querymethodview = from emp in empDataManager.lstEmployees
                                  join req in Requests
                                  on emp.empId equals req.empid
                                  select new
                                  {
                                      Reqid = req.reqid,
                                      EId = emp.empId,
                                      EName = emp.EmpName,
                                      Loc_F = req.location_from,
                                      Loc_T = req.location_to,
                                      App_St = req.Approved_Status,
                                      Book_st = req.Booking_Status,
                                      Curr_St = req.Current_Status,

                                  };
            foreach( var emp in querymethodview )
            {
                Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-10} {4,-10} {5,-10} {6,-10} {7,-14} ", emp.EId , emp.Reqid, emp.EName, emp.Loc_F, emp.Loc_T, emp.App_St, emp.Book_st, emp.Curr_St);
            }
            return 1;
        }
        public int ConfirmRequest_DAL(int req_Id, Booking_Enum bookstatus)
        {
            Console.WriteLine("Employee with  reqId {0} Booking Confirmed!!!", req_Id);
            var querymethodconfirm=Requests.FirstOrDefault(travelreq=>travelreq.reqid == req_Id);   
            TravelRequest approveR = Requests.FirstOrDefault(x => x.reqid==req_Id);
            int index = Requests.IndexOf(approveR);
            if (approveR != null)
            {

                Requests[index].Booking_Status = bookstatus;
                Requests[index].Current_Status =Current_Enum.close ;
                ViewTravelRequest_DAL() ;

            }
            else
            {
                Console.WriteLine("\n Travel Request has not been approved yet!!..");
            }
            if (querymethodconfirm.Booking_Status == Booking_Enum.Available || querymethodconfirm.Booking_Status == Booking_Enum.Not_Available)
            {
                querymethodconfirm.Current_Status=Current_Enum.close ;
            }
            return 1;
        }
        public int ViewTravelRequestApproveOpen_DAL()
        {
            //var querymethodbook = Requests.FirstOrDefault(travelreq => travelreq.
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                          View Travel Request");
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,-12} {1,-10} {2,-10} {3,-12} {4,-20} {5,-20} {6,-20}", "Req Id", "Emp Id", "location_from", "location_to", "Approved_Status", "Booking_Status", "Current_Status");
            Console.WriteLine("--------------------------------------------------------------------------------------------------");

            foreach (TravelRequest req in Requests)
            {
                if (req.Approved_Status == Approve_Enum.Approved )
                {
                    Console.WriteLine(req.ToString());
                    //Console.WriteLine(req.reqid);
                }
            }
            return 1;
        }
        public int ViewTravelByLocFrom_DAL(string loca_from)
        {
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                          View Travel Request");
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,-12} {1,-10} {2,-10} {3,-12} {4,-20} {5,-20} {6,-20}", "Req Id", "Emp Id", "location_from", "location_to", "Approved_Status", "Booking_Status", "Current_Status");
            Console.WriteLine("--------------------------------------------------------------------------------------------------");

            foreach (TravelRequest req in Requests)
            {
                if (req.location_from.ToLower() == loca_from.ToLower())
                {
                    Console.WriteLine(req.ToString());
                    //Console.WriteLine(req.reqid);
                }       
               
            }
            Console.WriteLine("Enter Location_From Not Found");
            return 1;
        }
        public int ViewTravelByLocTo_DAL(string loca_to)
        {
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                          View Travel Request");
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,-12} {1,-10} {2,-10} {3,-12} {4,-20} {5,-20} {6,-20}", "Req Id", "Emp Id", "location_from", "location_to", "Approved_Status", "Booking_Status", "Current_Status");
            Console.WriteLine("--------------------------------------------------------------------------------------------------");

            foreach (TravelRequest req in Requests)
            {
                if (req.location_to.ToLower() == loca_to.ToLower())
                {

                    Console.WriteLine(req.ToString());
                    //Console.WriteLine(req.reqid);
                }




            }
            Console.WriteLine("Enter Location_To Not Found");
            return 1;
        }
        public int ViewTravelRequestPending_DAL()
        {
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                          View Travel Request");
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,-12} {1,-10} {2,-10} {3,-12} {4,-20} {5,-20} {6,-20}", "Req Id", "Emp Id", "location_from", "location_to", "Approved_Status", "Booking_Status", "Current_Status");
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            
            foreach (TravelRequest req in Requests)
            {
                if (req.Approved_Status == Approve_Enum.Pending)
                {
                    Console.WriteLine(req.ToString());
                    //Console.WriteLine(req.reqid);
                }
            }
            return 1;

            //return 1;
        }
    }
}
