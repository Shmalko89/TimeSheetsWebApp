using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TimeSheetsWebApp.Models.EntityFramework;

namespace TimeSheetsWebApp.Repositories
{
    public interface IRepository<T> where T : class
    {
        IList<T> GetList();
        void Create(T item);
        void Update(T item, T itemToUpdate);
        void Delete(T item);
    }

}
