using System;
using System.Collections.Generic;
using System.Text;

namespace NexusERP.SharedKernel.Responses
{
    public static class ResponseMessages
    {
        public const string Created = "Record created successfully.";
        public const string Updated = "Record updated successfully.";
        public const string Deleted = "Record deleted successfully.";
        public const string Retrieved = "Record retrieved successfully.";
        public const string RetrievedAll = "Records retrieved successfully.";
        public const string ValidationFailed = "Validation failed.";
        public const string NotFound = "Record not found.";
        public const string Conflict = "Record already exists.";
        public const string BadRequest = "Bad request.";
    }
}
