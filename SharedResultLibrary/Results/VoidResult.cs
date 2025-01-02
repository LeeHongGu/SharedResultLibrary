using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SharedResultLibrary.Results
{
    /// <summary>
    /// Represents a result of an operation that does not return a value.
    /// </summary>
    [DataContract]
    public class VoidResult : DataResult
    {
        /// <summary>
        /// Creates a <see cref="VoidResult"/> by executing the specified action.
        /// </summary>
        /// <param name="doAction">The action to execute.</param>
        /// <returns>A <see cref="VoidResult"/> representing the result of the action.</returns>
        public static VoidResult Create(Action doAction)
        {
            var result = new VoidResult();

            try
            {
                doAction();
            }
            catch (Exception e)
            {
                result.Exception = e;
            }

            return result;
        }

        /// <summary>
        /// Asynchronously creates a <see cref="VoidResult"/> by executing the specified asynchronous action.
        /// </summary>
        /// <param name="doAction">The asynchronous action to execute.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="VoidResult"/> representing the result of the action.</returns>
        public static async Task<VoidResult> CreateAsync(Func<Task> doAction)
        {
            var result = new VoidResult();

            try
            {
                await doAction();
            }
            catch (Exception e)
            {
                result.Exception = e;
            }

            return result;
        }
    }
}
