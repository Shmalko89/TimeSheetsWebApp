using System.Runtime.InteropServices;

namespace TimeSheetsWebApp.Models.Token
{
    public  class TokenResponse
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
