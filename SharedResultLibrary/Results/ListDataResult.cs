using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SharedResultLibrary.Results
{
    /// <summary>
    /// Represents a result that contains a list of data items.
    /// </summary>
    /// <typeparam name="T">The type of data in the list.</typeparam>
    [DataContract]
    public class ListDataResult<T> : DataResult
    {
        /// <summary>
        /// Gets or sets the list of data items.
        /// </summary>
        [DataMember]
        public List<T> DataList { get; set; } = new List<T>();

        /// <summary>
        /// Gets the total count of items in the data list.
        /// </summary>
        [IgnoreDataMember]
        public int TotalCount => DataList?.Count ?? 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListDataResult{T}"/> class.
        /// </summary>
        public ListDataResult()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListDataResult{T}"/> class with the specified data list.
        /// </summary>
        /// <param name="dataList">The list of data items.</param>
        public ListDataResult(List<T> dataList)
        {
            DataList = dataList;
        }

        /// <summary>
        /// Creates a new <see cref="ListDataResult{T}"/> instance using a function to generate the data list.
        /// </summary>
        /// <param name="getDataList">A function to generate the data list.</param>
        /// <returns>A new instance of <see cref="ListDataResult{T}"/> containing the data list or an exception if the function fails.</returns>
        public static ListDataResult<T> Create(Func<List<T>> getDataList)
        {
            var result = new ListDataResult<T>();

            try
            {
                result.DataList = getDataList();
            }
            catch (Exception e)
            {
                result.Exception = e;
            }

            return result;
        }

        /// <summary>
        /// Asynchronously creates a new <see cref="ListDataResult{T}"/> instance using a function to generate the data list.
        /// </summary>
        /// <param name="getDataList">An asynchronous function to generate the data list.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result contains a new instance of 
        /// <see cref="ListDataResult{T}"/> containing the data list or an exception if the function fails.
        /// </returns>
        public static async Task<ListDataResult<T>> CreateAsync(Func<Task<List<T>>> getDataList)
        {
            var result = new ListDataResult<T>();

            try
            {
                result.DataList = await getDataList();
            }
            catch (Exception e)
            {
                result.Exception = e;
            }

            return result;
        }
    }
}
