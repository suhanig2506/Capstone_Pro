using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary_BusinessAcessLayer;
using Final_Pro;

namespace ClassLibrary_MainMenu
{
    public class MainMenu
    {
        private static readonly EmployeeBAL _empManager= new EmployeeBAL();
        private static readonly TravelBAL _travelManager= new TravelBAL();

        public static void showmenu()
        {
            bool continueMenu = true;
            try
            {
                do
                {

                    int choice;
                    Console.WriteLine("===================MAIN MENU======================");
                    Console.WriteLine("1. Manage Employee\n2. Manage Travel Request\n3.Exit");
                    Console.WriteLine("Enter Choice ");
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)

                    {
                        case 1:
                            Console.WriteLine("============Manage Employee=================");
                            ShowEmployeeMenu();
                            break;
                        case 2:
                            Console.WriteLine("================Manage Travel Request==============");
                            ShowTravelMenu();
                            break;
                        case 3:
                            Environment.Exit(0);
                            continueMenu = false;
                            break;
                        default:
                            Console.WriteLine("Wrong Choice");
                            break;
                    }
                    Console.WriteLine("Do you want to continue? (y/n)");
                    char response = Console.ReadKey().KeyChar;
                    Console.WriteLine("\n");
                    continueMenu = (response == 'y' || response == 'Y');
                }
                while (continueMenu);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Please enter correct choice:");
                Console.WriteLine(ex.Message);
            }
        }
        //Employee
        public static void ShowEmployeeMenu()
        {
            int choice;
            bool continueMenu = true;
            try
            {
                do
                {
                    Console.WriteLine("1.Add Employee\n2.Edit Employee\n3.Delete Employee\n4.View Employee\n5.Go Back");
                    Console.WriteLine("Enter Your Choice?");
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            //Console.WriteLine("Add Employee");
                            AddEmployee();
                            break;

                        case 2:
                            //Console.WriteLine("Edit Employee");
                            EditEmployee();
                            break;
                        case 3:
                            //Console.WriteLine("Delete Employee");
                            DeleteEmployee();
                            break;
                        case 4:
                            //Console.WriteLine("View Employee");
                            ViewEmployee();
                            break;
                        case 5:
                            Console.WriteLine("Go Back");
                            MainMenu.showmenu();
                            break;
                        case 6:
                            Console.WriteLine("Exit....");
                            Environment.Exit(0);
                            continueMenu = false;
                            break;
                        default:
                            Console.WriteLine("Wrong Choice");
                            break;
                    }

                    Console.WriteLine("Do you want to continue? (y/n)");
                    char response = Console.ReadKey().KeyChar;
                    Console.WriteLine("\n");
                    continueMenu = (response == 'y' || response == 'Y');

                }
                while (continueMenu);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Please Enter Correct Choice");
                Console.WriteLine(ex.Message);
            }
        

        }
        public static void AddEmployee()
        {
            int empId, contact;
            string empName, Address;
            DateTime dob;



            Console.WriteLine("****************************** ADD EMPLOYEE INFO ********************************************");

            Console.WriteLine("Enter Employee Name Here:");
            empId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Employee_Name:");
            empName = Console.ReadLine();
            //Console.WriteLine("Enter Last_Name");
            //LName = Console.ReadLine();
            Console.WriteLine("Enter date of birth");
            dob = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter Address");
            Address = Console.ReadLine();
            Console.WriteLine("Enter Contact Number Here");
            contact = int.Parse(Console.ReadLine());

            _empManager.AddEmployee_BAL(empId, empName, Address,dob,contact);
            
        }

        static void EditEmployee()

        {
            int contact,e_Id,num1;
            string EmpName, Address;
            DateTime dob;

            Console.WriteLine("************************************* EDIT EMPLOYEE INFO ***************************************");

            _empManager.ViewEmployee_BAL();

            Console.WriteLine("Enter Emp Id to Edit");
            e_Id = int.Parse(Console.ReadLine());

            Employee emp_to_change = _empManager.GetEmployeeById(e_Id);

            _empManager.EditEmployee_BAL(emp_to_change);
           

            while (true)
            {


                    Console.WriteLine("1.Emp Name\n2.Dob\n3.Address\n4.Contact");
                    num1 = int.Parse(Console.ReadLine());
                    switch (num1)
                    {
                        case 1:
                            Console.WriteLine("Edit Employee First Name:");
                            EmpName = (Console.ReadLine());
                            emp_to_change.EmpName = EmpName;
                            break;

                        case 2:
                            Console.WriteLine("Edit Date Of Birthday");
                            dob = DateTime.Parse(Console.ReadLine());
                            emp_to_change.dob = dob;
                            break;
                        case 3:
                            Console.WriteLine("Edit Address Of Employee:");
                            Address = Console.ReadLine();
                            emp_to_change.Address = Address;
                            break;
                        case 4:
                            Console.WriteLine("Edit Contact Number Of Employee");
                            contact = int.Parse(Console.ReadLine());
                            emp_to_change.Contact = contact;
                            break;
                        case 5:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Wrong Choice");
                            break;

                    }
                _empManager.ViewEmployee_BAL();

            }

        }

        static void DeleteEmployee()
        {
            int empId;
            //Program Employee2 = new Program();
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("*********************DELETE EMPLOYEE INFORMATION************************");
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("Enter Employee Id to delete The info:");
            empId = int.Parse(Console.ReadLine());
            Console.WriteLine("Information Of Employee having id {0} is deleted", empId);

            _empManager.DeleteEmployee_BAL(empId);
        }

        static void ViewEmployee()
        {

            _empManager.ViewEmployee_BAL();
            Console.WriteLine("===================================Show All Employee Here=====================================");
        }

        //travel
        public static void RaiseTravelRequest()

        {
            // manage = new Program();

            int reqId, empId;

            string location_from, location_to;// Approved_Status, Booking_Status, Current_Status;
                                              // Console.WriteLine("Raise travel request ");
            //ViewJionReqTable_BAL();
            Console.WriteLine("Enter request id:");
            reqId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter employee id:");
            empId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter location form:");
            location_from = Console.ReadLine();
            Console.WriteLine("Enter location to:");
            location_to = Console.ReadLine();
            //Console.WriteLine("Your Approved Status");
            //Approved_Status = Console.ReadLine();
            //Console.WriteLine("Your approve status is:" );
            //Booking_Status = Console.ReadLine();    
            //Console.WriteLine("Your Request status is:" );
            //Current_Status = Console.ReadLine() ;
           // Console.WriteLine("Your approve status is:" + Request_Status);
            
            _travelManager.RaiseTravelRequest_BAL(reqId, empId, location_from, location_to);



        }
        static void ViewTraRequest()
        {
            Console.WriteLine("View All Employee Here!");
            Console.WriteLine("************************");
            //_travelManager.ViewTravelRequest_BAL();
            _travelManager.ViewJionReqTable_BAL();
        }
        static void DeleteRequest()
        {
            int reqId;
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("                 Delete Request                                  ");
            //Console.WriteLine("-----------------------------------------------------------------");                                                               ");
            Console.WriteLine("Enter Request Id to delete The Request");
            reqId = int.Parse(Console.ReadLine());
            Console.WriteLine("Travel Request Having reqId {0} is Deleted", reqId);
            _travelManager.DeleteRequest_BAL(reqId);

        }
        static void ConfirmTravelReq()
        {
            _travelManager.ViewTravelRequestApproveOpen_BAL();
            Console.WriteLine("1.Approve\n2.Not_Approved");
            int choice1;
            choice1 = int.Parse(Console.ReadLine());
            Booking_Enum Book = Booking_Enum.Not_Available;
            switch (choice1)
            {
                case 1:
                    Book = Booking_Enum.Available;
                    break;
                case 2:
                    Book= Booking_Enum.Not_Available;
                    break;
                
 
            }
            Console.WriteLine("Enter Req Id To Change Status:");
            int r_id=int.Parse(Console.ReadLine());
            _travelManager.ConfirmRequest_BAL(r_id, Book);

        }
        static void EditTravelRequest()
        {
            int EmpId, r_id, num1;
            string location_from, location_to;
            
            Console.WriteLine("********Edit Request*******");
            _travelManager.ViewTravelRequest_BAL();
            Console.WriteLine("Enter Request Id to Edit");
            r_id = int.Parse(Console.ReadLine());
            TravelRequest treq_to_change = new TravelRequest();
            treq_to_change = _travelManager.GetTravelRequestById_BAL(r_id);

            
            while (true)
            {
                Console.WriteLine("1.EMPId\n2.location_From\n3.location_To");
                num1 = int.Parse(Console.ReadLine());
                switch (num1)
                {
                    case 1:
                        Console.WriteLine("Edit Emp Id:");
                        EmpId = int.Parse(Console.ReadLine());
                        treq_to_change.empid = EmpId;
                        break;
                    case 2:
                        Console.WriteLine("Edit Location From");
                        location_from = Console.ReadLine();
                        treq_to_change.location_from = location_from;
                        break;
                    case 3:
                        Console.WriteLine("Enter Location_To:");
                        location_to = Console.ReadLine();
                        treq_to_change.location_to = location_to;
                        break;
                }
                _travelManager.EditTravelRequest_BAL(treq_to_change);
                _travelManager.ViewTravelRequest_BAL();
            }     
        }
        static void ApproveTravelReq()
        {
            _travelManager.ViewTravelRequestPending_BAL();
            Console.WriteLine("1.Approve\n2.Not_Approved\n3.Pending");
            int choice;
            choice = int.Parse(Console.ReadLine());
            Approve_Enum App_1 = Approve_Enum.Approved;
            //Booking_Enum Book_1 = Booking_Enum.Available;
            switch (choice)
            {
                case 1:
                    App_1= Approve_Enum.Approved;
                    break;
                case 2:
                    App_1 = Approve_Enum.Not_Approved;
                    break;
                default:
                    App_1 = Approve_Enum.Pending;
                    break;     
            }
            Console.WriteLine("Enter Req ID To Change Approve Status");
            int r_id=int.Parse (Console.ReadLine());
            _travelManager.ApproveRequest_BAL(r_id, App_1);
            ViewTraRequest();
        }
        public static void ViewByLocFrom(string loca_from)
        {
            //string loca_from;
            
            _travelManager.ViewTravelByLocFrom_BAL(loca_from);

        }
        public static void ViewByLocTo(string loca_To)
        {
            _travelManager.ViewTravelByLocTo_BAL(loca_To);
        }
        public static void ShowTravelMenu()
        {
            int choice;
            bool continueMenu = true;
            do
            {
                Console.WriteLine("1.Raise Travel Request\n2.View Travel Request\n3.Delete Travel Request\n4.Approve Travel Request\n5.Confirm_Booking\n6.EditTravelRequest\n7.ViewByLoc_From\n8.ViewByLocTo\n9.Go Back");
                Console.WriteLine("Select a Choice");
                choice = int.Parse(Console.ReadLine());
                //
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Raise Travel Request");
                        RaiseTravelRequest();
                        break;
                    case 2:
                        Console.WriteLine("View Travel Request");
                        ViewTraRequest();
                        break;
                    case 3:
                        Console.WriteLine("Delete travel request");
                        DeleteRequest();

                        break;
                    case 4:
                        Console.WriteLine("Approve travel Request");
                        ApproveTravelReq();
                        break;
                    case 5:
                        Console.WriteLine("Confirm Bokking");
                        ConfirmTravelReq();
                        break;

                    case 6:
                        Console.WriteLine("Edit Travel Request");
                        EditTravelRequest();
                        break;
                    case 7:
                        Console.WriteLine("Enter The Location_From TO Show By Location:");
                        string loca_from;
                        loca_from = Console.ReadLine();

                        ViewByLocFrom(loca_from);
                        break;
                    case 8:
                        Console.WriteLine("Enter The Location_From TO Show By Location:");
                        string loca_to;
                        loca_to = Console.ReadLine();
                        ViewByLocTo(loca_to);
                        break;


                    case 9:
                        Console.WriteLine("Go back");
                        MainMenu.showmenu();
                        break;
                    
                    default:
                        Console.WriteLine("wrong choice");
                        break;

                }
                Console.WriteLine("Do you want to continue? (y/n)");
                char response = Console.ReadKey().KeyChar;
                Console.WriteLine("\n");
                continueMenu = (response == 'y' || response == 'Y');
            }
            while (continueMenu);
            
        }

    }
}
