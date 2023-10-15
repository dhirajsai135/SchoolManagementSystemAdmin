namespace SchoolManagementSystemAdmin.Abstractions;

public interface ILoginService
{
    Task<ResponseMessageVM> Login(LoginRequest loginRequest);
}
