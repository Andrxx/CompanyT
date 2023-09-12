namespace CompanyT.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public int cId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Position { get; set; }
        public string? Title { get; set; }
        public DateOnly BirthDate { get; set; }
    }
}
