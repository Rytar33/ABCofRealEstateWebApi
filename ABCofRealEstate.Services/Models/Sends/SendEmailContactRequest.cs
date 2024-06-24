namespace ABCofRealEstate.Services.Models.Sends;

public class SendEmailContactRequest
{
    public string FullName { get; init; }
    public string NumberPhone { get; init; }
    public string Email { get; init; }
    public string Message { get; init; }
}
