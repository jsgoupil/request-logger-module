using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoiseBakery.RequestLogger
{
    /// <summary>
    /// Class holding important data about the request and response.
    /// </summary>
    public class LogEntry
    {
        /// <summary>
        /// Curated data from the request.
        /// </summary>
        public Request Request { get; set; }

        /// <summary>
        /// Curated data from the response.
        /// </summary>
        public Response Response { get; set; }

        /// <summary>
        /// Extra data saved by the developer.
        /// </summary>
        public Dictionary<string, object> Extra { get; set; }
    }
}
