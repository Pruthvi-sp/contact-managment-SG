using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContactManagement.Data;
using ContactManagement.Models;
using System.Collections.Concurrent;

namespace ContactManagement.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ContatsContext _context;

        public ContactsController(ContatsContext context)
        {
                      _context = context;
        }

        // GET: ContactsModels
        public async Task<IActionResult> Index()
        {
            _context.Add(new ContactsModel { FirstName = "Item1", LastName = "121212", HomeNumber = "12121221", MobileNumber = 89719827, PersonalNumber = "8767867868", ProfessionalNumber = "12121212" });
            return View(await _context.Contacts.ToListAsync());
        }

        // GET: ContactsModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactsModel = await _context.Contacts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactsModel == null)
            {
                return NotFound();
            }

            return View(contactsModel);
        }

        // GET: ContactsModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContactsModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,PersonalNumber,ProfessionalNumber,HomeNumber,MobileNumber")] ContactsModel contactsModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contactsModel);
        }

        // GET: ContactsModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactsModel = await _context.Contacts.FindAsync(id);
            if (contactsModel == null)
            {
                return NotFound();
            }
            return View(contactsModel);
        }

        // POST: ContactsModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,PersonalNumber,ProfessionalNumber,HomeNumber,MobileNumber")] ContactsModel contactsModel)
        {
            if (id != contactsModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactsModelExists(contactsModel.Id))
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
            return View(contactsModel);
        }

        // GET: ContactsModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactsModel = await _context.Contacts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactsModel == null)
            {
                return NotFound();
            }

            return View(contactsModel);
        }

        // POST: ContactsModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactsModel = await _context.Contacts.FindAsync(id);
            _context.Contacts.Remove(contactsModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactsModelExists(int id)
        {
            return _context.Contacts.Any(e => e.Id == id);
        }
    }


}
