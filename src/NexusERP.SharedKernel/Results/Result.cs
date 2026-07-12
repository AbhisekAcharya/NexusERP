using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.SharedKernel.Results
{
    /// <summary>
    /// This class represents - "Did my operation succeed or not?"
    /// It does not returns any data, instead it returns success/failure.
    /// For example - "DeleteEmployee()" doesn't need to return an employee, instead it will return success/failure.
    /// </summary>
    public class Result
    {
        //Why the constructor is "protected" - because developers should not create the object of result class directly,
        //instead the developers should use the methods - Result.Success() or Result.Failure(...)
        protected Result(bool isSuccess, Error error)
        {
            //This used here beacause if developers write - 
            //if (isSuccess && error != Error.None)
            //This means - if "isSuccess" = true and "error" is not equals to "Error.None" - that means there is no error.
            //So eventually it says that the - operation is successful but there is an error. Thats impossible -  
            //hence we have an exception thrown here.
            if (isSuccess && error != Error.None)
                throw new ArgumentException();
            //This used here beacause if developers write - 
            //if (!isSuccess && error == Error.None)
            //This means - if "isSuccess" = false and "error" is equals to "Error.None" - that means there is no error.
            //So eventually it says that the - operation is unsuccessful but there is no error. Thats also impossible -  
            //hence we have an exception thrown here.
            if (!isSuccess && error == Error.None)
                throw new ArgumentException();
            IsSuccess = isSuccess;
            Error = error;
        }
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public Error Error { get; }
        //Factory Method - instead of writing "new Result(true, Error.None);" - we directly write "Result.Success()"
        public static Result Success()
        {
            return new Result(true, Error.None);
        }
        //Factory Method - instead of writing "new Result(false, error);" - we directly write "Result.Failure()"
        public static Result Failure(Error error)
        {
            return new Result(false, error);
        }
    }
}
