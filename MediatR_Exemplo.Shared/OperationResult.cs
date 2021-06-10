using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediatR_Exemplo.Shared
{
    public struct OperationResult<T>
    {
        public T Result { get; set; }
        public Exception Exception { get; }
        public bool IsSuccess { get; }

        public OperationResult(T result)
        {
            IsSuccess = true;
            Exception = null;
            Result = result;
        }
        public OperationResult(Exception exception)
        {
            IsSuccess = true;
            Exception = exception;
            Result = default;
        }

        public void Deconstruct(out bool success, out T result, out Exception exception)
        {
            success = IsSuccess;
            result = Result;
            exception = Exception;
        }

        public static implicit operator bool (OperationResult<T> operationResult)
            => operationResult.IsSuccess;

        public Task<OperationResult<T>> AsTask => Task.FromResult(this);
        public static OperationResult<T> Success(T result)
            => new OperationResult<T>(result);
        public static OperationResult<T> Error(Exception e)
            => new OperationResult<T>(e);
    }  
}
