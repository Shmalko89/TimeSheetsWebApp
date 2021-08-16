using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TimeSheetsWebApp.Models;
using TimeSheetsWebApp.Repositories.Interfaces;

namespace TimeSheetsWebApp.Services
{
    public class ContractRepo : IContractRepo
    {
        List<Contract> data = new List<Contract>();
        public void Create(Contract item)
        {
            data.Add(item);
        }

        public void Delete(Contract item)
        {
            data.Remove(item);
        }

        public IList<Contract> GetList()
        {
            foreach (Contract d in data)
            {
                Console.WriteLine(d);
            }
            return data;
        }

        public void Update(Contract item, Contract itemToUpdate)
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i] == item)
                    data[i] = itemToUpdate;
            }
        }
    }
}