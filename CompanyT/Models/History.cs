namespace CompanyT.Models
{
    public class History
    {
        public int Id { get; set; }
        public int cId { get; set; }
        public string? StoreCity { get; set; }
        public DateOnly OrderDate { get; set; }
    }
}
