using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SharedResultLibrary.Results
{
    /// <summary>
    /// Represents a result that contains a boolean value.
    /// </summary>
    [DataContract]
    public class BooleanDataResult : DataResult
    {
        /// <summary>
        /// Gets or sets the boolean value.
        /// </summary>
        [DataMember]
        public bool Value { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BooleanDataResult"/> class.
        /// </summary>
        public BooleanDataResult()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BooleanDataResult"/> class with the specified boolean value.
        /// </summary>
        /// <param name="value">The boolean value to set.</param>
        public BooleanDataResult(bool value)
        {
            Value = value;
        }

        /// <summary>
        /// Creates a new <see cref="BooleanDataResult"/> instance using a function to generate the boolean value.
        /// </summary>
        /// <param name="getValue">A function to generate the boolean value.</param>
        /// <returns>
        /// A new instance of <see cref="BooleanDataResult"/> containing the boolean value or an exception if the function fails.
        /// </returns>
        public static BooleanDataResult Create(Func<bool> getValue)
        {
            var result = new BooleanDataResult();

            try
            {
                result.Value = getValue();
            }
            catch (Exception e)
            {
                result.Exception = e;
            }

            return result;
        }

        /// <summary>
        /// Asynchronously creates a new <see cref="BooleanDataResult"/> instance using a function to generate the boolean value.
        /// </summary>
        /// <param name="getValue">An asynchronous function to generate the boolean value.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result contains a new instance of 
        /// <see cref="BooleanDataResult"/> containing the boolean value or an exception if the function fails.
        /// </returns>
        public static async Task<BooleanDataResult> CreateAsync(Func<Task<bool>> getValue)
        {
            var result = new BooleanDataResult();

            try
            {
                result.Value = await getValue();
            }
            catch (Exception e)
            {
                result.Exception = e;
            }

            return result;
        }

        /// <summary>
        /// Implicitly converts the specified <see cref="BooleanDataResult"/> to its boolean value.
        /// </summary>
        /// <param name="result">The <see cref="BooleanDataResult"/> instance to convert.</param>
        public static implicit operator bool(in BooleanDataResult result)
        {
            return result.Value;
        }
    }
}
