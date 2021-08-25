using System.Runtime.InteropServices;

namespace TimeSheetsWebApp.Models.Token
{
    public class AuthResponse
    {
        public string Password { get; set; }
        public RefreshToken LatestRefreshToken { get; set; }
    }
}
