namespace ABCofRealEstate.Data.Models
{
    public class Employee
    {
        public int IdEmployee { get; set; }
        public string? UrlImg { get; set; }
        public string Email { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string JobTitle { get; set; } = null!;
        public string NumberPhone { get; set; } = null!;
    }
}
