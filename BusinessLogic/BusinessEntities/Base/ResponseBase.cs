using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.BusinessEntities.Base
{
    /// <summary>
    /// Base class for all responses
    /// </summary>
    public class ResponseBase
    {
        /// <summary>
        /// Error code for the specific error
        /// </summary>
        public int ErrorCode { get; set; }
        /// <summary>
        /// Error level
        /// </summary>
        public ErrorLevelType ErrorLevel { get; set; }
        /// <summary>
        /// Error message
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
