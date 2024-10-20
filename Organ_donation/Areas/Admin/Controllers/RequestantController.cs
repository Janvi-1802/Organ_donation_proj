using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Organ_donation.Models;

namespace Organ_donation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin2")]
    public class RequestantController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RequestantController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Available_doners(int id)
        {
            var requestant = _context.Requestants.Find(id);
            if (requestant == null)
            {
                return NotFound();
            }

            ViewBag.Organ = requestant.AskOrgan.ToString();

            var donersWithSameOrgan = _context.Doners
                                              .Where(d => d.donateOrgan == requestant.AskOrgan)
                                              .Select(d => new DonerViewModel
                                              {
                                                  Id = d.Id,
                                                  Name = d.Name,
                                                  Age = d.Age,
                                                  Gender = d.Gender,
                                                  PhoneNumber = d.PhoneNumber,
                                                  DOB = d.DOB,
                                                  Organ = d.donateOrgan,
                                                  BloodType = d.BloodType,
                                                  IsMatch = d.BloodType == requestant.BloodType
                                              })
                                              .ToList();

            return View(donersWithSameOrgan);
            //return View(await _context.Requestants.ToListAsync());
        }


        // GET: Admin/Requestant
        public async Task<IActionResult> Index()
        {
            return View(await _context.Requestants.ToListAsync());
        }

        // GET: Admin/Requestant/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestant = await _context.Requestants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requestant == null)
            {
                return NotFound();
            }

            return View(requestant);
        }

        // GET: Admin/Requestant/Create
        public IActionResult Create()
        {

            ViewBag.Gender = new SelectList(Enum.GetValues(typeof(Gender)).Cast<Gender>());
            ViewBag.Organ = new SelectList(Enum.GetValues(typeof(Organ)).Cast<Organ>());

            return View();
        }

        // POST: Admin/Requestant/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Age,Gender,PhoneNumber,DOB,AskOrgan,BloodType")] Requestant requestant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(requestant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(requestant);
        }

        // GET: Admin/Requestant/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestant = await _context.Requestants.FindAsync(id);
            if (requestant == null)
            {
                return NotFound();
            }

            ViewBag.Gender = new SelectList(Enum.GetValues(typeof(Gender)).Cast<Gender>());
            ViewBag.Organ = new SelectList(Enum.GetValues(typeof(Organ)).Cast<Organ>());

            return View(requestant);
        }

        // POST: Admin/Requestant/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Age,Gender,PhoneNumber,DOB,AskOrgan,BloodType")] Requestant requestant)
        {
            if (id != requestant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requestant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestantExists(requestant.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(requestant);
        }

        // GET: Admin/Requestant/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestant = await _context.Requestants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requestant == null)
            {
                return NotFound();
            }

            return View(requestant);
        }

        // POST: Admin/Requestant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var requestant = await _context.Requestants.FindAsync(id);
            if (requestant != null)
            {
                _context.Requestants.Remove(requestant);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestantExists(int id)
        {
            return _context.Requestants.Any(e => e.Id == id);
        }
    }
}
