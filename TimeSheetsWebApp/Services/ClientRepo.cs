using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TimeSheetsWebApp.Models;
using TimeSheetsWebApp.Repositories.Interfaces;

namespace TimeSheetsWebApp.Services
{
    public class ClientRepo : IClientRepo
    {
        List<Client> data = new List<Client>();
        public void Create(Client item)
        {
            data.Add(item);
        }

        public void Delete(Client item)
        {
            data.Remove(item);
        }

        public IList<Client> GetList()
        {
            foreach (Client d in data)
            {
                Console.WriteLine(d);
            }
            return data;
        }

        public void Update(Client item, Client itemToUpdate)
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i] == item)
                    data[i] = itemToUpdate;
            }
        }
    }
}
