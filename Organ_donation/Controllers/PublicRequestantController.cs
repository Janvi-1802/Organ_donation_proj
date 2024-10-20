using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Organ_donation.Models;

namespace Organ_donation.Controllers
{
    public class PublicRequestantController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PublicRequestantController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            ViewBag.Gender = new SelectList(Enum.GetValues(typeof(Gender)).Cast<Gender>());
            ViewBag.Organ = new SelectList(Enum.GetValues(typeof(Organ)).Cast<Organ>());

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Age,Gender,PhoneNumber,DOB,donateOrgan,BloodType")] Requestant req)
        {
            if (ModelState.IsValid)
            {
                _context.Add(req);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(req);
        }

    }
}
