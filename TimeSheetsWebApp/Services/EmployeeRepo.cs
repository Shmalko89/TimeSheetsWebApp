using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using TimeSheetsWebApp.Models;
using TimeSheetsWebApp.Models.Token;
using TimeSheetsWebApp.Repositories.Interfaces;

namespace TimeSheetsWebApp.Services
{
    public class EmployeeRepo : IEmployeeRepo
    {
        List<Employee> data = new List<Employee>();
        public void Create(Employee item)
        {
            data.Add(item);
        }

        public void Delete(Employee item)
        {
            data.Remove(item);
        }

        public IList<Employee> GetList()
        {
            foreach (Employee d in data)
            {
                Console.WriteLine(d);
            }
            return data;
        }

        public void Update(Employee item, Employee itemToUpdate)
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i] == item)
                    data[i] = itemToUpdate;
            }
        }

        private IDictionary<string, AuthResponse> _users = new Dictionary<string, AuthResponse>()
        {
            {"test", new AuthResponse() {Password = "test"} }
        };

        public const string SecretCode = "THIS IS SOME VERY SECRET STRING!!!";

        public TokenResponse Authenticate(string user, string password)
        {
            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(password))
            {
                return null;
            }
            TokenResponse tokenResponse = new TokenResponse();
            int i = 0;
            foreach (KeyValuePair<string, AuthResponse> pair in _users)
            {
                i++;
                if (string.CompareOrdinal(pair.Key, user) == 0 && string.CompareOrdinal(pair.Value.Password, password) == 0)
                {
                    tokenResponse.Token = GenerateJwtToken(i, 15);
                    RefreshToken refreshToken = GenerateRefreshToken(i);
                    pair.Value.LatestRefreshToken = refreshToken;
                    tokenResponse.RefreshToken = refreshToken.Token;
                    return tokenResponse;
                }
            }
            return null;
        }
        public string RefreshToken(string token)
        {
            int i = 0;
            foreach (KeyValuePair<string, AuthResponse> pair in _users)
            {
                i++;
                if (string.CompareOrdinal(pair.Value.LatestRefreshToken.Token, token) == 0
                    && pair.Value.LatestRefreshToken.IsExpired is false)
                {
                    pair.Value.LatestRefreshToken = GenerateRefreshToken(i);
                    return pair.Value.LatestRefreshToken.Token;
                }
            }
            return string.Empty;
        }
        private string GenerateJwtToken(int id, int minutes)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(SecretCode);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(minutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public RefreshToken GenerateRefreshToken(int id)
        {
            RefreshToken refreshToken = new RefreshToken();
            refreshToken.Expires = DateTime.Now.AddMinutes(360);
            refreshToken.Token = GenerateJwtToken(id, 360);
            return refreshToken;
        }
    }
}
