using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using TimeSheetsWebApp.Models;
using TimeSheetsWebApp.Models.Token;
using TimeSheetsWebApp.Repositories;
using TimeSheetsWebApp.Repositories.Interfaces;

namespace TimeSheetsWebApp.Services
{
    public class UserRepo : IUserRepo
    {
        List<Users> data = new List<Users>();
        public void Create(Users item)
        {
            data.Add(item);
        }

        public IList<Users> GetList()
        {
            foreach (Users d in data)
            {
                Console.WriteLine(d);
            }
            return data;
        }
    }
}