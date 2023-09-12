using CompanyT.Models;
using CompanyT.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;

namespace CompanyT.Pages
{
    [IgnoreAntiforgeryToken]
    public class CompanyDetailsModel : PageModel
    {
        ApplicationContext context;
        public CompanyDetailsModel(ApplicationContext db)
        {
            context = db;
        }
        public List<Company> Ñompanies;
        public List<Notes> notes;
        public Company company;
        public int _id;
        [BindProperty]
        public Company newCompany { get; set; }
        
        public string? url, jCompany, jNotes;

        public void OnGet(int Id)
        {
            //_id = Id;
            url = Url.Page("CompanyDetails", "Company", new { id = Id });
            //Ñompanies = CompaniesServices.GetCompanies(context);
            //company = CompaniesServices.GetCompanyById(Id, context);
        }

        public IActionResult OnGetCompany(int Id) 
        {

            company = CompaniesServices.GetCompanyById(Id, context);
            
            jCompany = JsonConvert.SerializeObject(company);

            return Content(jCompany);
        }
        public void OnPostCompany(int Id = 1) 
        {
            company = CompaniesServices.GetCompanyById(Id, context);
        }
        public IActionResult OnGetNotes(int Id)
        {
            notes = NotesServices.GetNotes(Id, context);
            
            jNotes = JsonConvert.SerializeObject(notes);

            return Content(jNotes);
        }
    }
}
