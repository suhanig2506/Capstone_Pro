using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TravelBooking_NewMVC.Models;
using TravelBooking_NewMVC.Repository;

namespace TravelBooking_NewMVC.Controllers
{
    public class TravelRequestController : Controller
    {
        private readonly ITravelRepository _trepository;
        private readonly IEmployeeRepository _repository;
        public TravelRequestController(ITravelRepository trepository, IEmployeeRepository repository)
        {
            _trepository = trepository;
            _repository = repository;
        }
        public IActionResult Index()
        {
            IEnumerable<TravelRequest> travelRequests = _trepository.GetTravelReq();
            
            return View(travelRequests);
        }
        public IActionResult RaiseRequest()
        {
            ViewBag.Employees = new SelectList(_repository.GetEmployees(), "EmpId", "EmpId");
            return View();
        }
        [HttpPost]
        public IActionResult RaiseRequest(TravelRequest travelRequest)
        {
            if (ModelState.IsValid)
            {
                _trepository.RaiseRequest(travelRequest);
            }
            return RedirectToAction("Index");
        }
        public IActionResult DeleteRequest(int id)
        {
            _trepository.DeleteRequest(id);
            return RedirectToAction("Index");
        }
        
        public IActionResult UpdateRequest(int id)
        {
            TravelRequest? travelRequest = _trepository.GetRequestById(id);
            ViewBag.Employees = new SelectList(_repository.GetEmployees(), "EmpId", "EmpFirstName");
            if(travelRequest != null)
            {
                return View(travelRequest);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult UpdateRequest(TravelRequest travelRequest, int id)
        {
            if (ModelState.IsValid)
            {
                
                _trepository.UpdateRequest(travelRequest, id);

            }
            return RedirectToAction("Index");
        }
        public IActionResult ApproveTravelRequest(int id)
        {
            TravelRequest tr=_trepository.GetRequestById(id);
            return View(tr);
        }

        [HttpPost]
        public IActionResult ApproveTravelRequest(int id, string ApprovalStatus)
        {
            if (ModelState.IsValid)
            {
                _trepository.ApproveTravelRequest(id, ApprovalStatus);
            }
            return RedirectToAction("Index");
        }

        public IActionResult BookTravelRequest(int id)
        {
            TravelRequest tr = _trepository.GetRequestById(id);
            return View(tr);
        }

        [HttpPost]
        public IActionResult BookTravelRequest(int id, string BookingStatus)
        {
            if (ModelState.IsValid)
            {
                _trepository.BookTravelRequest(id, BookingStatus);
            }
            return RedirectToAction("Index");
        }
        

    }
}

