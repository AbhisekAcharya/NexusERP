using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.SharedKernel.Results
{
    /// <summary>
    /// This class is public because - Accessible from every project.
    /// This class is sealed because - nobody can inherit from it. We don't want people creating random subclasses that behave differently.
    /// This class has datatype record - A record is designed to represent data, not behavior.
    /// This class only stores data and messages 
    /// </summary>
    public sealed record Error
    {
        //This is static because only one copy of "None" will exist.Without static: Every Error object would contain its own "None".
        //This is readonly - because "Error.None = somethingElse;" will not be possible.
        //Why did we name it "None" ? - When an operation succeeds, there is no error. So instead of using "null", we will use "Error.None"
        //because using "null" creates NullReferenceExceptions, instead we will have a valid Error object
        public static readonly Error None = new(string.Empty, string.Empty);
        public Error(string code, string message)
        {
            Code = code;
            Message = message;
        }

        //datatype is string because - we know that after it is created it cannot be changed i.e. string is immutable
        public string Code { get; } 
        public string Message { get; }
    }
}
