using System;
using System.Collections.Generic;
using System.Text;

namespace MyLearningSkills.Infrastructure
{
    public class ApiException : Exception
    {
        public int ErrorCode { get; set; }
        public string? Details { get; set; }

        public ApiException(string message, int errorCode = 500, string? details = null) : base(message)
        {
            ErrorCode = errorCode;
            Details = details;
        }
    }
}
