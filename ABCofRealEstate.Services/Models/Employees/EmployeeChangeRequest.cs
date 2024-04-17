namespace ABCofRealEstate.Services.Models.Employees
{
    public class EmployeeChangeRequest
    {
        public EmployeeChangeRequest(
            Guid id,
            string email,
            string fullName,
            EnumJobTitleEmployee jobTitle,
            string numberPhone)
        {
            Id = id;
            Email = email;
            FullName = fullName;
            JobTitle = jobTitle;
            NumberPhone = numberPhone;
        }
        public EmployeeChangeRequest()
        {
            
        }
        public Guid Id { get; init; }
        public string Email { get; init; }
        public string FullName { get; init; }
        public EnumJobTitleEmployee JobTitle { get; init; }
        public string NumberPhone { get; init; }
    }
}
