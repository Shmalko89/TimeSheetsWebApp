using System.Collections.Generic;
using System.Runtime.InteropServices;

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
