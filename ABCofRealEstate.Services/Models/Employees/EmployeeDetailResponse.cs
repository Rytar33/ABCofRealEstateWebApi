namespace ABCofRealEstate.Services.Models.Employees
{
    public class EmployeeDetailResponse
    {
        public EmployeeDetailResponse(
            string? fullPathFile,
            Guid id,
            string email,
            string fullName,
            EnumJobTitleEmployee jobTitle,
            string numberPhone)
        {
            FullPathFile = fullPathFile;
            Id = id;
            Email = email;
            FullName = fullName;
            JobTitle = jobTitle;
            NumberPhone = numberPhone;
        }
        public string? FullPathFile { get; init; }
        public Guid Id { get; init; }
        public string Email { get; init; }
        public string FullName { get; init; }
        public EnumJobTitleEmployee JobTitle { get; init; }
        public string NumberPhone { get; init; }
    }
}
