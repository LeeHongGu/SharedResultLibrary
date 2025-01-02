using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SharedResultLibrary.Results
{
    /// <summary>
    /// Represents a result that contains a single data item.
    /// </summary>
    /// <typeparam name="T">The type of the data item.</typeparam>
    [DataContract]
    public class SingleDataResult<T> : DataResult
    {
        /// <summary>
        /// Gets or sets the data item.
        /// </summary>
        [DataMember]
        public T Data { get; set; }

        /// <summary>
        /// Gets a value indicating whether the data item is null.
        /// </summary>
        [IgnoreDataMember]
        public bool IsNull => Data == null;

        /// <summary>
        /// Initializes a new instance of the <see cref="SingleDataResult{T}"/> class.
        /// </summary>
        public SingleDataResult()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SingleDataResult{T}"/> class with the specified data item.
        /// </summary>
        /// <param name="data">The data item to set.</param>
        public SingleDataResult(T data)
        {
            Data = data;
        }

        /// <summary>
        /// Creates a new <see cref="SingleDataResult{T}"/> instance using a function to generate the data item.
        /// </summary>
        /// <param name="getData">A function to generate the data item.</param>
        /// <returns>A new instance of <see cref="SingleDataResult{T}"/> containing the data or an exception if the function fails.</returns>
        public static SingleDataResult<T> Create(Func<T> getData)
        {
            var result = new SingleDataResult<T>();

            try
            {
                result.Data = getData();
            }
            catch (Exception e)
            {
                result.Exception = e;
            }

            return result;
        }

        /// <summary>
        /// Asynchronously creates a new <see cref="SingleDataResult{T}"/> instance using a function to generate the data item.
        /// </summary>
        /// <param name="getData">An asynchronous function to generate the data item.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result contains a new instance of 
        /// <see cref="SingleDataResult{T}"/> containing the data or an exception if the function fails.
        /// </returns>
        public static async Task<SingleDataResult<T>> CreateAsync(Func<Task<T>> getData)
        {
            var result = new SingleDataResult<T>();

            try
            {
                result.Data = await getData();
            }
            catch (Exception e)
            {
                result.Exception = e;
            }

            return result;
        }

        /// <summary>
        /// Implicitly converts the specified <see cref="SingleDataResult{T}"/> to its data item.
        /// </summary>
        /// <param name="result">The <see cref="SingleDataResult{T}"/> instance to convert.</param>
        public static implicit operator T(in SingleDataResult<T> result)
        {
            return result.Data;
        }
    }
}
