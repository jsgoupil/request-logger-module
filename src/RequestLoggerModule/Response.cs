using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoiseBakery.RequestLogger
{
    /// <summary>
    /// Response class holding important data about the http response.
    /// </summary>
    public class Response
    {
        /// <summary>
        /// Status Code (e.g. 200)
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Status Description (e.g. OK)
        /// </summary>
        public string StatusDescription { get; set; }

        /// <summary>
        /// List of headers key/value pair sent from the server.
        /// </summary>
        public System.Collections.Specialized.NameValueCollection Headers { get; set; }

        /// <summary>
        /// Response body sent back to the client.
        /// </summary>
        public string Body { get; set; }
    }
}
