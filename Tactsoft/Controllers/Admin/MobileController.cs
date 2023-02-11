using Microsoft.AspNetCore.Mvc;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class MobileController : Controller
    {
        public readonly IMobileService _mobileService;
        public MobileController(IMobileService mobileService)
        {
            _mobileService = mobileService;
        }

        public async Task<IActionResult> Index()
        { 
            var mb= await _mobileService.GetAllAsync();
            return View(mb);
        }
    }
}
