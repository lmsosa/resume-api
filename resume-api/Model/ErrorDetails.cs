using System.Collections.Generic;

namespace Resume.WebApi.Model
{
    /// <summary>
    /// Represents an error that occurred
    /// </summary>
    public class ErrorDetails
    {
        /// <summary>
        /// Static method that creates a new instance of <see cref="ErrorDetails"/>
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ErrorDetails For(string message)
        {
            return new ErrorDetails()
            {
                Message = message
            };
        }

        /// <summary>
        /// Human-readable message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// List of technical-type error messages
        /// </summary>
        public List<string> Errors { get; set; }
    }
}
