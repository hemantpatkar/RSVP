using Microsoft.AspNetCore.Mvc;
using Registration.Web.Models;
using Registration.Web.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Registration.Web.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;

        }
        // GET: Registration
        public async Task<ActionResult> Index()
        {

            List<RegistrationViewModel> contact = await _registrationService.GetRegistrationList("");
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }

        public async Task<ActionResult> Search(string search)
        {
            if (search == null)
            {
                search = "";
            }
            List<RegistrationViewModel> contact = await _registrationService.GetRegistrationList(search);
            if (contact == null)
            {
                return NotFound();
            }
            return View("Index", contact);
        }

        // GET: Registration/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            RegistrationViewModel contact = await _registrationService.GetRegistrationDetails(id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }

        // GET: Registration/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Registration/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RegistrationViewModel request)
        {
            if (ModelState.IsValid)
            {
                if (request == null)
                {
                    return BadRequest();
                }
                var contact = await _registrationService.AddRegistration(request);
                if (contact)
                {
                    Response.Redirect("Index");
                }
                else
                {
                    return NotFound();
                }
            }
            return View(request);

        }

        // GET: Registration/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            RegistrationViewModel contact = await _registrationService.GetRegistrationDetails(id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);

        }

        // POST: Registration/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(RegistrationViewModel request)
        {
            if (ModelState.IsValid)
            {
                if (request == null)
                {
                    return BadRequest();
                }
                var contact = await _registrationService.UpdateRegistration(request);
                if (!contact)
                {
                    return NotFound();
                }
            }
            return RedirectToAction("Index");
        }

        // GET: Registration/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var contact = await _registrationService.GetRegistrationDetails(id);

            return View(contact);
        }

        // POST: Registration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _registrationService.DeleteRegistration(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}