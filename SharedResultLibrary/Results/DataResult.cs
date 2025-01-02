using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SharedResultLibrary.Results
{
    /// <summary>
    /// Represents the result of an operation that returns data.
    /// </summary>
    [DataContract]
    public abstract class DataResult
    {
        /// <summary>
        /// Gets or sets the exception associated with the data result.
        /// </summary>
        [DataMember]
        public Exception Exception { get; set; }

        /// <summary>
        /// Gets a value indicating whether the operation was successful.
        /// </summary>
        [IgnoreDataMember]
        public bool IsSuccess => Exception == null;

        /// <summary>
        /// Gets a value indicating whether the operation failed.
        /// </summary>
        [IgnoreDataMember]
        public bool IsFailure => Exception != null;

        /// <summary>
        /// Gets or sets the message associated with the data result.
        /// </summary>
        [DataMember]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the error code associated with the data result.
        /// </summary>
        [DataMember]
        public int? ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets the response time of the data result.
        /// </summary>
        [DataMember]
        public DateTime ResponseTime { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Implicitly converts the data result to a boolean value indicating success.
        /// </summary>
        /// <param name="result">The data result to convert</param>
        public static implicit operator bool(in DataResult result)
        {
            return result.IsSuccess;
        }
    }
}
