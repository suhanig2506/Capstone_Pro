using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Final_Pro
{
    public enum Approve_Enum { Approved, Not_Approved,Pending };
    public enum Booking_Enum { Available, Not_Available,Pending };

    public enum Current_Enum { open, close };
    public class TravelRequest
    {

        public int reqid { get; set; }
        public string location_from { get; set; }
        public string location_to { get; set; }

        public int empid { get; set; }
        public Approve_Enum Approved_Status  { get; set; }
        public Booking_Enum Booking_Status { get; set; }

        public Current_Enum Current_Status{ get; set; }


        public override string ToString()
        {
            return string.Format("{0,-10} {1,-10} {2,-10} {3,-10} {4,-10} {5,-10} {6,-10}  "
     , reqid,empid, location_from, location_to, Approved_Status,Booking_Status,Current_Status);
            
            
            
        }


    }
}
