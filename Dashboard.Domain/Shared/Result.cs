using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Domain.Shared
{
    public sealed class Result<T>
    {
        public bool IsSuccess { get; }
        public T? Value { get; }
        public Dictionary<string, string[]>? Errors { get; }

        private Result(bool isSuccess, T? value, Dictionary<string, string[]>? errors)
        {
            IsSuccess = isSuccess;
            Value = value;
            Errors = errors;
        }

        public static Result<T> Success(T value) => new(true, value, null);

        public static Result<T> Failure(Dictionary<string, string[]> errors) => new(false, default, errors);
    }
}
