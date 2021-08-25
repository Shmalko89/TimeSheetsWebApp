using System.Collections.Generic;
using System.Runtime.InteropServices;
using TimeSheetsWebApp.Validation;

public interface IOperationResult<TResult>
{
    TResult Result { get; }

    IReadOnlyList<IOperationFailure> Failures { get; }

    bool Succeed { get; }
}

