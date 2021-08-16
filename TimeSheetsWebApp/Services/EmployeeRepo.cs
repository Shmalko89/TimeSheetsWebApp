using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TimeSheetsWebApp.Models;
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
    }
}