using System.Runtime.InteropServices;
using TimeSheetsWebApp.Models;
using TimeSheetsWebApp.Models.Token;

namespace TimeSheetsWebApp.Repositories.Interfaces
{
    public interface IClientRepo : IRepository<Client>
    {
        TokenResponse Authenticate(string user, string password);
        string RefreshToken(string token);
    }
}
