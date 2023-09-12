using CompanyT.Models;
using System.Xml.Linq;

namespace CompanyT.Services
{
    public static class NotesServices
    {
        public static List<Notes> GetNotes(int CompanyId, ApplicationContext context)
        {
            List<Notes>  notes = new List<Notes>();
            try
            {
                notes = (from n in context.Notes
                             where n.cId == CompanyId
                             orderby n.InvoiceNumber
                             select n).ToList();
            }
            catch (Exception ex) { }
            if (notes.Count < 5) notes = CreateTestList(notes, CompanyId,  context);
            return notes;
        }

        static List<Notes> CreateTestList( List<Notes> notesList, int CompId, ApplicationContext context)
        {
            for (int i = 0; i <5; i++)
            {
                Notes notes = new Notes();
                try
                {
                    notes.cId = CompId;
                    notes.EmploeeFirstName = EmployeeServices.GetEmployees(CompId, context)[new Random().Next(5)].FirstName;
                    notes.EmploeeLastName = EmployeeServices.GetEmployees(CompId, context)[new Random().Next(5)].LastName;
                    notes.InvoiceNumber = i;
                    notesList.Add(notes);
                }
                catch { }    
            }
            return notesList;
        }
    }
}
