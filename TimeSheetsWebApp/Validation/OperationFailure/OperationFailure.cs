using System.Runtime.InteropServices;

namespace TimeSheetsWebApp.Validation
{
    public class OperationFailure : IOperationFailure
    {
        public string PropertyName { get; set; }

        public string Description { get; set; }

        public string Code { get; set; }
    }

    public interface IOperationFailure
    {
    }
}
