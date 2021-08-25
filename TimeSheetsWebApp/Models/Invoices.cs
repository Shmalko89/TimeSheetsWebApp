using System.Runtime.InteropServices;
using System;


namespace TimeSheetsWebApp.Models
{
    public class Invoices
    {
        public int Id { get; set; }
        public Contract IdContract { get; set; }
        public string Organisation { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public Employee IdEmployee { get; set; }
    }
}

