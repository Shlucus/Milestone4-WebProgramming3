using ECommerce.Api.Search.Interfaces;
using System.Threading.Tasks;

namespace ECommerce.Api.Search.Services
{
    public class CustomersService : ICustomerService
    {
        public Task<(bool IsSuccess, dynamic Customer, string ErrorMessage)> GetCustomerAsync(int customerId)
        {
            throw new System.NotImplementedException();
        }
    }
}
