using CompanyT.Models;
using CompanyT.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;

namespace CompanyT.Pages
{
    public class IndexModel : PageModel
    {
        ApplicationContext context;
        public IndexModel(ApplicationContext db)
        {
            context = db;
        }
        public List<Company> Сompanies;
        [BindProperty]
        public Company newCompany { get; set; }

        public void OnGet()
        {

            Сompanies = CompaniesServices.GetCompanies(context);
        }

        public IActionResult OnPostAdd()
        {
            CompaniesServices.AddCompany(newCompany, context);
            return RedirectToPage("Index");
        }
    }
}