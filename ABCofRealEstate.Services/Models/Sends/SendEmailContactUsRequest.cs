namespace ABCofRealEstate.Services.Models.Sends;

public class SendEmailContactUsRequest
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string NumberPhone { get; init; }
    public string Email { get; init; }
    public string Subject { get; init; }
    public string Message { get; init; }
}
