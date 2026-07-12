using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.SharedKernel.Results
{
    public class Result<T> : Result
    {
        private readonly T? _value;
        protected internal Result(T? value, bool isSuccess, Error error) : base(isSuccess, error)
        {
            _value = value;
        }
        public T Value => IsSuccess ? _value! : throw new InvalidOperationException();
        public static Result<T> Success(T value)
        {
            return new Result<T>(value, true, Error.None);
        }
        public static new Result<T> Failure(Error error)
        {
            return new Result<T>(default, false, error);
        }
    }
}
