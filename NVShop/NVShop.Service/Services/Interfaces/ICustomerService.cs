using NVShop.Service.DTOs.Customer;

namespace NVShop.Service.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<string> RegisterAsync(RegisterDto dto);
        Task<string> RemoveAccountAsync(string id);
        Task<string> UpdateAsync(string id, CustomerUpdateDto dto);
        Task<List<CustomerGetDto>> GetAllAsync();
        Task<CustomerGetDto> GetSingleAsync(string id);
        //ChangePassword
        //ChangeEmail
    }
}
