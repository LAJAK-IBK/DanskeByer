using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DanskeByer.Data;
using DanskeByer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DanskeByer.Pages.Cities
{
    public class IndexModel : PageModel
    {
        private readonly DanskeByer.Data.CityContext _context;
        private readonly IConfiguration _configuration;

        public IndexModel(DanskeByer.Data.CityContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public string NameSort { get; set; }
        public string PopSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<City> City { get;set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            PopSort = sortOrder == "population" ? "population_desc" : "population";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else 
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<City> citiesIQ = from s in _context.City
            select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                citiesIQ = citiesIQ.Where(s => s.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    citiesIQ = citiesIQ.OrderByDescending(s => s.Name);
                    break;
                case "population":
                    citiesIQ = citiesIQ.OrderBy(s => s.Population);
                    break;
                case "population_desc":
                    citiesIQ = citiesIQ.OrderByDescending(s => s.Population);
                    break;
                default:
                    citiesIQ = citiesIQ.OrderBy(s => s.Name);
                    break;
            }

            var pageSize = _configuration.GetValue("PageSize", 4);
            City = await PaginatedList<City>.CreateAsync(
                citiesIQ.AsNoTracking(), pageIndex ?? 1, pageSize);

            //City = await citiesIQ.AsNoTracking().ToListAsync();
        }
    }
}
