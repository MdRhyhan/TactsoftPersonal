using Microsoft.AspNetCore.Identity.UI.V5.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class RegistrationController : Controller 
    {
        private readonly IRegistrationService _registration;
        public RegistrationController(IRegistrationService registration)
        {
            _registration = registration;
        }

        public async Task <IActionResult> Index()
        {
            var registration = await _registration.GetAllAsync();
            return View(registration);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Create(Registration registration)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _registration.InsertAsync(registration);
                    TempData["successAlert"] = "Registration Save Successfull.";
                    return RedirectToAction("Index");
                }
                return View(registration);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task <IActionResult> Edit( int Id )
        {
            var reg = await _registration.FindAsync(Id);
            return View(reg);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Registration registration)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _registration.UpdateAsync(registration);
                    TempData["successAlert"] = "Registration Update Successfull.";
                    return RedirectToAction("Index");
                }
                return View(registration);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Details(int Id)
        {
            var reg = await _registration.FindAsync(Id);
            return View(reg);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var reg = await _registration.FindAsync(Id);
            return View(reg);
        }
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteCon(int Id)
        {
            try
            {
                var reg = await _registration.FindAsync(Id);
                if(Id != null)
                {
                    await _registration.DeleteAsync(reg);
                    TempData["successAlert"] = "Registration Delete Successfull.";
                    return RedirectToAction("Index");
                }
                return View(reg);
                    
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
