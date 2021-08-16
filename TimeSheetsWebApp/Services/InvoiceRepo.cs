using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TimeSheetsWebApp.Models;
using TimeSheetsWebApp.Repositories.Interfaces;

namespace TimeSheetsWebApp.Services
{
    public class InvoiceRepo : IInvoiceRepo
    {
        List<Invoices> data = new List<Invoices>();
        public void Create(Invoices item)
        {
            data.Add(item);
        }

        public void Delete(Invoices item)
        {
            data.Remove(item);
        }

        public IList<Invoices> GetList()
        {
            foreach (Invoices d in data)
            {
                Console.WriteLine(d);
            }
            return data;
        }

        public void Update(Invoices item, Invoices itemToUpdate)
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i] == item)
                    data[i] = itemToUpdate;
            }
        }
    }
}