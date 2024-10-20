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
    [Authorize(Roles ="Admin2")]
    public class DonerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DonerController(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> See_doners(int id)
        {
            //var doners = await _context.Doners.Where(d => d.donateOrgan == organ).ToListAsync();
            //return View(doners);

            var doner =  _context.Doners.Find(id);
            if (doner == null)
            {
                return NotFound();
            }
            ViewBag.organ = doner.donateOrgan.ToString();
            var donersWithSameOrgan = _context.Doners
                                              .Where(d => d.donateOrgan == doner.donateOrgan)
                                              .ToList();

            return View(donersWithSameOrgan);
        }

        // GET: Admin/Doner
        public async Task<IActionResult> Index()
        {
            return View(await _context.Doners.ToListAsync());
        }

        // GET: Admin/Doner/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doner = await _context.Doners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doner == null)
            {
                return NotFound();
            }

            return View(doner);
        }

        // GET: Admin/Doner/Create
        public IActionResult Create()
        {
            ViewBag.Gender = new SelectList(Enum.GetValues(typeof(Gender)).Cast<Gender>());
            ViewBag.Organ = new SelectList(Enum.GetValues(typeof(Organ)).Cast<Organ>());

            return View();
        }

        // POST: Admin/Doner/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Age,Gender,PhoneNumber,DOB,donateOrgan,BloodType")] Doner doner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doner);
        }

        // GET: Admin/Doner/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doner = await _context.Doners.FindAsync(id);
            if (doner == null)
            {
                return NotFound();
            }

            ViewBag.Gender = new SelectList(Enum.GetValues(typeof(Gender)).Cast<Gender>());
            ViewBag.Organ = new SelectList(Enum.GetValues(typeof(Organ)).Cast<Organ>());

            return View(doner);
        }

        // POST: Admin/Doner/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Age,Gender,PhoneNumber,DOB,donateOrgan,BloodType")] Doner doner)
        {
            ViewBag.Gender = new SelectList(Enum.GetValues(typeof(Gender)).Cast<Gender>());
            ViewBag.Organ = new SelectList(Enum.GetValues(typeof(Organ)).Cast<Organ>());
            if (id != doner.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonerExists(doner.Id))
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

            return View(doner);
        }

        // GET: Admin/Doner/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doner = await _context.Doners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doner == null)
            {
                return NotFound();
            }

            return View(doner);
        }

        // POST: Admin/Doner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doner = await _context.Doners.FindAsync(id);
            if (doner != null)
            {
                _context.Doners.Remove(doner);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonerExists(int id)
        {
            return _context.Doners.Any(e => e.Id == id);
        }
    }
}
