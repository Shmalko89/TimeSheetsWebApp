using System;
using System.Runtime.InteropServices;

namespace TimeSheetsWebApp.Models
{
    public class Contract
    {
        public int Id { get; set; }
        public string NameOfContract { get; set; }
        public string Organisation { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
    }
}
