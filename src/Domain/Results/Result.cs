using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Results
{
    public record Error(string message, string code);
    public class Result<T> : Result
    {
        protected internal Result(T value, bool success, Error error)
            : base(success, error)
        {
            Value = value;
        }
        public T Value { get; set; }
    }
    public class Result
    {
        protected Result(bool success, Error error)
        {
            IsSuccess = success;
            Error = error;
        }

        public bool IsSuccess { get; }
        public Error Error { get; }
        public bool IsFailure => !IsSuccess;

        public static Result<T> Fail<T>(string message, string code = "")
        {
            return new Result<T>(default!, false, new Error(message, code));
        }
        public static Result Success()
        {
            return new Result(true, default!);
        }
        public static Result<T> Success<T>(T value)
        {
            return new Result<T>(value, true, default!);
        }

    }
}