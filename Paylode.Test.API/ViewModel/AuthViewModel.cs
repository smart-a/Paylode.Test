namespace Paylode.Test.API.ViewModel;

public class AuthViewModel
{
    public bool IsSuccess { get; set; } = true;
    public string Message { get; set; } = "Success!";
    public string? Email { get; set; }
    public string? Token { get; set; }

    public AuthViewModel()
    {
    }
    
    public AuthViewModel(bool isSuccess, string message) => 
        (IsSuccess, Message) = (isSuccess, message);
}