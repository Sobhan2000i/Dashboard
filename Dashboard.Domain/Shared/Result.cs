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
        public List<T>? Data { get; }
        public Dictionary<string, string[]>? Errors { get; }

        private Result(bool isSuccess, List<T>? data, Dictionary<string, string[]>? errors)
        {
            IsSuccess = isSuccess;
            Data = data;
            Errors = errors;
        }

        public static Result<T> Success(List<T> data) => new(true, data, null);

        public static Result<T> Failure(Dictionary<string, string[]> errors) => new(false, null, errors);
    }

}
