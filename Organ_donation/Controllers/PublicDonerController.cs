using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Organ_donation.Models;

namespace Organ_donation.Controllers
{
    public class PublicDonerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PublicDonerController(ApplicationDbContext context)
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
        public async Task<IActionResult> Create([Bind("Id,Name,Age,Gender,PhoneNumber,DOB,donateOrgan,BloodType")] Doner doner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doner);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","Home");
            }
            return View(doner);
        }
    }
}
