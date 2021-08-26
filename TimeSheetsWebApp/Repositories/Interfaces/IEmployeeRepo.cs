using System.Runtime.InteropServices;
using TimeSheetsWebApp.Models;
using TimeSheetsWebApp.Models.Token;

namespace TimeSheetsWebApp.Repositories.Interfaces
{
    public interface IEmployeeRepo : IRepository<Employee>
    {
        TokenResponse Authenticate(string user, string password);
        string RefreshToken(string token);
    }
}
