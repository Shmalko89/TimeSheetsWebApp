using System;
using System.Runtime.InteropServices;

namespace TimeSheetsWebApp.Models.Token
{
    public class RefreshToken
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public bool IsExpired => DateTime.UtcNow >= Expires;
    }
}
