using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DanskeByer.Data;
using DanskeByer.Models;

namespace DanskeByer.Pages.Cities
{
    public class EditModel : PageModel
    {
        private readonly DanskeByer.Data.CityContext _context;

        public EditModel(DanskeByer.Data.CityContext context)
        {
            _context = context;
        }

        [BindProperty]
        public City City { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            City = await _context.City.FirstOrDefaultAsync(m => m.Id == id);

            if (City == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(City).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityExists(City.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CityExists(int id)
        {
            return _context.City.Any(e => e.Id == id);
        }
    }
}
