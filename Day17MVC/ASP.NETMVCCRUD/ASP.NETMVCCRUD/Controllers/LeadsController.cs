using ASP.NETMVCCRUD.Data;
using ASP.NETMVCCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ASP.NETMVCCRUD.Controllers
{
    public class LeadsController : Controller
    {
        public IActionResult Index()
        {
            List<LeadsEntity> leads = new List<LeadsEntity>();
            LeadRepository leadRepository = new LeadRepository();
            leads = leadRepository.GetAllLeads();
            return View(leads);
        }
        public IActionResult AddLead()
        {
            return View();
        }
        public ActionResult AddNewLead(LeadsEntity lead)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    LeadRepository leadRepository = new LeadRepository();
                    if (leadRepository.AddLead(lead))
                    {
                        return RedirectToAction("Index"); // Redirect to the desired action upon successful addition
                    }
                }
                // If model state is invalid or lead addition fails, return the view with the lead model to display errors or re-enter data
                return View(lead);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return View();
            }
        }
        public IActionResult EditLead(int Id)
        {
            LeadsEntity lead = new LeadsEntity();
            LeadRepository leadRepository = new LeadRepository();
            lead = leadRepository.GetLeadById(Id);
            return View(lead); // Ensure the view name matches the action name ('Edit.cshtml')
        }
        public IActionResult EditLeadDetails(int Id, LeadsEntity lead)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LeadRepository leadRepository = new LeadRepository();
                    if (leadRepository.EditLeadDetails(Id, lead))
                    {
                        return RedirectToAction("Index"); // Redirect to the desired action upon successful update
                    }
                }
                // If model state is invalid or lead update fails, return the view with the lead model to display errors or re-enter data
                return View(lead); // Ensure the view name matches the action name ('EditLeadDetails.cshtml')
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        public IActionResult DeleteLead(int Id)
        {
           
            LeadsEntity lead = new LeadsEntity();
            LeadRepository leadRepository = new LeadRepository();
            lead = leadRepository.GetLeadById(Id);
            return View(lead);
        }

        public IActionResult DeleteLeadDetails(int Id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LeadRepository leadRepository = new LeadRepository();
                    if (leadRepository.DeleteLeadDetails(Id))
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        // Handle case when deletion fails
                        // You can provide an error message or display an error view
                        return RedirectToAction("Error");
                    }
                }
                else
                {
                    // Handle invalid model state, perhaps return the view with validation errors
                    return View();
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.Message);

                // Redirect to an error view or show a generic error message
                return RedirectToAction("Error");
            }
        }


    }

}
