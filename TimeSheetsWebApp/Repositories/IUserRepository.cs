using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TimeSheetsWebApp.Models.EntityFramework;

namespace TimeSheetsWebApp.Repositories
{
    public interface IUserRepository<T> where T : class
    {
        IList<T> GetList();
        void Create(T item);

    }

}
